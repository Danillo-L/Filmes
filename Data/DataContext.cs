using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Data 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Filme> TB_FILMES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>().ToTable("TB_FILMES");

            modelBuilder.Entity<Filme>().HasData
            (
                new Filme() { Id = 1, Nome = "Interestelar", AnoLancamento = 2014 , Bilheteria = 774_000_000, Duracao = new TimeSpan(2, 49, 0), Classificacao=Models.Enuns.ClassificacaoEnum.MaiorDez, Genero=Models.Enuns.GeneroEnum.FiccaoCientifica },
                new Filme() { Id = 2, Nome = "Django Livre", AnoLancamento = 2013, Bilheteria = 426_074_373, Duracao = new TimeSpan(2, 45, 0), Classificacao=Models.Enuns.ClassificacaoEnum.MaiorDezesseis, Genero=Models.Enuns.GeneroEnum.Ação},
                new Filme() { Id = 3, Nome = "La La Land", AnoLancamento = 2016, Bilheteria = 340_600_000, Duracao = new TimeSpan(2, 8, 0), Classificacao=Models.Enuns.ClassificacaoEnum.Livre, Genero=Models.Enuns.GeneroEnum.Ação}           
            );
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }





















    }
}