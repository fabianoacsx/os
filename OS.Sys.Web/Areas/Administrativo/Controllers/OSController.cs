using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OS.Sys.Dominio.Entidades;
using OS.Sys.Dominio.Repositorio;

namespace OS.Sys.Web.Areas.Administrativo.Controllers
{
    public class OSController : Controller
    {
        private EfDbContext db = new EfDbContext();

        // GET: Administrativo/OS
        public ActionResult Index()
        {
            return View(db.Ordem_de_servicos.ToList());
        }

        // GET: Administrativo/OS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem_de_servico ordem_de_servico = db.Ordem_de_servicos.Find(id);
            if (ordem_de_servico == null)
            {
                return HttpNotFound();
            }
            return View(ordem_de_servico);
        }

        // GET: Administrativo/OS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/OS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_os,num_os,cod_cliente_os,nome_cliente_os,status_os,equipamento_os,defeito_reclamado_os,defeito_detectado_os,servico_a_realizar_os,servico_realizado_os,info_adicionais_os,data_de_criacao,data_de_atualizacao")] Ordem_de_servico ordem_de_servico)
        {
            if (ModelState.IsValid)
            {
                ordem_de_servico.data_de_criacao = DateTime.Now;
                ordem_de_servico.data_de_atualizacao = DateTime.Now;

                db.Ordem_de_servicos.Add(ordem_de_servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordem_de_servico);
        }

        // GET: Administrativo/OS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem_de_servico ordem_de_servico = db.Ordem_de_servicos.Find(id);
            if (ordem_de_servico == null)
            {
                return HttpNotFound();
            }
            return View(ordem_de_servico);
        }

        // POST: Administrativo/OS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_os,num_os,cod_cliente_os,nome_cliente_os,status_os,equipamento_os,defeito_reclamado_os,defeito_detectado_os,servico_a_realizar_os,servico_realizado_os,info_adicionais_os,data_de_criacao,data_de_atualizacao")] Ordem_de_servico ordem_de_servico) 
        {
            if (ModelState.IsValid)
            {

                ordem_de_servico.data_de_atualizacao = DateTime.Now;
                
                db.Entry(ordem_de_servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordem_de_servico);
        }

        // GET: Administrativo/OS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordem_de_servico ordem_de_servico = db.Ordem_de_servicos.Find(id);
            if (ordem_de_servico == null)
            {
                return HttpNotFound();
            }
            return View(ordem_de_servico);
        }

        // POST: Administrativo/OS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordem_de_servico ordem_de_servico = db.Ordem_de_servicos.Find(id);
            db.Ordem_de_servicos.Remove(ordem_de_servico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
