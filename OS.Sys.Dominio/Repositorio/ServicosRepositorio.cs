using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS.Sys.Dominio.Entidades;

namespace OS.Sys.Dominio.Repositorio
{
    public class ServicosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Servico> Servicos
        {
            get { return _context.Servicos; }
        }
    }
}
