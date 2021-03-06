﻿using System;
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
    public class UsuariosController : Controller
    {
        private EfDbContext db = new EfDbContext();

        // GET: Administrativo/Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Administrativo/Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Administrativo/Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Login,Senha,Nome,Tipo,UltimoAcesso")] Usuario usuario) Removendo o campo UltimoAcesso e incluindo o campo DataCriacao
        public ActionResult Create([Bind(Include = "Id,Login,Senha,Nome,Tipo,DataCriacao")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.DataCriacao = DateTime.Now;
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Administrativo/Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Administrativo/Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Login,Senha,Nome,Tipo,UltimoAcesso")] Usuario usuario) Removendo o campo UltimoAcesso
        //public ActionResult Edit([Bind(Include = "Id,Login,Senha,Nome,Tipo")] Usuario usuario)

        public ActionResult Edit([Bind(Prefix = "Usuario")]FormCollection collection)
        {

            Usuario usuario = new Usuario();
            
            TryUpdateModel(usuario, "Usuario", collection.ToValueProvider());
            usuario.UltimoAcesso = DateTime.Now;

            if (ModelState.IsValid)
            {
                //db.Entry(usuario).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        //{
        //    if (ModelState.IsValid)
        //    {   
        //        db.Entry(usuario).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(usuario);
        //}

        // GET: Administrativo/Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Administrativo/Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
