using GestorClassAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorClassAPI.Models.Interfaces
{
    public interface IServicoMatricula : IServicoBase<DTOMatricula>
    {
        Task<List<DTOMatricula>> ObterTodos(int id);
    }
}