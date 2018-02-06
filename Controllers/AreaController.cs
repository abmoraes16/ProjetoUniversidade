using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoUniversidade.Dados;
using ProjetoUniversidade.Models;

namespace ProjetoUniversidade.Controllers
{
    [Route("Area")]
    public class AreaController:Controller
    {
        readonly UniversidadeContexto contexto;

        public AreaController(UniversidadeContexto Contexto){
            this.contexto = Contexto;
        }

        [HttpGet]
        /// <summary>
        /// Listar Area
        /// </summary>
        /// <returns>Lista de Areas</returns>
        public IEnumerable<Area> ListarArea(){
            return contexto.Area.ToList();
        }

        [HttpGet("{id}")]
        public Area ListarArea(int id){
                return contexto.Area.Where(a=>a.IdArea==id).FirstOrDefault();
        } 

        [HttpPost]
        public IActionResult PostarArea([FromBody] Area area){
            
            try{
                //Realiza a validação dos campos do modelo Area (DataAnotations)
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                contexto.Area.Add(area);

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
        public IActionResult DeletarArea(int id){
            
            try{
                var area = contexto.Area.Where(a=>a.IdArea==id).FirstOrDefault();

                if(area==null){
                    return NotFound();
                }

                contexto.Area.Remove(area);

                int x = contexto.SaveChanges();

                if(x>0){
                    return Ok();
                }
            }
            catch(Exception ex){
                throw new Exception("Erro ao remover Area: "+ex.Message);
            }

            return BadRequest();
        }

        [HttpPut]    
        
        public IActionResult AtualizarArea([FromBody]Area area){

        try{
            if(!ModelState.IsValid){
                return BadRequest();
            }   

            contexto.Area.Update(area);

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