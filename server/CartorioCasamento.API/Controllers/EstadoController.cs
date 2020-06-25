using System.Collections;
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
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;
        private readonly IMapper _mapper;

        public EstadoController(IEstadoService estadoService, IMapper mapper)
        {
            _estadoService = estadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoViewModel>>> ObterEstados()
        {
            return _mapper.Map<List<EstadoViewModel>>(await _estadoService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EstadoViewModel>> ObterPorId(int id)
        {
            var estadoViewModel = await _estadoService.GetById(id);

            if (estadoViewModel == null) return NotFound();

            return _mapper.Map<EstadoViewModel>(estadoViewModel);
        }

        [HttpGet("/[action]")]
        public async Task<ActionResult<EstadoViewModel>> ObterPorSigla(string sigla)
        {
            var estadoViewModel = await _estadoService.BuscaEstadoPorSigla(sigla);

            if (estadoViewModel == null) return NotFound();

            return _mapper.Map<EstadoViewModel>(estadoViewModel);
        }

    }
}
