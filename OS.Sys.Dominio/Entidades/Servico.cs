using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OS.Sys.Dominio.Entidades
{
    public class Servico
    {
        [Key]
        public int cod_ser { get; set; }
        public string nome_ser { get; set; }
        public string descricao_ser { get; set; }
        public string categoria_ser { get; set; }
        public decimal preco_ser { get; set; }

    }
}
