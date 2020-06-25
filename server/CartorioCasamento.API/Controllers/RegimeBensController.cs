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
    public class RegimeBensController : ControllerBase
    {
        private readonly IRegimeBensService _regimeBensService;
        private readonly IMapper _mapper;

        public RegimeBensController(IRegimeBensService regimeBensService, IMapper mapper)
        {
            _regimeBensService = regimeBensService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegimeBensViewModel>>> Get()
        {
            return _mapper.Map<List<RegimeBensViewModel>>(await _regimeBensService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RegimeBensViewModel>> Get(int id)
        {
            var regimeBensViewModel = await _regimeBensService.GetById(id);

            if (regimeBensViewModel == null) return NotFound();

            return _mapper.Map<RegimeBensViewModel>(regimeBensViewModel);
        }


    }
}
