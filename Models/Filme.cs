using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Models.Enuns;

namespace Filmes.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int AnoLancamento { get; set; }
        public decimal Bilheteria { get; set; }
        public TimeSpan Duracao { get; set; }
        public ClassificacaoEnum Classificacao { get; set; } 
        public GeneroEnum Genero { get; set; }

    }
}