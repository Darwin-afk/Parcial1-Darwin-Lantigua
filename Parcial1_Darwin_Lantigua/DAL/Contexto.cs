using System;
using System.Collections.Generic;
using System.Text;
using Parcial1_Darwin_Lantigua.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Parcial1_Darwin_Lantigua.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-3SJ2VPS\SQLEXPRESS; Database = ArticulosDb; Trusted_Connection = True; ");
        }
    }
}
