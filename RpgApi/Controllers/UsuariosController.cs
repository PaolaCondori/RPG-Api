using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context){
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string username){
            if(await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == username.ToLower())){
                return true;
            }
            return false;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ListarUsuario(){
            try{
               List<Usuario> usuarios = await _context.TB_USUARIOS.ToListAsync() ;
                return Ok(usuarios);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user){
            try{
                if(await UsuarioExistente(user.Username)){
                    throw new System.Exception("Nome de ususário já existe");
                }

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais){
            try{
                    Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                    if(usuario == null){
                        throw new System.Exception("Usuário não encontrado.");
                    }
                    else if(!Criptografia.VerificarPasswordHash(usuario.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                    {
                        throw new System.Exception("Senha incorreta.");
                    }
                    else{
                        usuario.DataAcesso = DateTime.Now;
                         _context.TB_USUARIOS.Update(usuario);
                        await _context.SaveChangesAsync();
                        return Ok(usuario);
                    }
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha( Usuario credenciais)
        {
            try{
                //Verificar a existência do usuário
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if(usuario == null){
                    throw new System.Exception("Usuário não encontrado.");
                }else
                {
                    //Trocando de senha, gerando novo hash e salt
                    Criptografia.CriarPasswordHash(usuario.PasswordString, out byte[] hash, out byte[] salt);
                    usuario.PasswordString = string.Empty;
                    usuario.PasswordHash = hash;
                    usuario.PasswordSalt = salt;
                     _context.TB_USUARIOS.Update(usuario);
                    await _context.SaveChangesAsync();
                    return Ok("Senha alterada!");
                }
                
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}