using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OS.Sys.Web.Areas.Administrativo.Models
{
    public enum DropDownStatus
    {
        Iniciado,
        Em_Suporte,
        Aguardando_Cliente,
        Fechado
    }

    public class Todos_status
    {
        [Key]
        public int Id { get; set; }
        public DropDownStatus DropDownStatus { get; set; }
    }
}