using AutoMapper;
using CartorioCasamento.API.ViewModels;
using CartorioCasamento.Domain.Models;
using System.Drawing;

namespace CartorioCasamento.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Casamento, CasamentoViewModel>().ReverseMap();
            CreateMap<Estado, EstadoViewModel>().ReverseMap();
            CreateMap<PedidoCasamento, PedidoCasamentoViewModel>().ReverseMap();
            CreateMap<RegimeBens, RegimeBensViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
