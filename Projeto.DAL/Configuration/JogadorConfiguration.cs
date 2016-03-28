using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entity.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.DAL.Configuration
{
    public class JogadorConfiguration : EntityTypeConfiguration<Jogador>
    {
        public JogadorConfiguration()
        {
            ToTable("TB_JOGADOR");

            HasKey(j => j.IdJogador);

            Property(j => j.IdJogador)
                .HasColumnName("IDJOGADOR")
                .IsRequired();

            Property(j => j.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(j => j.Apelido)
                .HasColumnName("APELIDO")
                .HasMaxLength(25);

            Property(j => j.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .IsRequired();

            Property(j => j.Posicao)
                .HasColumnName("POSICAO")
                .HasMaxLength(25)
                .IsRequired();

            Property(j => j.IdTime)
                .HasColumnName("IDTIME")
                .IsRequired();

            #region Relacionamentos

            HasRequired(j => j.Time)
                .WithMany(t => t.Jogadores)
                .HasForeignKey(j => j.IdTime);

            #endregion
        }
    }
}
