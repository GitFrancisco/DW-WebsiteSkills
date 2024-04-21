using System.ComponentModel.DataAnnotations.Schema;

namespace SkillPull.Models
{
    /// <summary>
    ///  Disjunção de Utilizadores - Aluno
    /// </summary>
    public class Aluno : Utilizadores
    {
        public Aluno()
        {
            ListaSubscricoes = new HashSet<Subscricao>();
        }

        public int IdAluno { get; set; }
        public DateTime DataInscricao { get; set; }
        //*******************************************
        // Relações com outras tabelas - Foreign Key

        // Relacionamento 1-N com a tabela "Subscricao"
        public ICollection<Subscricao> ListaSubscricoes { get; set; }
        //*******************************************
    }
}
