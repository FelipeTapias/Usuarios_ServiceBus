using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntryPoints.ReactiveWeb.Controllers
{
    [Route("api/apartamentos")]
    [ApiController]
    public class ApartamentoController : ControllerBase
    {
        private readonly IApartamentoUseCase _apartamentoUseCase;

        public ApartamentoController(IApartamentoUseCase apartamentoUseCase)
        {
            _apartamentoUseCase = apartamentoUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<ApartamentoResponse>>> Get()
        {
            return Ok(await _apartamentoUseCase.GetAllApartamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartamentoResponse>> GetApartamentoById(int id)
        {
            return Ok(await _apartamentoUseCase.GetApartamentoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ApartamentoRequest>> Post(ApartamentoRequest apartamentoRequest)
        {
            return await _apartamentoUseCase.PostApartamento(apartamentoRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApartamentoResponse>> Put(ApartamentoRequest apartamento, int id)
        {
            return await _apartamentoUseCase.PutApartamento(apartamento, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApartamentoResponse>> Delete(int id)
        {
            return await _apartamentoUseCase.DeleteApartamento(id);
        }
        
    }
}
