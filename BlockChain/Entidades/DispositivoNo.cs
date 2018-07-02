using System;

namespace BlockChain.Entidades
{
    public class DispositivoNo : Entidade
    {
        public string EnderecoUrl { get; set; }
        public bool Inacessivel { get; set; }
        public string Erro { get; set; }
    }
}
