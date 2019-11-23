using GestorClass.Dominio;
using GestorClassAPI.Models.DTO;
using GestorClassAPI.Models.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GestorClassAPI.Models.Implementacoes
{
    public class ServicoAluno : IServicoAluno
    {
        private ServidorProjetoGestorEntities lContext;

        public ServicoAluno(ServidorProjetoGestorEntities pContext)
        {
            lContext = pContext;
        }

        public async Task<DTOAluno> Adicionar(DTOAluno pAluno)
        {
            Aluno lALU = new Aluno()
            {
                Nome = pAluno.Nome,
                Email = pAluno.Email,
                Data_Nascimento = pAluno.Data_Nascimento
            };

            lContext.Alunoes.Add(lALU);
            await lContext.SaveChangesAsync();

            pAluno.Id = lALU.Id;

            return pAluno;
        }

        public async Task<DTOAluno> Atualizar(DTOAluno pAluno)
        {
            Aluno lALU = lContext.Alunoes.FirstOrDefault(p => p.Id == pAluno.Id);

            lALU.Nome = pAluno.Nome;
            lALU.Email = pAluno.Email;
            lALU.Data_Nascimento = pAluno.Data_Nascimento;

            await lContext.SaveChangesAsync();

            return pAluno;
        }

        public async Task Excluir(int Id)
        {
            Aluno lALU = lContext.Alunoes.FirstOrDefault(p => p.Id == Id);

            lContext.Alunoes.Remove(lALU);
            await lContext.SaveChangesAsync();
        }

        public async Task<DTOAluno> ObterPorCodigo(int Id)
        {
            return await (from ALU in lContext.Alunoes
                          where ALU.Id == Id
                          select new DTOAluno
                          {
                              Id = ALU.Id,
                              Nome = ALU.Nome,
                              Email = ALU.Email,
                              Data_Nascimento = ALU.Data_Nascimento
                          }).FirstOrDefaultAsync();

        }

        public async Task<List<DTOAluno>> ObterTodos()
        {
            return await lContext.Alunoes
                .Select(p => new DTOAluno
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Email = p.Email,
                    Data_Nascimento = p.Data_Nascimento
                }).ToListAsync();
        }
    }
}