using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;
using System.Collections.Generic;

namespace Gerenciador.Controllers
{
    public class BlockchainController : Controller
    {
        private readonly IBlockchainServico _servico;
        public BlockchainController(IBlockchainServico servico)
        {
            _servico = servico;
        }

        // GET: Blockchain
        public IActionResult Listagem()
        {
            ViewData["Mensagem"] = "Todos os blocos da blockchain";

            IEnumerable<Bloco> cadeiaCompleta = _servico.ObterCadeiaCompleta();
            return View(cadeiaCompleta);
        }

        // GET: Blockchain/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            Bloco bloco = _servico.ObterBloco(id);
            return View(bloco);
        }

        // GET: Blockchain/CriarTransacoes
        public ActionResult CriarTransacoes()
        {
            return View();
        }

        // POST: Blockchain/CriarTransacoes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarTransacoes(IFormCollection collection)
        {
            try
            {
                _servico.SalvarTransacoes(null);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }
    }
}