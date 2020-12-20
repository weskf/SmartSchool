using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SmartSchool.WebAPI.Models;
using System.Linq;
using SmartSchool.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public SmartContext _context { get; }

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_context.Alunos);
        }
            
        [HttpGet("ById/{id}")]
        public IActionResult GetById (int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName (string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if(aluno == null) return BadRequest("Aluno não encontrado");
            
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        { 
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, Aluno aluno)
        { 
            var oAluno= _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(oAluno == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Aluno aluno)
        { 
            var oAluno= _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(oAluno == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        { 
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok("Aluno Removido");
        }
    }
}