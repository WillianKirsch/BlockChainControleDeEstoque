namespace BlockChain.Entidades
{
    public class Transacao : Entidade
    {
        public int Quantidade { get; set; }
        public string Destinatario { get; set; }
        public string Remetente { get; set; }
    }
}
