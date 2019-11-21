using GestorClass.Dominio;
using GestorClassAPI.Models.DTO;
using GestorClassAPI.Models.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GestorClassAPI.Models.Implementacoes
{
    public class ServicoMatricula : IServicoMatricula
    {
        private ServidorProjetoGestorEntities lContext;

        public ServicoMatricula(ServidorProjetoGestorEntities pContext)
        {
            lContext = pContext;
        }

        public async Task<DTOMatricula> Adicionar(DTOMatricula pMatricula)
        {
            Matricula lMAT = new Matricula()
            {
                Curso = pMatricula.Curso,
                Serie = pMatricula.Serie,
                Turma = pMatricula.Turma,
                Data_Inicial = pMatricula.Data_Inicial,
                Data_Final = pMatricula.Data_Final,
                Status = pMatricula.Status
            };

            lContext.Matriculas.Add(lMAT);
            await lContext.SaveChangesAsync();

            pMatricula.Id = lMAT.Id;

            return pMatricula;
        }

        public async Task<DTOMatricula> Atualizar(DTOMatricula pMatricula)
        {
            Matricula lMAT = lContext.Matriculas.FirstOrDefault(p => p.Id == pMatricula.Id);

            lMAT.Curso = pMatricula.Curso;
            lMAT.Serie = pMatricula.Serie;
            lMAT.Turma = pMatricula.Turma;
            lMAT.Data_Inicial = pMatricula.Data_Inicial;
            lMAT.Data_Final = pMatricula.Data_Final;
            lMAT.Status = pMatricula.Status;

           await lContext.SaveChangesAsync();

            return pMatricula;
        }

        public async Task Excluir(int Id)
        {
            Matricula lMAT = lContext.Matriculas.FirstOrDefault(p => p.Id == Id);

            lContext.Matriculas.Remove(lMAT);
            await lContext.SaveChangesAsync();
        }

        public async Task<DTOMatricula> ObterPorCodigo(int Id)
        {
            return await (from MAT in lContext.Matriculas
                    where MAT.Id == Id
                    select new DTOMatricula
                    {
                        Id = MAT.Id,
                        Curso = MAT.Curso,
                        Serie = MAT.Serie,
                        Turma = MAT.Turma,
                        Data_Inicial = MAT.Data_Inicial,
                        Data_Final = MAT.Data_Final,
                        Status = MAT.Status
                    }).FirstOrDefaultAsync();
        }

        public async Task<List<DTOMatricula>> ObterTodos(int id)
        {
            return await lContext.Matriculas
                .Select(p => new DTOMatricula
                {
                    Id = p.Id,
                    Curso = p.Curso,
                    Serie = p.Serie,
                    Turma = p.Turma,
                    Data_Inicial = p.Data_Inicial,
                    Data_Final = p.Data_Final,
                    Status = p.Status
                }).ToListAsync();
        }
    }
}