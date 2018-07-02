using BlockChain.Entidades;
using BlockChain.Entidades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    public class DispositivoController : Controller
    {
        private readonly IDispositivoServico _dispositivoServico;
        public DispositivoController(IDispositivoServico dispositivoService)
        {
            _dispositivoServico = dispositivoService;
        }

        // GET: Dispositivo
        public ActionResult Listagem()
        {
            var listagem = _dispositivoServico.ObterTodos();
            return View(listagem);
        }

        // GET: Dispositivo/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            var dispositivo = _dispositivoServico.ObterPorId(id);
            return View(dispositivo);
        }

        // GET: Dispositivo/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Dispositivo/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(DispositivoNo dispositivo)
        {
            try
            {
                _dispositivoServico.Salvar(dispositivo);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dispositivo/Edicao/5
        public ActionResult Edicao(int id)
        {
            var dispositivo = _dispositivoServico.ObterPorId(id);
            return View(dispositivo);
        }

        // POST: Dispositivo/Edicao/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edicao(int id, DispositivoNo dispositivo)
        {
            try
            {
                _dispositivoServico.Salvar(dispositivo);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dispositivo/Exclusao/5
        public ActionResult Exclusao(int id)
        {
            var dispositivo = _dispositivoServico.ObterPorId(id);
            return View(dispositivo);
        }

        // POST: Dispositivo/Exclusao/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Exclusao(int id, DispositivoNo dispositivo)
        {
            try
            {
                _dispositivoServico.Excluir(dispositivo);

                return RedirectToAction(nameof(Listagem));
            }
            catch
            {
                return View();
            }
        }
    }
}