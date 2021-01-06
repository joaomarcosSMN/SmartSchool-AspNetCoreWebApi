using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmatSchool.WebAPI.Models;

namespace SmatSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Joao",
                Sobrenome = "Marcos",
                Telefone = "4968498489"
            },
            new Aluno() {
                Id = 2,
                Nome = "Neymar",
                Sobrenome = "Jr",
                Telefone = "489498494"
            },
            new Aluno() {
                Id = 3,
                Nome = "Zinedine",
                Sobrenome = "Zidane",
                Telefone = "119188118"
            },
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get() {
            return Ok("Alunos: Joao, Marcos");
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id) {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno) {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno) {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno) {
            return Ok(aluno);
        }
        
        [HttpPut("{id}")]
        public IActionResult Delete(int id) {
            return Ok();
        }
    }
}