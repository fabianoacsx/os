using OS.Sys.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Sys.Dominio.Repositorio
{
    
    public class UsuariosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public Usuario ObterUsuario(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(a => a.Login == usuario.Login);
        }
    }
}
