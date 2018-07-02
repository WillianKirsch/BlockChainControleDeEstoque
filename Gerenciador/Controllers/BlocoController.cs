using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    public class BlocoController : Controller
    {
        private static List<Transacao> MockDb = new List<Transacao>
            {
                new Transacao { Destinatario = "Fred", Remetente="Than" },
                new Transacao { Destinatario = "Erin", Remetente="Saavedra" },
                new Transacao { Destinatario = "Abdul", Remetente = "Banas" }
            };

        private List<Transacao> _transacoes;
        private List<Transacao> Transacoes
        {
            get
            {
                if (_transacoes == null)
                    _transacoes = TempData["Transacoes"] as List<Transacao>;
                return _transacoes;
            }
            set
            {
                _transacoes = value;
                TempData["Transacoes"] = _transacoes;
            }
        }

        // GET: Transacoes
        public ActionResult CriarBloco()
        {
            if (Transacoes == null)
            {
                // TODO: load real data from database
                Transacoes = MockDb;
            }
            return View(Transacoes);
        }

        [HttpPost]
        public ActionResult CriarBloco(List<Transacao> transacoes, string command)
        {
            try
            {
                if (command == "Add Item")
                {
                    transacoes.Add(new Transacao { Destinatario = "BABABA", Remetente= "TTTT" });
                    Transacoes = transacoes;
                }
                else if (command == "Remove Selected")
                {
                    int pos = transacoes.Count();

                    Transacoes = transacoes;
                }
                else if (command == "Cancel/Refresh")
                {
                    // force reload of data from database
                    Transacoes = null;
                }
                else
                {
                    // update actual database
                    MockDb = transacoes;
                    // force reload of data from database
                    Transacoes = null;
                }
                return RedirectToAction("CriarBloco");
            }
            catch
            {
                return View();
            }
        }
    }
}