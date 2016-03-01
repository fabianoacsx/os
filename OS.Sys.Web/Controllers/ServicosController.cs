using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OS.Sys.Dominio.Repositorio;

namespace OS.Sys.Web.Controllers
{
    public class ServicosController : Controller
    {
        private ServicosRepositorio _repositorio;

        // GET: Servicos
        public ActionResult Index()
        {
            _repositorio = new ServicosRepositorio();
            var servicos = _repositorio.Servicos.Take(10);

            return View(servicos);
        }
    }
}