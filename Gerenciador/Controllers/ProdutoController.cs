using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(IProdutoServico produtoService)
        {
            _produtoServico = produtoService;
        }

        // GET: Produto
        public ActionResult Listagem()
        {
            var listagem = _produtoServico.ObterTodos();
            return View(listagem);
        }

        // GET: Produto/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            var produto = _produtoServico.ObterPorId(id);
            return View(produto);
        }

        // GET: Produto/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Produto/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Produto produto)
        {
            try
            {
                _produtoServico.Salvar(produto);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edicao/5
        public ActionResult Edicao(int id)
        {
            var produto = _produtoServico.ObterPorId(id);
            return View(produto);
        }

        // POST: Produto/Edicao/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edicao(int id, Produto produto)
        {
            try
            {
                _produtoServico.Salvar(produto);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Exclusao/5
        public ActionResult Exclusao(int id)
        {
            var produto = _produtoServico.ObterPorId(id);
            return View(produto);
        }

        // POST: Produto/Exclusao/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Exclusao(int id, Produto produto)
        {
            try
            {
                _produtoServico.Excluir(produto);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }
    }
}