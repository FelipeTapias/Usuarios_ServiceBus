using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Usuarios_ServiceBus.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly IAppServiceBus _appServiceBus;

        public UsuarioController(IAppServiceBus appServiceBus)
        {
            _appServiceBus = appServiceBus;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            await _appServiceBus.SendMessage(usuario);
            return Ok();
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Usuario>>> Get()
        //{
        //    return new List<Usuario>() {
        //        new Usuario() { Id = 0, Nombre = "Felipe Tapias", Documento = 1000758512, Edad = 20, Id_Apartamento = 1 },
        //        new Usuario() { Id = 1, Nombre = "Andres Tuberquia", Documento = 148754255, Edad = 32, Id_Apartamento = 2 }
        //    };
        //}

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _appServiceBus.RecieveMessage();
            return Ok();
        }

    }
}
