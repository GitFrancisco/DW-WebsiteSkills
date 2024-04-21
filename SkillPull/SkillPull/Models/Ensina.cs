using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillPull.Models
{
    /// <summary>
    /// Tabela do "meio" entre Mentor e Skills
    /// </summary>
    public class Ensina
    {
        

        // Chave Primária Composta
        [Key, Column(Order = 1)]
        // Foreign Key - Tabela "Skills"
        [ForeignKey(nameof(Skills))]
        public int SkillsFK { get; set; }
        public Skills Skills { get; set; }

        // Chave Primária Composta
        [Key, Column(Order = 2)]
        // Foreign Key - Tabela "Mentor"
        [ForeignKey(nameof(Mentor))]
        public int MentorFK { get; set; }
        public Mentor Mentor { get; set; }
    }
}
