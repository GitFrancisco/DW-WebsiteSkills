using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillPull.Models
{
    /// <summary>
    /// Classe que representa os Recursos de cada Skill
    /// </summary>
    public class Recurso
    {
        [Key] // Primary Key - Recurso
        public int IdRecurso { get; set; }

        public string NomeRecurso { get; set; }

        public string ConteudoRecurso { get; set; }

        public string TipoRecurso { get; set; }

        // *******************************************
        // Relações com outras tabelas - Foreign Keys

        [ForeignKey(nameof(Skill))]
        public int SkillsFK { get; set; }
        public Skills Skill { get; set; }

        // *******************************************

    }
}
