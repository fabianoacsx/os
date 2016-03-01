using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OS.Sys.Dominio.Entidades
{
    public class Ordem_de_servico
    {
        [Key]
        [HiddenInput]
        public int id_os { get; set; }

        
        [Display(Name = "Número da OS")]
        public int num_os { get; set; }

        [Display(Name ="Código do Cliente")]
        public int cod_cliente_os { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string nome_cliente_os { get; set; }

        [Display(Name = "Status OS")]
        public string status_os { get; set; }

        [Display(Name = "Equipamento")]
        public string equipamento_os { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Defeito Reclamado")]
        public string defeito_reclamado_os { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Defeito Detectado")]
        public string defeito_detectado_os { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Serviço a realizar")]
        public string servico_a_realizar_os { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Serviço Realizado")]
        public string servico_realizado_os { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Informações adicionais")]
        public string info_adicionais_os { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de criação")]
        public DateTime data_de_criacao { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de atualização")]
        public DateTime data_de_atualizacao { get; set; }
    }

  
}