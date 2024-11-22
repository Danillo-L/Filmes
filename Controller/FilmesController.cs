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
    /// <summary>
    /// Controlador para gerenciar filmes na API.
    /// </summary>
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

        /// <summary>
        /// Retorna todos os filmes disponíveis na API.
        /// </summary>
        /// <returns>Uma lista de filmes.</returns>
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(filmes);
        }

        /// <summary>
        /// Retorna um filme específico pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do filme que será retornado.</param>
        /// <returns>O filme com o ID especificado.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var filme = filmes.FirstOrDefault(fi => fi.Id == id);
            if (filme == null)
            {
                return NotFound("Filme não encontrado.");
            }
            return Ok(filme);
        }

        /// <summary>
        /// Adiciona um novo filme à lista.
        /// </summary>
        /// <param name="filme">O objeto do filme a ser adicionado.</param>
        /// <returns>Uma resposta contendo a lista de filmes atualizada.</returns>
        [HttpPost("AddFilme")]
        public IActionResult AddFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);
            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Remove um filme da lista pelo ID.
        /// </summary>
        /// <param name="id">O ID do filme a ser removido.</param>
        /// <returns>Uma resposta com a lista de filmes atualizada.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filmeToRemove = filmes.FirstOrDefault(fi => fi.Id == id);
            if (filmeToRemove == null)
            {
                return NotFound("Filme não encontrado.");
            }
            filmes.Remove(filmeToRemove);
            return Ok(filmes);
        }
    }
}
