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
    public class PedidoCasamentoController : ControllerBase
    {
        private readonly IPedidoCasamentoService _pedidoCasamentoService;
        private readonly IMapper _mapper;

        public PedidoCasamentoController(IPedidoCasamentoService pedidoCasamentoService, IMapper mapper)
        {
            _pedidoCasamentoService = pedidoCasamentoService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoCasamentoViewModel>> Get(int id)
        {
            var pedidoCasamentoViewModel = await _pedidoCasamentoService.GetById(id);

            if (pedidoCasamentoViewModel == null) return NotFound();

            return _mapper.Map<PedidoCasamentoViewModel>(pedidoCasamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PedidoCasamentoViewModel pedidoCasamentoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Success = false, Message = "Modelo inválido." });

            await _pedidoCasamentoService.Add(_mapper.Map<PedidoCasamento>(pedidoCasamentoViewModel));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, PedidoCasamentoViewModel pedidoCasamentoViewModel)
        {
            if (id != pedidoCasamentoViewModel.Id) return BadRequest(new { Success = false, Message = "Id informato está diferente do modelo enviado." });

            await _pedidoCasamentoService.Update(_mapper.Map<PedidoCasamento>(pedidoCasamentoViewModel));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedidoCasamentoViewModel = await _pedidoCasamentoService.GetById(id);

            if (pedidoCasamentoViewModel == null) return NotFound();

            await _pedidoCasamentoService.Remove(id);

            return Ok();
        }

    }
}
