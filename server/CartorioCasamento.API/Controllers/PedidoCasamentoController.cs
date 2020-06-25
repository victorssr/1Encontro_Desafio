using System;
using System.Collections.Generic;
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
        private readonly IUsuarioService _usuarioService;
        private readonly ICasamentoService _casamentoService;
        private readonly IMapper _mapper;

        public PedidoCasamentoController(IPedidoCasamentoService pedidoCasamentoService, IMapper mapper, IUsuarioService usuarioService,
            ICasamentoService casamentoService)
        {
            _pedidoCasamentoService = pedidoCasamentoService;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _casamentoService = casamentoService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoCasamentoViewModel>> ObterPorId(int id)
        {
            var pedidoCasamentoViewModel = await _pedidoCasamentoService.GetById(id);

            if (pedidoCasamentoViewModel == null) return NotFound();

            return _mapper.Map<PedidoCasamentoViewModel>(pedidoCasamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PedidoCasamentoViewModel pedidoCasamentoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Success = false, Message = "Modelo inválido." });

            var usuarioSolicitante = await _usuarioService.FindAsNoTracking(pedidoCasamentoViewModel.UsuarioSolicitanteId);
            if (usuarioSolicitante == null) return BadRequest(new { Success = false, Message = "Usuário solicitante não encontrado." });
            //if (!usuarioSolicitante.Desimpedido) return BadRequest(new { Success = false, Message = "Usuário solicitante está impedido." });

            var usuarioSolicitado = await _usuarioService.FindAsNoTracking(pedidoCasamentoViewModel.UsuarioSolicitadoId);
            if (usuarioSolicitado == null) return BadRequest(new { Success = false, Message = "Usuário solicitado não encontrado." });
            //if (!usuarioSolicitado.Desimpedido) return BadRequest(new { Success = false, Message = "Usuário solicitado está impedido." });

            await _pedidoCasamentoService.Add(_mapper.Map<PedidoCasamento>(pedidoCasamentoViewModel));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, PedidoCasamentoViewModel pedidoCasamentoViewModel)
        {
            if (id != pedidoCasamentoViewModel.Id) return BadRequest(new { Success = false, Message = "Id informato está diferente do modelo enviado." });

            await _pedidoCasamentoService.Update(_mapper.Map<PedidoCasamento>(pedidoCasamentoViewModel));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var pedidoCasamentoViewModel = await _pedidoCasamentoService.FindAsNoTracking(id);

            if (pedidoCasamentoViewModel == null) return NotFound();

            await _pedidoCasamentoService.Remove(id);

            return Ok();
        }

        [HttpGet("/[action]/{idUsuario:int}")]
        public async Task<ActionResult<List<PedidoCasamentoViewModel>>> BuscarPedidosPendentes(int idUsuario)
        {
            var usuario = await _usuarioService.FindAsNoTracking(idUsuario);

            if (usuario == null) return NotFound();

            var pedidosPendentes = await _pedidoCasamentoService.BuscaPedidosPendentesUsuario(idUsuario);
            return _mapper.Map<List<PedidoCasamentoViewModel>>(pedidosPendentes);
        }

        [HttpPost("/[action]/{id:int}, {aceitarPedido:bool}")]
        public async Task<IActionResult> ResponderPedidoCasamento(int id, bool aceitarPedido)
        {
            var pedidoCasamento = await _pedidoCasamentoService.GetById(id);
            if (pedidoCasamento == null) return NotFound();

            if (pedidoCasamento.DataPedidoAceito.HasValue || pedidoCasamento.DataPedidoNegado.HasValue)
                return BadRequest(new { Success = false, Message = "Este pedido de casamento já foi respondido." });

            if (!aceitarPedido)
            {
                pedidoCasamento.DataPedidoNegado = DateTime.Now;
                await _pedidoCasamentoService.Update(pedidoCasamento);
                return NoContent();
            }

            pedidoCasamento.DataPedidoAceito = DateTime.Now;
            await _pedidoCasamentoService.Update(pedidoCasamento);

            var casamento = new Casamento
            {
                PedidoCasamentoId = id
            };
            await _casamentoService.Add(casamento);

            return Ok(new { Success = true, IdCasamento = casamento.Id });
        }

    }
}
