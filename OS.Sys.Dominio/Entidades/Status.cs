using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Sys.Dominio.Entidades
{
    public class Status
    {
        [Key]
        public int Id_status { get; set; }
        public string Descricao_status { get; set; }

    }
}
