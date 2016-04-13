using OS.Sys.Dominio.Entidades;
using OS.Sys.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OS.Sys.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosRepositorio _repositorio;

        // GET: Autenticacao
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Usuario());
        } 

        [HttpPost]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            _repositorio = new UsuariosRepositorio();

            //_repositorio.ObterUsuario(usuario);

            if (ModelState.IsValid)
            {
                Usuario user = _repositorio.ObterUsuario(usuario);

                if(user != null)
                {
                    if(!Equals(usuario.Senha, user.Senha))
                    {
                        ModelState.AddModelError("", "Senha incorreta!");

                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.Login, false);

                        if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && !returnUrl.StartsWith("/\\"))
                        { 
                            return Redirect(returnUrl);
                        }

                        if (returnUrl == null) { 
                           returnUrl = "../Administrativo/OS/Index";
                                return Redirect(returnUrl);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário não cadastrado");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(new Usuario());
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return Redirect("../Autenticacao/Login");
        }
    }
}