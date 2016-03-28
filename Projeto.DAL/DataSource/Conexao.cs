using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entity.Entities;
using Projeto.DAL.Configuration;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.DAL.DataSource
{
    public class Conexao : DbContext
    {
        public Conexao()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JogadorConfiguration());
            modelBuilder.Configurations.Add(new TimeConfiguration());   
        }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Time> Time { get; set; }
    }
}
