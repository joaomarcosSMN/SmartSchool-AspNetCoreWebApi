using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmatSchool.WebAPI.Data;
using SmatSchool.WebAPI.DTOs;
using SmatSchool.WebAPI.Models;

namespace SmatSchool.WebAPI.Controllers
{

  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/[controller]")]
  public class AlunoController : ControllerBase
  {
    // private readonly DataContext context;
    public readonly IRepository _repo;
    public readonly IMapper _mapper;

    public AlunoController(IRepository repo,
                           IMapper mapper)
    {
      _mapper = mapper;
      //   this.context = context;
      // _context = context;
      _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var alunos = _repo.GetAllAlunos(true);
      return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var aluno = _repo.GetAlunoById(id, false);
      if (aluno == null) return BadRequest("Aluno não encontrado");

      var alunoDto = _mapper.Map<AlunoDto>(aluno);
      return Ok(alunoDto);
    }

    [HttpPost]
    public IActionResult Post(AlunoRegistrarDto model)
    {
      var aluno = _mapper.Map<Aluno>(model);

      _repo.Add(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }

      return BadRequest("Aluno não cadastrado");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, AlunoRegistrarDto model)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }

      return BadRequest("Aluno não atualizado");
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, AlunoRegistrarDto model)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }

      return BadRequest("Aluno não atualizado");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado");

      _repo.Delete(aluno);
      if (_repo.SaveChanges())
      {
        return Ok("Aluno deletado");
      }

      return BadRequest("Aluno não deletado");
    }
  }
}