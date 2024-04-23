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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ensina>()
            .HasOne(e => e.Mentor)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict); // <--

            modelBuilder.Entity<Ofere>()
            .HasOne(e => e.Subscricao)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict); // <--

            modelBuilder.Entity<Ofere>()
            .HasOne(e => e.Skills)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict); // <--


            base.OnModelCreating(modelBuilder);
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
