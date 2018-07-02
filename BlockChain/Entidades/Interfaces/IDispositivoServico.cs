using System.Collections.Generic;

namespace BlockChain.Entidades.Interfaces
{
    public interface IDispositivoServico
    {
        DispositivoNo ObterPorId(int id);
        IEnumerable<DispositivoNo> ObterTodos();
        int Excluir(DispositivoNo produto);
        int Salvar(DispositivoNo produto);
    }
}

