using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS.Sys.Dominio.Entidades;

namespace OS.Sys.Dominio.Repositorio
{
    public class Ordem_de_servicoRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Ordem_de_servico> Ordem_de_servicos
        {
            get { return _context.Ordem_de_servicos; }
        }



        //Salva uma nova OS ou Altera
        public void Salvar(Ordem_de_servico OrdemDeServico)
        {
            if (OrdemDeServico.id_os == 0)
            {
                OrdemDeServico.data_de_criacao = DateTime.Now;
                OrdemDeServico.data_de_atualizacao = DateTime.Now;
                //Salva nova OS
                _context.Ordem_de_servicos.Add(OrdemDeServico);
            }
            else
            {
                Ordem_de_servico OS = _context.Ordem_de_servicos.Find(OrdemDeServico.id_os);

                if (OS != null)
                {
                    //valores alterados na tela passando para os campos do banco de dados
                    OS.num_os = OrdemDeServico.num_os;
                    OS.cod_cliente_os = OrdemDeServico.cod_cliente_os;
                    OS.nome_cliente_os = OrdemDeServico.nome_cliente_os;
                    OS.status_os = OrdemDeServico.status_os;
                    OS.equipamento_os = OrdemDeServico.equipamento_os;
                    OS.defeito_reclamado_os = OrdemDeServico.defeito_reclamado_os;
                    OS.defeito_detectado_os = OrdemDeServico.defeito_detectado_os;
                    OS.servico_a_realizar_os = OrdemDeServico.servico_a_realizar_os;
                    OS.servico_realizado_os = OrdemDeServico.servico_realizado_os;
                    OS.info_adicionais_os = OrdemDeServico.info_adicionais_os;
                    OS.data_de_atualizacao = DateTime.Now;
                }
           
            }

            _context.SaveChanges();
        }

        //Excluir
        public Ordem_de_servico Excluir(int id_os)
        {
            Ordem_de_servico OS = _context.Ordem_de_servicos.Find(id_os);
            
            if(OS != null)
            {
                _context.Ordem_de_servicos.Remove(OS);
                _context.SaveChanges();
            }

            return OS;
        }
    }
}
