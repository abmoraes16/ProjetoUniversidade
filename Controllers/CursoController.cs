using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoUniversidade.Dados;
using ProjetoUniversidade.Models;

namespace ProjetoUniversidade.Controllers
{
    [Route("Curso")]
    public class CursoController:Controller
    {
readonly UniversidadeContexto contexto;

        public CursoController(UniversidadeContexto Contexto){
            this.contexto = Contexto;
        }

        [HttpGet]
        /// <summary>
        /// Listar Curso
        /// </summary>
        /// <returns>Lista de Cursos</returns>
        public IEnumerable<Curso> ListarCurso(){
            return contexto.Curso.ToList();
        }

        [HttpGet("{id}")]
        public Curso ListarCurso(int id){
                return contexto.Curso.Where(a=>a.IdCurso==id).FirstOrDefault();
        } 

        [HttpPost]
        public IActionResult PostarCurso([FromBody] Curso Curso){
            
            try{
                //Realiza a validação dos campos do modelo Curso (DataAnotations)
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                contexto.Curso.Add(Curso);

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
        public IActionResult DeletarCurso(int id){
            
            try{
                var Curso = contexto.Curso.Where(a=>a.IdCurso==id).FirstOrDefault();

                if(Curso==null){
                    return NotFound();
                }

                contexto.Curso.Remove(Curso);

                int x = contexto.SaveChanges();

                if(x>0){
                    return Ok();
                }
            }
            catch(Exception ex){
                throw new Exception("Erro ao remover Curso: "+ex.Message);
            }

            return BadRequest();
        }

        [HttpPut]    
        
        public IActionResult AtualizarCurso([FromBody]Curso Curso){

        try{
            if(!ModelState.IsValid){
                return BadRequest();
            }   

            contexto.Curso.Update(Curso);

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