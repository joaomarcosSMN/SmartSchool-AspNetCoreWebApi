using AutoMapper;
using SmatSchool.WebAPI.DTOs;
using SmatSchool.WebAPI.Models;

namespace SmatSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    destino => destino.Nome,
                    opcao => opcao.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    destino => destino.Idade,
                    opcao => opcao.MapFrom(src => src.DataNascimento.GetCurrenteAge())
                );
                
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

            CreateMap<Professor, ProfessorDto>().ReverseMap();
        }
    }
}