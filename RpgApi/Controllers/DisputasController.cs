using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RpgApi.Data;
using RpgApi.Models;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
       private readonly DataContext _context;

       public DisputasController(DataContext context){
            _context = context;
       }

       [HttpPost("Arma")]
       public async Task<IActionResult> AtaqueComArmaAsync(Disputa d){
            try{
                Personagem? atacante = await _context.TB_PERSONAGENS
                .Include(p => p.Arma)
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem? oponente = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                int dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));
                dano = dano - new Random().Next(oponente.Defesa);
                
                if(dano > 0){
                    oponente.PontosVida = oponente.PontosVida - (int)dano;
                }

                if(oponente.PontosVida <= 0){
                    d.Narracao = $"{oponente.Nome} foi derrotado!";
                }
                
                _context.TB_PERSONAGENS.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat(" Atacante: {0}. ", atacante.Nome);
                dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                dados.AppendFormat(" Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                dados.AppendFormat(" Pontos de vida do oponente: {0}. ", oponente.PontosVida);
                dados.AppendFormat(" Arma utilizada: {0}. ", atacante.Arma.Nome);
                dados.AppendFormat(" Dano: {0}. ", dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.TB_DISPUTAS.Add(d);
                _context.SaveChanges();

                return Ok(d);
            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
       }

       [HttpPost("Habilidade")]

       public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d){
            try{
                Personagem atacante = await _context.TB_PERSONAGENS
                .Include(p => p.PersonagemHabilidades)
                .ThenInclude(ph => ph.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem oponente = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                PersonagemHabilidade ph = await _context.TB_PERSONAGENS_HABILIDADES
                .Include(p => p.Habilidade)
                .FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId 
                && phBusca.PersonagemId == d.AtacanteId);

                if(ph == null){
                    d.Narracao = $"{atacante.Nome} não possui essa habilidade";
                }else{
                    int dano = ph.Habilidade.Dano + (new Random().Next(atacante.Inteligencia));
                    dano = dano - new Random().Next(oponente.Defesa);

                    if(dano > 0){
                        oponente.PontosVida = oponente.PontosVida - dano;
                    }

                    if(oponente.PontosVida <= 0){
                        d.Narracao += $"{oponente.Nome} foi derrotado!";
                    }

                    _context.SaveChangesAsync();

                    StringBuilder dados = new StringBuilder();
                    dados.AppendFormat(" Atacante: {0}. ", atacante.Nome);
                    dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                    dados.AppendFormat(" Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                    dados.AppendFormat(" Pontos de vida do oponente: {0}. ", oponente.PontosVida);
                    dados.AppendFormat(" Habilidade utilizada: {0}. ", ph.Habilidade.Nome);
                    dados.AppendFormat(" Dano: {0}. ", dano);

                    d.Narracao += dados.ToString();
                    d.DataDisputa = DateTime.Now;
                    _context.TB_DISPUTAS.Add(d);
                    _context.SaveChanges();
                }

                return Ok(d);
            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
       }

       [HttpGet("PersonagemRandom")]

       public async Task<IActionResult> Sorteio(){
            List<Personagem> personagens = await _context.TB_PERSONAGENS.ToListAsync();

            int sorteio = new Random().Next(personagens.Count);

            Personagem p = personagens[sorteio];

            string msg =
                string.Format("Nº Sorteado {0}. Personagem: {1}", sorteio, p.Nome);

            return Ok(msg);
       }

       [HttpDelete("ApagarDisputas")] 
        public async Task<IActionResult> DeleteAsync() 
        { 
            try 
            { 
                List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync(); 
 
                _context.TB_DISPUTAS.RemoveRange(disputas); 
                await _context.SaveChangesAsync(); 
 
                return Ok("Disputas apagadas"); 
            } 
            catch (System.Exception ex) 
            {return BadRequest(ex.Message); } 
            
        }

        [HttpGet("Listar")] 
        public async Task<IActionResult> ListarAsync() 
        { 
            try 
            { 
                List<Disputa> disputas = 
                   await _context.TB_DISPUTAS.ToListAsync();                 
 
                return Ok(disputas); 
            } 
            catch (System.Exception ex) 
            { 
                return BadRequest(ex.Message); 
            } 
        } 
       
    }
}