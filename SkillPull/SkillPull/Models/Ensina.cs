using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillPull.Models
{
    // Chave Primária Composta
    [PrimaryKey(nameof(SkillsFK), nameof(MentorFK))]

    /// <summary>
    /// Tabela do "meio" entre Mentor e Skills
    /// </summary>
    public class Ensina
    {
        
        // Foreign Key - Tabela "Skills"
        [ForeignKey(nameof(Skills))]
        public int SkillsFK { get; set; }
        public Skills Skills { get; set; }

        // Foreign Key - Tabela "Mentor"
        [ForeignKey(nameof(Mentor))]
        public int MentorFK { get; set; }
        public Mentor Mentor { get; set; }
    }
}
