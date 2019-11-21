using GestorClass.Dominio;
using GestorClassAPI.Models.DTO;
using GestorClassAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorClassAPI.Models.Entities
{
    public class ServicoAluno : IServicoAluno
    {
        private ServidorProjetoGestorEntities lContext;

        public ServicoAluno(ServidorProjetoGestorEntities pContext)
        {
            lContext = pContext;
        }

        public void Adicionar(DTOAluno pAluno)
        {
            Aluno lALU = new Aluno()
            {
                Nome = pAluno.Nome,
                Email = pAluno.Email,
                Data_Nascimento = pAluno.Data_Nascimento
            };

            lContext.Alunoes.Add(lALU);
            lContext.SaveChanges();
        }

        public void Atualizar(DTOAluno pAluno)
        {
            Aluno lALU = lContext.Alunoes.FirstOrDefault(p => p.Id == pAluno.Id);

            lALU.Nome = pAluno.Nome;
            lALU.Email = pAluno.Email;
            lALU.Data_Nascimento = pAluno.Data_Nascimento;

            lContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Aluno lALU = lContext.Alunoes.FirstOrDefault(p => p.Id == Id);

            lContext.Alunoes.Remove(lALU);
            lContext.SaveChanges();
        }

        public DTOAluno ObterPorCodigo(int Id)
        {
            DTOAluno lRetorno = (from ALU in lContext.Alunoes
                                 where ALU.Id == Id
                                 select new DTOAluno
                                 {
                                     Nome = ALU.Nome,
                                     Email = ALU.Email,
                                     Data_Nascimento = ALU.Data_Nascimento
                                 }).FirstOrDefault();

            return lRetorno;
        }

        public List<DTOAluno> ObterTodos()
        {
            List<DTOAluno> lRetorno = lContext.Alunoes
                .Select(p => new DTOAluno
                {
                    Nome = p.Nome,
                    Email = p.Email,
                    Data_Nascimento = p.Data_Nascimento
                }).ToList();

            return lRetorno;
        }
    }
}