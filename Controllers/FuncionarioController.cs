using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;

namespace API_Folhas.Controllers
{
    [ApiController]
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly DataContext _context;

        public FuncionarioController(DataContext context) =>
            _context = context;

        private static List<Funcionario> funcionarios = new List<Funcionario>();

        [Route("listar")]
        [HttpGet]
        public IActionResult Listar() =>
            Ok(_context.Funcionarios.ToList());

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return Created("", funcionario);
        }

        [Route("buscar/{cpf}")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string cpf)
        {

            Funcionario funcionario =
                _context.Funcionarios.FirstOrDefault
            (
                f => f.Cpf.Equals(cpf)
            );
            if (funcionario != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            Funcionario funcionario =
                _context.Funcionarios.Find(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                _context.SaveChanges();
                return Ok(funcionario);
            }
            return NotFound();
        }

        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }
    }
}