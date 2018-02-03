using System;
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

        [HttpPost]
        public IActionResult PostarCurso(Curso Curso){
            
            try{
                if(!ModelState.IsValid){
                    return BadRequest();
                }

                contexto.Curso.Add(Curso);
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