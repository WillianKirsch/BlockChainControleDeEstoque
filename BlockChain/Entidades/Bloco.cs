using BlockChain.Infraestrutura;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BlockChain.Entidades
{
    public class Bloco : Entidade
    {
        public Int64 Altura { get; set; }
        public Int64 Prova { get; set; }
        public string Chave { get; set; }
        public string ChaveBlocoAnterior { get; set; }
        public string ChaveBlocoSucessor { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Bits { get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; }

        public override string ToString()
        {
            return String.Format(
                "Número do bloco: {0} | Prova: {1} | Chave: {2} | Chave do bloco anterior: {3} | Quantidade de transações: {4} | Criado em: {5}",
                Id, Prova, Chave, ChaveBlocoAnterior, Transacoes.Count, CriadoEm.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }

    public static class BlocoExtensions
    {
        public static Bloco ObterParaChave(this Bloco bloco)
        {
            Bloco blocoParaChave = new Bloco
            {
                Altura = bloco.Altura,
                ChaveBlocoAnterior = bloco.ChaveBlocoAnterior,
                CriadoEm = bloco.CriadoEm,
                Transacoes = bloco.Transacoes
            };

            return blocoParaChave;
        }

        public static int ObterBits(this Bloco bloco)
        {
            Bloco blocoParaChave = bloco.ObterParaChave();
            string blocoEmTexto = JsonConvert.SerializeObject(blocoParaChave);
            return blocoEmTexto.Length;
        }

        public static string ObterChave(this Bloco bloco)
        {
            Bloco blocoParaChave = bloco.ObterParaChave();
            string blocoEmTexto = JsonConvert.SerializeObject(blocoParaChave);
            return Criptografia.ObterSha256(blocoEmTexto);
        }
    }
}
