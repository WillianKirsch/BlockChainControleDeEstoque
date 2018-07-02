using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using Servico.BancoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace Servico.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly BlockchainClientContexto _contexto;
        protected BlockchainClientContexto Contexto { get { return _contexto; } }

        public ProdutoServico(BlockchainClientContexto contexto)
        {
            _contexto = contexto;
        }

        public Produto ObterPorId(int id)
        {
            return Contexto.Produtos.FirstOrDefault(produto => produto.Id == id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return Contexto.Produtos;
        }

        public int Excluir(Produto produto)
        {
            Contexto.Produtos.Remove(produto);
            return Contexto.SaveChanges();
        }

        public int Salvar(Produto produto)
        {
            Produto produtoSalvo = produto.Id == 0 ? Incluir(produto) : Alterar(produto);
            return Contexto.SaveChanges();
        }

        private Produto Alterar(Produto produto)
        {
            Produto produtoSalvo = Contexto.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            produtoSalvo.Codigo = produto.Codigo;
            produtoSalvo.Descricao = produto.Descricao;

            return produtoSalvo;
        }

        private Produto Incluir(Produto produto)
        {
            Contexto.Produtos.Add(produto);
            return produto;
        }
    }
}
