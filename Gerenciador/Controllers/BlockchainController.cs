using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Bloco> cadeiaCompleta = _servico.ObterCadeiaCompleta();
            return View(cadeiaCompleta);
        }

        // GET: Blockchain/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            Bloco bloco = _servico.ObterBloco(id);
            return View(bloco);
        }

        // GET: Blockchain/CriarBloco
        public ActionResult CriarBloco()
        {
            return View();
        }

        // POST: Blockchain/CriarBloco
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarBloco(Bloco bloco)
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

        public ActionResult Consenso()
        {
            TempData["MensagemInfo"] = _servico.Consenso();
            return RedirectToAction(nameof(Listagem));
        }

        public ActionResult ValidarCadeia()
        {
            TempData["MensagemInfo"] = _servico.ValidarCadeia();
            return RedirectToAction(nameof(Listagem));
        }

        public ActionResult RevalidarBloco(int id)
        {
            TempData["MensagemInfo"] = _servico.RevalidarBloco(id);
            return RedirectToAction(nameof(Listagem));
        }
    }
}