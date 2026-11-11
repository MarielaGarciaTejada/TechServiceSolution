using Microsoft.AspNetCore.Mvc;
using TechService.Infrastructure.Models;
using TechService.Application.Services;
using TechService.Application.Dtos;

namespace TechService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController(UsuariosService usuariosService, ILogger<UsuariosController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
    {
        logger.LogInformation("Consultando lista completa de usuarios");
        var lista = await usuariosService.GetList();
        return Ok(lista);
    }

    [HttpGet("roles")]
    public async Task<ActionResult<IEnumerable<RolDto>>> GetRoles()
    {
        var roles = await usuariosService.GetRoles();
        return Ok(roles);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UsuarioDto>> GetById(int id)
    {
        var result = await usuariosService.Buscar(id);
        var usuario = result.Value;

        if (usuario == null)
            return NotFound(new { mensaje = $"Usuario con ID {id} no encontrado." });

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDto usuario)
    {
        if (await usuariosService.ExisteNombreUsuario(usuario.NombreUsuario))
            return BadRequest(new { mensaje = $"El nombre de usuario '{usuario.NombreUsuario}' ya está en uso." });
        
        var guardado = await usuariosService.Guardar(usuario);

        if (!guardado.IsSuccess)
            return BadRequest(new { mensaje = "No fue posible registrar el usuario." });

        return CreatedAtAction(nameof(GetById), new { id = usuario.UsuarioId }, usuario);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto usuario)
    {
        if (id != usuario.UsuarioId)
            return BadRequest(new { mensaje = "El ID no coincide con el cuerpo." });
        if (!await usuariosService.Existe(id))
            return NotFound(new { mensaje = $"El usuario {id} no existe." });
        if (await usuariosService.ExisteNombreUsuario(usuario.NombreUsuario, id))
            return BadRequest(new { mensaje = $"El nombre de usuario '{usuario.NombreUsuario}' ya está registrado en otra cuenta." });
        
        var actualizado = await usuariosService.Modificar(usuario);

        if (!actualizado)
            return BadRequest(new { mensaje = "Error al actualizar los datos del usuario." });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await usuariosService.Eliminar(id);

        if (!eliminado.IsSuccess)
            return NotFound(new { mensaje = $"El usuario {id} no fue encontrado o no se pudo desactivar." });

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.NombreUsuario) || string.IsNullOrWhiteSpace(request.Contrasena))
            return BadRequest(new LoginResponseDto { Exito = false, Mensaje = "Debe proporcionar usuario y contraseña." });

        var usuario = await usuariosService.Login(request.NombreUsuario, request.Contrasena);

        if (usuario == null)
            return Unauthorized(new LoginResponseDto { Exito = false, Mensaje = "Credenciales incorrectas o usuario inactivo." });

        return Ok(new LoginResponseDto
        {
            Exito = true,
            Mensaje = $"Bienvenido/a {usuario.NombreCompleto}",
            Usuario = usuario
        });
    }
}