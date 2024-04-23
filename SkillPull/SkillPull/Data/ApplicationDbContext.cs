using Microsoft.EntityFrameworkCore;
using SkillPull.Models;

namespace SkillPull.Data
{
    /// <summary>
    /// Classe que cria e gere a base de dados
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // definir tabelas
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Ensina> Ensina { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<Ofere> Ofere { get; set; }
        public DbSet<Recurso> Recurso { get; set; }
        public DbSet<Subscricao> Subscricao { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }

    }
}
