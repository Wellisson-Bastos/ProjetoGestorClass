using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorClassAPI.Models.Interfaces
{
    public interface IServicoBase<Classe>
        where Classe : class
    {
        Task<Classe> Adicionar(Classe obj);
        Task<Classe> Atualizar(Classe obj);
        Task Excluir(int id);
        Task<Classe> ObterPorCodigo(int id);
    }
}
