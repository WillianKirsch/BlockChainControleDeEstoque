using System;
using System.Collections.Generic;

namespace BlockChain.Entidades.Respostas
{
    public class BlocoMineradoResposta
    {
        public string Mensagem { get; set; }
        public Int64 BlocoId { get; set; }
        public List<Transacao> Transacoes { get; set; }
        public Int64 Prova { get; set; }
        public string ChaveBlocoAnterior { get; set; }
    }
}
