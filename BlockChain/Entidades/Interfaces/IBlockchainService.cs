using BlockChain.Entidades.Respostas;
using System.Collections.Generic;

namespace BlockChain.Entidades.Interfaces
{
    public interface IBlockchainService
    {
        BlocoMineradoResposta SalvarTransacoes(List<Transacao> transacoes);
        Bloco ObterBloco(int id);
        IEnumerable<Bloco> ObterCadeiaCompleta();
        string RegistrarDispositivoNos(string[] dispositivosNo);
        ConsensoResposta Consenso();
    }
}