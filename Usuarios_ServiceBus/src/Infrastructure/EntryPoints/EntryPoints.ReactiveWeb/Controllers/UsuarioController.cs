using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntryPoints.ReactiveWeb.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly IUsuarioUseCase _usuario;

        public UsuarioController(IUsuarioUseCase usuario)
        {
            _usuario = usuario;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioRequest usuario)
        {
            return Ok(await _usuario.CreateSendMessage(usuario));
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioRequest>>> Get()
        {
            return Ok(await _usuario.GetAllUsers());
        }


    }
}
