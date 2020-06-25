using System;
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
        private readonly IEstadoService _estadoService;
        private readonly IMapper _mapper;

        public CasamentoController(ICasamentoService casamentoService, IMapper mapper, IEstadoService estadoService)
        {
            _casamentoService = casamentoService;
            _mapper = mapper;
            _estadoService = estadoService;
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

        [HttpPost("{id:int}, {idUsuarioTestemunha:int}")]
        public async Task<IActionResult> InserirPrimeiraTestemunhaCasamento(int id, int idUsuarioTestemunha)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            if (casamento.UsuarioPrimeiraTestemunhaId.HasValue && casamento.UsuarioPrimeiraTestemunhaId.HasValue)
                return BadRequest(new { Success = false, Message = "Este casamento já possui as duas testemunhas necessárias." });

            if (!casamento.UsuarioPrimeiraTestemunhaId.HasValue)
            {
                casamento.UsuarioPrimeiraTestemunhaId = idUsuarioTestemunha;
            }
            else
            {
                casamento.UsuarioSegundaTestemunhaId = idUsuarioTestemunha;
            }

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}, {idUsuarioTestemunha:int}")]
        public async Task<IActionResult> AlterarPrimeiraTestemunhaCasamento(int id, int idUsuarioTestemunha)
        {
            var casamento = await _casamentoService.GetById(id);

            if (casamento == null) return NotFound();

            casamento.UsuarioPrimeiraTestemunhaId = idUsuarioTestemunha;
            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}, {idUsuarioTestemunha:int}")]
        public async Task<IActionResult> AlterarSegundaTestemunhaCasamento(int id, int idUsuarioTestemunha)
        {
            var casamento = await _casamentoService.GetById(id);

            if (casamento == null) return NotFound();

            casamento.UsuarioSegundaTestemunhaId = idUsuarioTestemunha;
            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> SolicitarEntradaCasamento(int id, string siglaEstado)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound(new { Success = false, Message = "Casamento não encontrado." });

            var estado = await _estadoService.BuscaEstadoPorSigla(siglaEstado);
            if (estado == null) return NotFound(new { Success = false, Message = "Estado não encontrado." });

            casamento.DataEntrada = DateTime.Now;
            casamento.ValorCasamento = estado.ValorCasamento;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> AprovarEntradaCasamento(int id, DateTime dataAprovacao)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            casamento.DataAprovacaoEntrada = dataAprovacao;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> DefinirDataCasamento(int id, DateTime dataCasamento)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            //if (!casamento.DataAprovacaoEntrada.HasValue)
            //    return BadRequest(new { Success = false, Message = "A entrada deste casamento não foi aprovada pelo cartório ainda." });

            //var dataLimiteCasamento = casamento.DataAprovacaoEntrada.Value.AddMonths(6).Date;
            //if (dataCasamento.Date > dataLimiteCasamento)
            //    return BadRequest(new
            //    {
            //        Success = false,
            //        Message = "A data do casamento deve ser até 6 meses após a aprovação do cartório, dia " + dataLimiteCasamento.ToShortDateString() + "."
            //    });

            casamento.DataCasamento = dataCasamento;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> DefinirRealizacaoCasamento(int id, string linkCerimoniaGravada)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            //if (!casamento.DataCasamento.HasValue)
            //    return BadRequest(new { Success = false, Message = "Este casamento não pode ser realizado, pois a data ainda não foi definida." });

            casamento.DataRealizacaoCasamento = DateTime.Now;
            casamento.LinkCerimoniaGravada = linkCerimoniaGravada;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> DefinirAprovacaoDiarioOficial(int id, DateTime dataAprovacaoDiarioOficial)
        {
            var casamento = await _casamentoService.GetById(id);

            if (casamento == null) return NotFound();

            casamento.DataAprovacaoDiarioOficial = dataAprovacaoDiarioOficial;

            await _casamentoService.Update(casamento);

            return Ok();
        }

    }
}
