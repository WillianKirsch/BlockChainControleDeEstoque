using System.Collections.Generic;

namespace BlockChain.Entidades.Interfaces
{
    public interface IProdutoServico
    {
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        int Excluir(Produto produto);
        int Salvar(Produto produto);
    }
}
