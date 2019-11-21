using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorClassAPI.Models.Interfaces
{
    public interface IServicoBase<Classe>
        where Classe : class
    {
        void Adicionar(Classe obj);
        void Atualizar(Classe obj);
        void Excluir(int id);
        Classe ObterPorCodigo(int id);
        List<Classe> ObterTodos(int id);
    }
}
