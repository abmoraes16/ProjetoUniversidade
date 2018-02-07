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

        /// <summary>
        /// Retorna lista de áreas
        /// </summary>
        /// <returns>Lista de Areas</returns>
        /// <response code="200">Retorna uma lista de areas</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Area>),200)]
        [ProducesResponseType(typeof(string),400)]
        public IEnumerable<Area> ListarArea(){
            return contexto.Area.ToList();
        }

        /// <summary>
        /// Retorna área específica
        /// </summary>
        /// <param name="id">Area Id</param>
        /// <returns></returns>
        /// <response code="200">Retorna uma área específica</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Area),200)]
        [ProducesResponseType(typeof(string),400)]
        public IActionResult ListarArea(int id){
            try{
                return Ok(contexto.Area.Where(a=>a.IdArea==id).FirstOrDefault());
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        } 

        /// <summary>
        /// Cadastra uma nova área
        /// </summary>
        /// <param name="area">Nova área para registrar</param>
        /// <remarks>
        /// Modelo de dados que deve ser enviado para cadastrar a area request:
        /// 
        ///     POST /Area
        ///     {
        ///         "nome" : "nome da area"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna área cadastrada</response>
        /// <response code="400">Ocorreu um erro</response>
        [HttpPost]
        [ProducesResponseType(typeof(Area),200)]
        [ProducesResponseType(typeof(string),400)]
        public IActionResult PostarArea([FromBody] Area area){
            
            try{
                //Realiza a validação dos campos do modelo Area (DataAnotations)
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                contexto.Area.Add(area);

                int x = contexto.SaveChanges();

                if(x>0){
                    return Ok(area);
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

/// <summary>
/// Atualiza sua area
/// </summary>
/// <param name="area">Área que vai ser atualizada</param>
/// <returns>Retorna a área atualizada</returns>
/// <response code="200">Retorna a área atualizada</response>
/// <response code="400">Ocorreu um erro</response>
/// <response code="404">Área não encontrada</response>
        [HttpPut]    
        [ProducesResponseType(typeof(Area),200)]
        [ProducesResponseType(typeof(string),400)] 
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