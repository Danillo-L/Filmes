using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Models;
using Filmes.Models.Enuns;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>()
        {
            new Filme() { Id = 1, Nome = "Interestelar", AnoLancamento = 2014 , Bilheteria = 774_000_000, Duracao = new TimeSpan(2, 49, 0), Classificacao=Models.Enuns.ClassificacaoEnum.MaiorDez, Genero=Models.Enuns.GeneroEnum.FiccaoCientifica },
            new Filme() { Id = 2, Nome = "Django Livre", AnoLancamento = 2013, Bilheteria = 426_074_373, Duracao = new TimeSpan(2, 45, 0), Classificacao=Models.Enuns.ClassificacaoEnum.MaiorDezesseis, Genero=Models.Enuns.GeneroEnum.Ação},
            new Filme() { Id = 3, Nome = "La La Land", AnoLancamento = 2016, Bilheteria = 340_600_000, Duracao = new TimeSpan(2, 8, 0), Classificacao=Models.Enuns.ClassificacaoEnum.Livre, Genero=Models.Enuns.GeneroEnum.Ação}           

        };

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(filmes);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(filmes.FirstOrDefault(fi => fi.Id == id));
        }
    
        [HttpPost("AddFilme")]
        public IActionResult AddFilme(Filme filme)
        {
            filmes.Add(filme);
            return Ok(filmes);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            filmes.RemoveAll(fi => fi.Id == id);
            return Ok(filmes);
        }

    
    
    
    
    
    
    
    
    }
}