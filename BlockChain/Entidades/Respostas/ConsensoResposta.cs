using System;
using System.Collections.Generic;

namespace BlockChain.Entidades.Respostas
{
    public class ConsensoResposta
    {
        public string Mensagem { get; set; }
        public List<Bloco> Cadeia { get; set; }
    }
}
