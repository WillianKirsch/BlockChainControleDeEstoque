using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Infraestrutura
{
    public static class Criptografia
    {
        public static string ObterSha256(string dados)
        {
            var sha256 = new SHA256Managed();
            var construtorDeChave = new StringBuilder();

            byte[] bytes = Encoding.Unicode.GetBytes(dados);
            byte[] chave = sha256.ComputeHash(bytes);

            foreach (byte x in chave)
                construtorDeChave.Append($"{x:x2}");

            return construtorDeChave.ToString();
        }
    }
}
