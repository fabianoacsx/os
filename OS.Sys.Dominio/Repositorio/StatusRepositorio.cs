using OS.Sys.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Sys.Dominio.Repositorio
{
    public class StatusRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Status> Status
        {
            get { return _context.Status; }
        }
    }
}
