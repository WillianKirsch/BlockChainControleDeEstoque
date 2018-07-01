using BlockChain.Entidades;
using BlockChain.Entidades.Respostas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.Servicos
{
    public interface IBlockchainServico
    {
        BlocoMineradoResposta SalvarTransacoes(List<Transacao> transacoes);
        Bloco ObterBloco(int id);
        IEnumerable<Bloco> ObterCadeiaCompleta();
        string RegistrarDispositivoNos(string[] dispositivosNo);
        ConsensoResposta Consenso();
    }
}
