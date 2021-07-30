using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Cleitim",
                Sobrenome = "Oliveira",
                Telefone = "(61) 9 9999-9999"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Rogerim",
                Sobrenome = "Tortão",
                Telefone = "(61) 9 9999-9999"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Isadora",
                Sobrenome = "Pinto",
                Telefone = "(61) 9 9999-9999"
            },
            new Aluno()
            {
                Id = 4,
                Nome = "Isadora",
                Sobrenome = "Machado",
                Telefone = "(61) 9 9999-9999"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Roberto",
                Sobrenome = "Pinto",
                Telefone = "(61) 9 9999-9999"
            }
        };

        // GET: alunos
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Alunos);
        }

        // GET alunos/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(w => w.Id == id);

            if (aluno == null) return BadRequest("Nenhum aluno encontrado com esse ID");

            return Ok(aluno);
        }

        // GET alunos/GetByNome/Laura
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var aluno = Alunos
                .Where(w => w.Nome.Contains(nome))
                .Select(s => new
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Sobrenome = s.Sobrenome,
                    Telefone = s.Telefone
                })
                .ToList();

            if (aluno == null) return BadRequest("Nenhum aluno encontrado com esse nome");

            return Ok(aluno);
        }

        // GET alunos/GetBySobrenome/Oliveira
        [HttpGet("GetBySobrenome/{sobrenome}")]
        public IActionResult GetBySobrenome(string sobrenome)
        {
            var aluno = Alunos
                .Where(w => w.Sobrenome == sobrenome)
                .Select(s => new
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Sobrenome = s.Sobrenome,
                    Telefone = s.Telefone
                })
                .ToList();

            if (aluno == null) return BadRequest("Nenhum aluno encontrado com esse sobrenome");

            return Ok(aluno);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
