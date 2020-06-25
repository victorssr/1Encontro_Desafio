﻿using System.Threading.Tasks;
using AutoMapper;
using CartorioCasamento.API.ViewModels;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartorioCasamento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> Get(int id)
        {
            var usuarioViewModel = await _usuarioService.GetById(id);

            if (usuarioViewModel == null) return NotFound();

            return _mapper.Map<UsuarioViewModel>(usuarioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Success = false, Message = "Modelo inválido." });

            await _usuarioService.Add(_mapper.Map<Usuario>(usuarioViewModel));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return BadRequest(new { Success = false, Message = "Id informato está diferente do modelo enviado." });

            await _usuarioService.Update(_mapper.Map<Usuario>(usuarioViewModel));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioViewModel = await _usuarioService.GetById(id);

            if (usuarioViewModel == null) return NotFound();

            await _usuarioService.Remove(id);

            return Ok();
        }

    }
}
