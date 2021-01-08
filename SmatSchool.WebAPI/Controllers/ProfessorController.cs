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
  [Route("api/[controller]")]
  public class ProfessorController : ControllerBase
  {
    public readonly IRepository _repo;
    public readonly IMapper _mapper;
    public ProfessorController(IRepository repo,
                               IMapper mapper) 
    { 
        _mapper = mapper;
        _repo = repo;
    }

  [HttpGet]
  public IActionResult Get()
  {
    var profs = _repo.GetAllProfessores(true);
    return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(profs));
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var prof = _repo.GetProfessorById(id, false);
    if (prof == null) return BadRequest("Professor não encontrado");

    var profDto = _mapper.Map<ProfessorDto>(prof);
    return Ok(profDto);
  }

  [HttpPost]
  public IActionResult Post(ProfessorDto model)
  {
    var prof = _mapper.Map<Professor>(model);

    _repo.Add(prof);
    if (_repo.SaveChanges())
    {
      return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
    }

    return BadRequest("Professor não cadastrado");
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, ProfessorDto model)
  {
    var prof = _repo.GetProfessorById(id);
    if (prof == null) return BadRequest("Professor não encontrado");

    _mapper.Map(model, prof);

    _repo.Update(prof);
    if (_repo.SaveChanges())
    {
        return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
    }

    return BadRequest("Professor não atualizado");
  }

  [HttpPatch("{id}")]
  public IActionResult Patch(int id, ProfessorDto model)
  {
    var prof = _repo.GetProfessorById(id);
    if (prof == null) return BadRequest("Professor não encontrado");

    _mapper.Map(model, prof);

    _repo.Update(prof);
    if (_repo.SaveChanges())
    {
        return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
    }

    return BadRequest("Professor não atualizado");
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var professor = _repo.GetProfessorById(id);
    if (professor == null) return BadRequest("Professor não encontrado");

    _repo.Delete(professor);
    if (_repo.SaveChanges())
    {
      return Ok("Professor deletado");
    }

    return BadRequest("Professor não deletado");
  }
}
}
