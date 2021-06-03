using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;

namespace WmsSystem.Repository.Context
{
    public class WmsContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WMSBD;Data Source=LAPTOP-6TFFSG8O");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Seq);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.Seq);
            });
        }
    }
}
