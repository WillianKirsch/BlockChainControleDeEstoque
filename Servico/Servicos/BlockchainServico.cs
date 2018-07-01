using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using BlockChain.Entidades.Respostas;
using BlockChain.Infraestrutura;
using Newtonsoft.Json;
using Servico.BancoDeDados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Servico.Servicos
{
    public class BlockchainServico : IBlockchainServico
    {
        public string DispositivoNoId { get; private set; }

        private readonly BlockchainClientContexto _contexto;
        protected BlockchainClientContexto Contexto { get { return _contexto; } }
        private Bloco _ultimoBloco => Contexto.Blocos.LastOrDefault();

        public BlockchainServico(BlockchainClientContexto contexto)
        {
            _contexto = contexto;

            if (!Contexto.Blocos.Any())
                CriarNovoBloco();

            //TEMPORARIO
            DispositivoNoId = Guid.NewGuid().ToString().Replace("-", "");
        }

        #region MÉTODOS PÚBLICOS

        //Efetua a transação
        //PASSAR A TRANSAÇÃO DESERJADA POR PARAMETRO
        public BlocoMineradoResposta SalvarTransacoes(List<Transacao> transacoes)
        {
            transacoes = new List<Transacao>();
            transacoes.Add(CriarTransacao(destinatario: "0", remetente: DispositivoNoId, quantidade: 1));

            Bloco bloco = CriarNovoBloco(transacoes);

            var resposta = new BlocoMineradoResposta
            {
                Mensagem = "Novo bloco minerado",
                BlocoId = bloco.Id,
                Transacoes = bloco.Transacoes.ToList(),
                Prova = bloco.Prova,
                ChaveBlocoAnterior = bloco.ChaveBlocoAnterior
            };

            return resposta;
        }

        public Bloco ObterBloco(int id)
        {
            return Contexto.Blocos.FirstOrDefault(bloco => bloco.Id == id);
        }

        public IEnumerable<Bloco> ObterCadeiaCompleta()
        {
            return Contexto.Blocos.OrderBy(bloco => bloco.Altura);
        }

        public string RegistrarDispositivoNos(string[] dispositivosNo)
        {
            var sb = new StringBuilder();
            foreach (string dispositivoNo in dispositivosNo)
            {
                string url = $"http://{dispositivoNo}";
                RegistrarDispositivoNo(url);
                sb.Append($"{url}, ");
            }

            sb.Insert(0, $"{dispositivosNo.Count()} novos dispositivos foram adicionados: ");
            string resultado = sb.ToString();
            return resultado.Substring(0, resultado.Length - 2);
        }

        public ConsensoResposta Consenso()
        {
            bool alterado = ResolverConflitos();
            string mensagem = alterado ? "foi alterada" : "está autorizada";

            return new ConsensoResposta
            {
                Mensagem = $"Nossa cadeia {mensagem}",
                Cadeia = Contexto.Blocos.ToList()
            };
        }

        #endregion

        #region MÉTODOS PRIVADOS
        private Transacao CriarTransacao(string destinatario, string remetente, int quantidade)
        {
            var transacao = new Transacao
            {
                Destinatario = destinatario,
                Remetente = remetente,
                Quantidade = quantidade
            };

            return transacao;
        }

        private void RegistrarDispositivoNo(string endereco)
        {
            Contexto.Dispositivos.Add(new DispositivoNo { EnderecoUrl = endereco });
        }

        private bool CadeiaValida(List<Bloco> cadeia)
        {
            Bloco bloco = null;
            Bloco ultimoBloco = cadeia.First();
            int identificadorAtual = 1;
            while (identificadorAtual < cadeia.Count)
            {
                bloco = cadeia.ElementAt(identificadorAtual);

                //Verifica se a Chave do bloco está correta
                if (bloco.ChaveBlocoAnterior != ultimoBloco.ObterChave())
                    return false;

                //Verifica se a Prova está correta
                if (!ProvaValida(bloco.Chave, ultimoBloco.ChaveBlocoAnterior, bloco.Prova, ultimoBloco.Prova))
                    return false;

                ultimoBloco = bloco;
                identificadorAtual++;
            }

            return true;
        }

        private bool ResolverConflitos()
        {
            List<Bloco> novaCadeia = null;
            int tamanhoMaximo = Contexto.Blocos.Count();

            foreach (DispositivoNo dispositivoNo in Contexto.Dispositivos)
            {
                var url = new Uri(String.Concat(dispositivoNo.EnderecoUrl, "/cadeia"));
                var requisicao = (HttpWebRequest)WebRequest.Create(url);
                var resposta = (HttpWebResponse)requisicao.GetResponse();

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    var modelo = new
                    {
                        cadeia = new List<Bloco>(),
                        length = 0
                    };
                    string json = new StreamReader(resposta.GetResponseStream()).ReadToEnd();
                    var dados = JsonConvert.DeserializeAnonymousType(json, modelo);

                    if (dados.cadeia.Count > Contexto.Blocos.Count() && CadeiaValida(dados.cadeia))
                    {
                        tamanhoMaximo = dados.cadeia.Count;
                        novaCadeia = dados.cadeia;
                    }
                }
            }

            if (novaCadeia != null)
            {
                Contexto.Blocos.AddRange(novaCadeia);
                Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        private Bloco CriarNovoBloco(List<Transacao> transacoes = null)
        {
            string chaveBlocoAnterior = _ultimoBloco?.Chave;
            Int64 provaBlocoAnterior = _ultimoBloco != null ? _ultimoBloco.Prova : 1;

            Bloco bloco = new Bloco
            {
                Altura = Contexto.Blocos.Count() + 1,
                ChaveBlocoAnterior = chaveBlocoAnterior,
                CriadoEm = DateTime.UtcNow,
                Transacoes = transacoes
            };

            bloco.Chave = bloco.ObterChave();
            bloco.Prova = CriarProva(bloco.Chave, chaveBlocoAnterior, provaBlocoAnterior);
            bloco.Bits = bloco.ObterBits();

            AtualizarBlocoAnterior(bloco.Chave);

            Contexto.Blocos.Add(bloco);
            Contexto.SaveChanges();
            return bloco;
        }

        private void AtualizarBlocoAnterior(string chave)
        {
            if (_ultimoBloco != null)
                _ultimoBloco.ChaveBlocoSucessor = chave;
        }

        private int CriarProva(string chaveAtual, string chaveBlocoAnterior, Int64 ultimaProva)
        {
            int prova = 0;
            while (!ProvaValida(chaveAtual, chaveBlocoAnterior, prova, ultimaProva))
                prova++;

            return prova;
        }

        private bool ProvaValida(string chaveAtual, string chaveBlocoAnterior, Int64 prova, Int64 ultimaProva)
        {
            string hipotese = $"{chaveAtual}{chaveBlocoAnterior}{prova}{ultimaProva}";
            string resultado = Criptografia.ObterSha256(hipotese);
            return resultado.StartsWith("0000");
        }

        #endregion
    }
}
