using System.ComponentModel.DataAnnotations;

namespace SkillPull.Models
{
    public class Utilizadores
    {
        [Key] // Chave primária - Utilizadores
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
