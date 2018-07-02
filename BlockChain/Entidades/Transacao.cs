using System.Collections.Generic;

namespace BlockChain.Entidades
{
    public class Transacao : Entidade
    {
        public string Destinatario { get; set; }
        public string Remetente { get; set; }
        public int BlocoId { get; set; }
        public virtual Bloco Bloco { get; set; }

        public virtual ICollection<ItemTransacao> Transacoes { get; set; }
    }
}
