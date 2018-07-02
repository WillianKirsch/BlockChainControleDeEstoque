using BlockChain.Entidades.Respostas;
using System.Collections.Generic;

namespace BlockChain.Entidades.Interfaces
{
    public interface IBlockchainServico
    {
        BlocoMineradoResposta SalvarTransacoes(List<Transacao> transacoes);
        Bloco ObterBloco(int id);
        IEnumerable<Bloco> ObterCadeiaCompleta();
        string RegistrarDispositivoNos(string[] dispositivosNo);
        string Consenso();
        string ValidarCadeia();
        string RevalidarBloco(int id);
    }
}