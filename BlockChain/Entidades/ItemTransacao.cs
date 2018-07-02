namespace BlockChain.Entidades
{
    public class ItemTransacao : Entidade
    {
        public int Quantidade { get; set; }
        public int TransacaoId { get; set; }
        public Transacao Transacao { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
