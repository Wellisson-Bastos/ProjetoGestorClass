using GestorClassAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorClassAPI.Models.Interfaces
{
    public interface IServicoAluno : IServicoBase<DTOAluno>
    {
        Task<List<DTOAluno>> ObterTodos();
    }
}