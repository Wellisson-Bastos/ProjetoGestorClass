using GestorClassAPI.Models.DTO;
using GestorClassAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GestorClassAPI.Controllers
{
    public class AlunoController : ApiController
    {
        private readonly IServicoAluno fServico;

        public AlunoController(IServicoAluno pServico)
        {
            fServico = pServico;
        }

        [HttpGet]
        [ResponseType(typeof(List<DTOAluno>))]
        [Route("api/aluno/obtertodos")]
        public async Task<IHttpActionResult> ObterTodos(int id)
        {
            try
            {
                return Ok(await fServico.ObterTodos());
            }
            catch (Exception Ex)
            {
                return InternalServerError(Ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(DTOAluno))]
        [Route("api/aluno/{id}")]
        public async Task<IHttpActionResult> ObterPorCodigo(int id)
        {
            try
            {
                var lRetorno = await fServico.ObterPorCodigo(id);

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
        [ResponseType(typeof(DTOAluno))]
        public async Task<IHttpActionResult> Adicionar([FromBody]DTOAluno pDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await fServico.Adicionar(pDTO));
            }
            catch (ApplicationException Ex)
            {
                return InternalServerError(Ex);
            }
        }

        [HttpPut]
        [ResponseType(typeof(DTOAluno))]
        public async Task<IHttpActionResult> Atualizar([FromBody]DTOAluno pDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await fServico.Atualizar(pDTO));
            }
            catch (ApplicationException Ex)
            {
                return InternalServerError(Ex);
            }
        }

        [HttpDelete]
        [Route("api/aluno/{id}")]
        public async Task<IHttpActionResult> Excluir(int id)
        {
            try
            {
                await fServico.Excluir(id);

                return Ok();
            }
            catch (ApplicationException Ex)
            {
                return InternalServerError(Ex);
            }
        }
    }
}
