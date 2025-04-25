using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using System.Collections.Generic;
using System.Linq;
namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListaPersonagemHabilidades(int id)
        {
            try{
                //Lista de personagem hablidade de acordo com o id do personagem
                List<PersonagemHabilidade> phLista = await _context.TB_PERSONAGENS_HABILIDADES.Where(ph => ph.PersonagemId == id).ToListAsync();
                return Ok(phLista);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        } 

        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidades(){
            try{
                //tá certo?
                List<Habilidade> habilidades = await _context.TB_HABILIDADES.ToListAsync();
                return Ok(habilidades);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade){
            try{
                Personagem personagem = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if(personagem == null)
                    throw new System.Exception("Personagem não enontrado para o Id Informado.");

                    Habilidade habilidade = await _context.TB_HABILIDADES
                                            .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if(habilidade == null)
                    throw new System.Exception("Habilidade não encontrada.");

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade =  habilidade;
                await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
                
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade personagemHabilidade){
            try{
                var personagem = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.Id == personagemHabilidade.PersonagemId);
                var habilidade = await _context.TB_HABILIDADES.FirstOrDefaultAsync(h => h.Id == personagemHabilidade.HabilidadeId);
                var ph = await _context.TB_PERSONAGENS_HABILIDADES.FirstOrDefaultAsync(ph => ph.PersonagemId == personagemHabilidade.PersonagemId && ph.HabilidadeId == personagemHabilidade.HabilidadeId);
                if(personagem == null){
                    throw new Exception("Personagem não encontrado.");
                }
                if(habilidade == null){
                    throw new Exception("Habilidade não encontrada.");
                }
                if(ph == null){
                    throw new Exception("A relação entre personagem e habilidade não foi encontrada");
                }
                 _context.TB_PERSONAGENS_HABILIDADES.Remove(ph);
                 await _context.SaveChangesAsync();
                return Ok("A relação entre personagem e habilidade foi excluída com sucesso!");
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }


        
    }

}