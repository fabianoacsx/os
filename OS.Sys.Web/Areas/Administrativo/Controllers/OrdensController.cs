using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OS.Sys.Dominio.Repositorio;
using OS.Sys.Dominio.Entidades;
using OS.Sys.Web.Areas.Administrativo.Models;

namespace OS.Sys.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class OrdensController : Controller
    {
        //private Ordem_de_servicoRepositorio _repositorio;
        // GET: Administrativo/Ordens
        //public ActionResult Index()
        //{
        //    _repositorio = new Ordem_de_servicoRepositorio();
        //    var Ordem_de_servicos = _repositorio.Ordem_de_servicos.Take(10);
        //    return View(Ordem_de_servicos);
        //}

        private Ordem_de_servicoRepositorio _repositorio = new Ordem_de_servicoRepositorio();
        

        public ActionResult Index(string BuscaStatus)
        {
            var Ordem_de_servicos = from os in _repositorio.Ordem_de_servicos
                                    select os;

            if (!String.IsNullOrEmpty(BuscaStatus))
            {
                //Ordem_de_servicos = Ordem_de_servicos.Where(os => os.status_os.ToUpper().Contains(BuscaStatus.ToUpper()));

                Ordem_de_servicos = Ordem_de_servicos.Where(os => os.status_os.ToUpper().Contains(BuscaStatus.ToUpper()));
            }
            else
            {
                //Ordem_de_servicos = _repositorio.Ordem_de_servicos.Take(10);
                Ordem_de_servicos = _repositorio.Ordem_de_servicos.Take(1000);
            }
            //return View(Ordem_de_servicos);
            return View(Ordem_de_servicos.ToList());
            
        }

        public ActionResult Alterar(int num_os)
        {
            _repositorio = new Ordem_de_servicoRepositorio();
            Ordem_de_servico ordem_de_servico = _repositorio.Ordem_de_servicos
                .FirstOrDefault(o => o.num_os == num_os);

                return View(ordem_de_servico);

        }

        public ActionResult Visualizar(int num_os)
        {
            _repositorio = new Ordem_de_servicoRepositorio();
            Ordem_de_servico ordem_de_servico = _repositorio.Ordem_de_servicos
                .FirstOrDefault(o => o.num_os == num_os);

            return View("Visualizar", ordem_de_servico);

        }

        [HttpPost]
        public ActionResult Alterar(Ordem_de_servico OrdemDeServico)
        {
            if (ModelState.IsValid)
            {
                _repositorio = new Ordem_de_servicoRepositorio();
                _repositorio.Salvar(OrdemDeServico);

                TempData["mesagem"] = string.Format("{0} foi salvo com sucesso", OrdemDeServico.num_os);

                return RedirectToAction("Index");
            }
            return View(OrdemDeServico);
        }

        public ViewResult NovaOrdem()
        {
            return View("Criar", new Ordem_de_servico());
        }

        [HttpPost]
        public ActionResult Excluir(int id_os)
        {
            _repositorio = new Ordem_de_servicoRepositorio();

            Ordem_de_servico OS = _repositorio.Excluir(id_os);

            if(OS != null)
            {
                TempData["mensagem"] = string.Format("{0} foi excluido com sucesso.", OS.num_os);
            }

            return RedirectToAction("Index");
        }
    }
}