using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public SmartContext _context { get; }

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_context.Professores);
        }   

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");
            
            return Ok(professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName (string nome)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));

            if(professor == null) return BadRequest("Professor não encontrado");
            
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post (Professor professor)
        { 
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, Professor professor)
        { 
            var oProfessor= _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(oProfessor == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Professor professor)
        { 
            var oProfessor= _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(oProfessor == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        { 
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok("Professor Removido");
        }
    }
}