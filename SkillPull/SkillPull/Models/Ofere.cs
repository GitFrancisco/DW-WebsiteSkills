using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkillPull.Models
{
    /// <summary>
    /// Tabela do "meio" entre Subscricao e Skills
    /// </summary>
    public class Ofere
    {
        // Tabela do "meio" entre Mentor e Skills

        // Chave Primária Composta
        [Key, Column(Order = 1)]
        // Foreign Key - Tabela "Skills"
        [ForeignKey(nameof(Skills))]
        public int SkillsFK { get; set; }
        public Skills Skills { get; set; }

        // Chave Primária Composta
        [Key, Column(Order = 2)]
        // Foreign Key - Tabela "Mentor"
        [ForeignKey(nameof(Subscricao))]
        public int SubscricaoFK { get; set; }
        public Subscricao Subscricao { get; set; }
    }
}
