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
        public async Task<ActionResult<CasamentoViewModel>> ObterPorId(int id)
        {
            var casamentoViewModel = await _casamentoService.GetById(id);

            if (casamentoViewModel == null) return NotFound();

            return _mapper.Map<CasamentoViewModel>(casamentoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var casamentoViewModel = await _casamentoService.FindAsNoTracking(id);

            if (casamentoViewModel == null) return NotFound();

            await _casamentoService.Remove(id);

            return Ok();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CasamentoViewModel>> BuscaCasamentoUsuario(int idUsuario)
        {
            var casamentoViewModel = await _casamentoService.BuscarCasamentoUsuario(idUsuario);
            return _mapper.Map<CasamentoViewModel>(casamentoViewModel);
        }

        [HttpPost("/[action]/{id:int}, {idUsuarioTestemunha:int}")]
        public async Task<IActionResult> InserirTestemunhaCasamento(int id, int idUsuarioTestemunha)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            if (casamento.UsuarioPrimeiraTestemunhaId.HasValue && casamento.UsuarioSegundaTestemunhaId.HasValue)
                return BadRequest(new { Success = false, Message = "Este casamento já possui as duas testemunhas necessárias." });

            if (!casamento.UsuarioPrimeiraTestemunhaId.HasValue)
            {
                casamento.UsuarioPrimeiraTestemunhaId = idUsuarioTestemunha;
            }
            else
            {
                if (casamento.UsuarioPrimeiraTestemunhaId == idUsuarioTestemunha)
                    return BadRequest(new { Success = false, Message = "Esta testemunha já está cadastrada para este casamento." });

                casamento.UsuarioSegundaTestemunhaId = idUsuarioTestemunha;
            }

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("/[action]/{id:int}, {idUsuarioTestemunha:int}")]
        public async Task<IActionResult> AlterarPrimeiraTestemunhaCasamento(int id, int idUsuarioTestemunha)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            if(!VerificaTestemunhaCasamento(casamento, idUsuarioTestemunha))
                return BadRequest(new { Success = false, Message = "Esta testemunha já está cadastrada para este casamento." });

            casamento.UsuarioPrimeiraTestemunhaId = idUsuarioTestemunha;
            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("/[action]/{id:int}, {idUsuarioTestemunha:int}")]
        public async Task<IActionResult> AlterarSegundaTestemunhaCasamento(int id, int idUsuarioTestemunha)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            if (!VerificaTestemunhaCasamento(casamento, idUsuarioTestemunha))
                return BadRequest(new { Success = false, Message = "Esta testemunha já está cadastrada para este casamento." });

            casamento.UsuarioSegundaTestemunhaId = idUsuarioTestemunha;
            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("/[action]/{id:int}")]
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

        [HttpPost("/[action]/{id:int},{dataAprovacao:DateTime}")]
        public async Task<IActionResult> AprovarEntradaCasamento(int id, DateTime dataAprovacao)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            casamento.DataAprovacaoEntrada = dataAprovacao;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("/[action]/{id:int},{dataCasamento:DateTime}")]
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

        [HttpPost("/[action]/{id:int}")]
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

        [HttpPost("/[action]/{id:int},{dataAprovacaoDiarioOficial:DateTime}")]
        public async Task<IActionResult> DefinirAprovacaoDiarioOficial(int id, DateTime dataAprovacaoDiarioOficial)
        {
            var casamento = await _casamentoService.GetById(id);

            if (casamento == null) return NotFound();

            casamento.DataAprovacaoDiarioOficial = dataAprovacaoDiarioOficial;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        [HttpPost("/[action]/{id:int},{dataDivorcio:DateTime}")]
        public async Task<IActionResult> DefinirDivorcio(int id, DateTime dataDivorcio)
        {
            var casamento = await _casamentoService.GetById(id);
            if (casamento == null) return NotFound();

            casamento.DataDivorcio = dataDivorcio;

            await _casamentoService.Update(casamento);

            return Ok();
        }

        private bool VerificaTestemunhaCasamento(Casamento casamento, int idUsuarioTestemunha)
        {
            if (casamento.UsuarioPrimeiraTestemunhaId.HasValue)
            {
                if (casamento.UsuarioPrimeiraTestemunhaId.Value == idUsuarioTestemunha) return false;
            }

            if (casamento.UsuarioSegundaTestemunhaId.HasValue)
            {
                if (casamento.UsuarioSegundaTestemunhaId.Value == idUsuarioTestemunha) return false;
            }

            return true;
        }
    }
}
