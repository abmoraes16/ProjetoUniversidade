using Microsoft.EntityFrameworkCore;
using ProjetoUniversidade.Models;

namespace ProjetoUniversidade.Dados
{
    public class UniversidadeContexto:DbContext
    {
        public UniversidadeContexto(DbContextOptions<UniversidadeContexto>options):base(options){}

        public DbSet<Area> Area { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder){
            ModelBuilder.Entity<Area>().ToTable("Area");
            ModelBuilder.Entity<Curso>().ToTable("Curso");
            ModelBuilder.Entity<Turma>().ToTable("Turma");
        }
    }
}