using Microsoft.AspNetCore.Mvc;

namespace SmatSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() { }

        [HttpGet]
        public IActionResult Get() {
            return Ok("Professores: Joao, Marcos");
        }

    }
}