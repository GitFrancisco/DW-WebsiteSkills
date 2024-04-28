using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillPull.Data;
using SkillPull.Models;

namespace SkillPull.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        public ApplicationDbContext _context;

        public SkillController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var listaDb = _context.Skills.ToList();
            var listaRes = new List<SkillsDTO>();

            foreach (var skill in listaDb)
            {
                SkillsDTO skilldto = new SkillsDTO();
                skilldto.Descricao = skill.Descricao;
                skilldto.Nome = skill.Nome;
                skilldto.Tempo = skill.Tempo;
                skilldto.Dificuldade = skill.Dificuldade;


                listaRes.Add(skilldto);
            }

            return Ok(listaRes);
        }


        [HttpPost]
        [Route("insereSkill")]
        public ActionResult InsereSkill([FromBody] SkillsDTO dto)
        {
            Skills skill = new Skills();
            skill.Nome = dto.Nome;
            skill.Descricao = dto.Descricao;
            skill.Tempo = dto.Tempo;
            skill.Dificuldade = dto.Dificuldade;

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("editSkill")]
        public ActionResult EditSkill([FromBody] SkillsDTO dto, [FromQuery] int id)
        {
            Skills skill = _context.Skills.Where(c => c.SkillsId == id).FirstOrDefault();

            skill.Nome = dto.Nome;
            skill.Descricao = dto.Descricao;
            skill.Tempo = dto.Tempo;
            skill.Dificuldade = dto.Dificuldade;

            _context.Skills.Update(skill);
            _context.SaveChanges();


            return Ok();
        }


        [Route("ola")]
        public ActionResult Ola(string nome, string turma)
        {
            if (turma != "A" && turma != "B" && turma != "C")
                return BadRequest();


            return Ok("Olá" + nome + "da turma" + turma);
        }
    }

 
}
