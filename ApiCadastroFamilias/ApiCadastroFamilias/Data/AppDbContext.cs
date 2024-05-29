using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroFamilias
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Defina seus DbSets aqui, garantindo que eles correspondam às tabelas do banco de dados existente
        public DbSet<Representantes>? Representantes { get; set; }
        public DbSet<Dependentes>? Dependentes { get; set; }
    }

    public class Representantes
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? CEP { get; set; }
        public DateTime DataNascimento { get; set; }
        public int QuantidadeDependentes { get; set; }
        public ICollection<Dependentes>? Dependentes { get; set; }
    }

    public class Dependentes
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int RepresentanteId { get; set; }
        public Representantes? Representante { get; set; }
    }
}
