using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DDDCommerceBCC.Domain;

namespace DDDCommerceBCC.Infra
{
    public class ECommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDb01");
        }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
