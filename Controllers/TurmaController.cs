using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoUniversidade.Dados;
using ProjetoUniversidade.Models;

namespace ProjetoUniversidade.Controllers
{
    [Route("Turma")]
    public class TurmaController:Controller
    {
        readonly UniversidadeContexto contexto;

        public TurmaController(UniversidadeContexto Contexto){
            this.contexto = Contexto;
        }

        [HttpGet]
        /// <summary>
        /// Listar Turma
        /// </summary>
        /// <returns>Lista de Turmas</returns>
        public IEnumerable<Turma> ListarTurma(){
            return contexto.Turma.ToList();
        }

        [HttpGet("{id}")]
        public Turma ListarTurma(int id){
                return contexto.Turma.Where(a=>a.IdTurma==id).FirstOrDefault();
        } 

        [HttpPost]
        public IActionResult PostarTurma([FromBody] Turma Turma){
            
            try{
                //Realiza a validação dos campos do modelo Turma (DataAnotations)
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                contexto.Turma.Add(Turma);

                int x = contexto.SaveChanges();

                if(x>0){
                    return Ok();
                }
                
            }
            catch(Exception ex){
                throw new Exception("Erro ao cadastrar: "+ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTurma(int id){
            
            try{
                var Turma = contexto.Turma.Where(a=>a.IdTurma==id).FirstOrDefault();

                if(Turma==null){
                    return NotFound();
                }

                contexto.Turma.Remove(Turma);

                int x = contexto.SaveChanges();

                if(x>0){
                    return Ok();
                }
            }
            catch(Exception ex){
                throw new Exception("Erro ao remover Turma: "+ex.Message);
            }

            return BadRequest();
        }

        [HttpPut]    
        
        public IActionResult AtualizarTurma([FromBody]Turma Turma){

        try{
            if(!ModelState.IsValid){
                return BadRequest();
            }   

            contexto.Turma.Update(Turma);

            int x = contexto.SaveChanges();

            if(x>0){
                return Ok();
            }
        }
        catch(Exception ex){
            throw new Exception(ex.Message);
        }

        return BadRequest();

        }
    }
}