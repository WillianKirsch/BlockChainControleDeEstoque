using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using Servico.BancoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace Servico.Servicos
{
    public class DispositivoServico : IDispositivoServico
    {
        private readonly BlockchainClientContexto _contexto;
        protected BlockchainClientContexto Contexto { get { return _contexto; } }

        public DispositivoServico(BlockchainClientContexto contexto)
        {
            _contexto = contexto;
        }

        public DispositivoNo ObterPorId(int id)
        {
            return Contexto.Dispositivos.FirstOrDefault(dispositivo => dispositivo.Id == id);
        }

        public IEnumerable<DispositivoNo> ObterTodos()
        {
            return Contexto.Dispositivos;
        }

        public int Excluir(DispositivoNo dispositivo)
        {
            Contexto.Dispositivos.Remove(dispositivo);
            return Contexto.SaveChanges();
        }

        public int Salvar(DispositivoNo dispositivo)
        {
            DispositivoNo dispositivoSalvo = dispositivo.Id == 0 ? Incluir(dispositivo) : Alterar(dispositivo);
            return Contexto.SaveChanges();
        }

        private DispositivoNo Alterar(DispositivoNo dispositivo)
        {
            DispositivoNo dispositivoSalvo = Contexto.Dispositivos.FirstOrDefault(p => p.Id == dispositivo.Id);
            
            dispositivoSalvo.EnderecoUrl = dispositivo.EnderecoUrl;

            return dispositivoSalvo;
        }

        private DispositivoNo Incluir(DispositivoNo dispositivo)
        {
            Contexto.Dispositivos.Add(dispositivo);
            return dispositivo;
        }
    }
}
