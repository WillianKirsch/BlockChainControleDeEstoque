using BlockChain.Entidades;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlockchainClient
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            //var cadeia = new CadeiaDeBloco();
            //var server = new WebServer(cadeia);
            System.Console.Read();
        }
    }
}
