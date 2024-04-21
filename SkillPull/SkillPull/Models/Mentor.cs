using System.ComponentModel.DataAnnotations.Schema;

namespace SkillPull.Models
{
    public class Mentor : Utilizadores
    {
        public Mentor()
        {
            ListaEnsina = new HashSet<Ensina>();
        }

        public int NumMentor { get; set; }

        //*******************************************
        // Relações com outras tabelas - Foreign Keys

        [ForeignKey(nameof(Skills))]
        public int SkillsFK { get; set; }
        public Skills Skills { get; set; }

        public ICollection<Ensina> ListaEnsina { get; set; }
        //*******************************************   
    }
}

