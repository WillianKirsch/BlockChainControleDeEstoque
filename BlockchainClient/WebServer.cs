using BlockChain.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BlockcadeiaClient
{
    public class WebServer
    {
        public WebServer(CadeiaDeBloco cadeia)
        {
            var configuracoes = ConfigurationManager.AppSettings;
            string host = configuracoes["host"]?.Length > 1 ? configuracoes["host"] : "localhost";
            string port = configuracoes["port"]?.Length > 1 ? configuracoes["port"] : "12345";

            var server = new TinyWebServer.WebServer(request =>
            {
                string path = request.Url.PathAndQuery.ToLower();
                string query = "";
                string json = "";
                if (path.Contains("?"))
                {
                    string[] parts = path.Split('?');
                    path = parts[0];
                    query = parts[1];
                }

                switch (path)
                {
                    //GET: http://localhost:12345/mine
                    case "/mine":
                        return cadeia.Mine();

                    //POST: http://localhost:12345/transactions/new
                    //{ "Amount":123, "Recipient":"ebeabf5cc1d54abdbca5a8fe9493b479", "Sender":"31de2e0ef1cb4937830fcfd5d2b3b24f" }
                    case "/transactions/new":
                        if (request.HttpMethod != HttpMethod.Post.Method)
                            return $"{new HttpResponseMessage(HttpStatusCode.MethodNotAllowed)}";

                        json = new StreamReader(request.InputStream).ReadToEnd();
                        Transaction trx = JsonConvert.DeserializeObject<Transaction>(json);
                        int blockId = cadeia.CreateTransaction(trx.Sender, trx.Recipient, trx.Amount);
                        return $"Your transaction will be included in block {blockId}";

                    //GET: http://localhost:12345/cadeia
                    case "/cadeia":
                        return cadeia.GetFullChain();

                    //POST: http://localhost:12345/nodes/register
                    //{ "Urls": ["localhost:54321", "localhost:54345", "localhost:12321"] }
                    case "/nodes/register":
                        if (request.HttpMethod != HttpMethod.Post.Method)
                            return $"{new HttpResponseMessage(HttpStatusCode.MethodNotAllowed)}";

                        json = new StreamReader(request.InputStream).ReadToEnd();
                        var urlList = new { Urls = new string[0] };
                        var obj = JsonConvert.DeserializeAnonymousType(json, urlList);
                        return cadeia.RegisterNodes(obj.Urls);

                    //GET: http://localhost:12345/nodes/resolve
                    case "/nodes/resolve":
                        return cadeia.Consensus();
                }

                return "";
            },
                $"http://{host}:{port}/mine/",
                $"http://{host}:{port}/transactions/new/",
                $"http://{host}:{port}/cadeia/",
                $"http://{host}:{port}/nodes/register/",
                $"http://{host}:{port}/nodes/resolve/"
            );

            server.Run();
        }
    }
}
