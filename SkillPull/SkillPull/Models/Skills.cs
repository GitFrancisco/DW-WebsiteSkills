using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkillPull.Models
{
    /// <summary>
    /// Classe que representa as "Skills" existentes na aplicação
    /// </summary>
    public class Skills
    {
        public Skills()
        {
            ListaEnsina = new HashSet<Ensina>();
            ListaRecursos = new HashSet<Recurso>();
        }

        [Key] // Primary Key - Skills
        public int SkillsId { get; set; }

        public string Nome { get; set; }

        public string Dificuldade { get; set; }

        public int Tempo { get; set; }

        public string Descricao { get; set; }

        // *******************************************
        // Relações com outras tabelas - Foreign Keys

        // Relacionamento 1-N com a tabela "Ofere"
        [ForeignKey(nameof(Ofere))]
        public int OfereFK { get; set; }
        public Ofere Ofere { get; set; }

        // Relacionamento 1-N com a tabela "Recurso"
        public ICollection<Recurso> ListaRecursos { get; set; }

        // Relacionamento 1-N com a tabela "Ensina"
        public ICollection<Ensina> ListaEnsina { get; set; }
        // *******************************************
    }
}
    
