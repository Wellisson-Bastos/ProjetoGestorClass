using GestorClassAPI.Models.DTO;
using GestorClassAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace GestorClassAPI.Controllers
{
    public class MatriculaController : ApiController
    {
        private readonly IServicoMatricula fServico;

        public MatriculaController(IServicoMatricula pServico)
        {
            fServico = pServico;
        }

        [HttpGet]
        [ResponseType(typeof(List<DTOMatricula>))]
        [Route("api/matricula/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var lRetorno = fServico.ObterTodos(id); 

                return Ok(lRetorno);
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(DTOMatricula))]
        [Route("api/matricula/get_by_id/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var lRetorno = fServico.ObterPorCodigo(id);

                if (lRetorno != null)
                {
                    return Ok(lRetorno);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }

        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]DTOMatricula pDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                fServico.Adicionar(pDTO);

                return Ok();
            }
            catch (ApplicationException Ex)
            {
                return InternalServerError(Ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]DTOMatricula pDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                fServico.Atualizar(pDTO);

                return Ok();
            }
            catch (ApplicationException Ex)
            {
                return InternalServerError(Ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                fServico.Excluir(id);

                return Ok();
            }
            catch (ApplicationException Ex)
            {
                return InternalServerError(Ex);
            }
        }
    }
}
