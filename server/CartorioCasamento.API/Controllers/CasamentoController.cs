using System.Threading.Tasks;
using AutoMapper;
using CartorioCasamento.API.ViewModels;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartorioCasamento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CasamentoController : ControllerBase
    {
        private readonly ICasamentoService _casamentoService;
        private readonly IMapper _mapper;

        public CasamentoController(ICasamentoService casamentoService, IMapper mapper)
        {
            _casamentoService = casamentoService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CasamentoViewModel>> Get(int id)
        {
            var casamentoViewModel = await _casamentoService.GetById(id);

            if (casamentoViewModel == null) return NotFound();

            return _mapper.Map<CasamentoViewModel>(casamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CasamentoViewModel casamentoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Success = false, Message = "Modelo inválido." });

            await _casamentoService.Add(_mapper.Map<Casamento>(casamentoViewModel));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, CasamentoViewModel casamentoViewModel)
        {
            if (id != casamentoViewModel.Id) return BadRequest(new { Success = false, Message = "Id informato está diferente do modelo enviado." });

            await _casamentoService.Update(_mapper.Map<Casamento>(casamentoViewModel));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var casamentoViewModel = await _casamentoService.GetById(id);

            if (casamentoViewModel == null) return NotFound();

            await _casamentoService.Remove(id);

            return Ok();
        }

    }
}
