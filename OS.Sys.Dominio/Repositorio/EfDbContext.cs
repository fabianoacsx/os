using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using OS.Sys.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OS.Sys.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Ordem_de_servico> Ordem_de_servicos { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Servico>().ToTable("Servicos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        }

        
    }
}
