using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SkillPull.Models
{

    // Chave Primária Composta
    [PrimaryKey(nameof(SkillsFK), nameof(SubscricaoFK))]

    /// <summary>
    /// Tabela do "meio" entre Subscricao e Skills
    /// </summary>
    public class Ofere
    {
        // Tabela do "meio" entre Mentor e Skills

        // Foreign Key - Tabela "Skills"
        [ForeignKey(nameof(Skills))]
        public int SkillsFK { get; set; }
        public Skills Skills { get; set; }

        // Foreign Key - Tabela "Mentor"
        [ForeignKey(nameof(Subscricao))]
        public int SubscricaoFK { get; set; }
        public Subscricao Subscricao { get; set; }
    }
}
