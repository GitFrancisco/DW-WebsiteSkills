using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillPull.Models
{
    /// <summary>
    /// Tabela que representa a Subscricao
    /// </summary>
    public class Subscricao
    {
        [Key] // Primary Key - Subscricao
        public int Id { get; set; }
        public decimal Preco { get; set; }

        // *******************************************
        // Relações com outras tabelas - Foreign Keys
        [ForeignKey(nameof(Aluno))]
        public int AlunoFK { get; set; }
        public Aluno Aluno { get; set; }
        // *******************************************
    }
}
