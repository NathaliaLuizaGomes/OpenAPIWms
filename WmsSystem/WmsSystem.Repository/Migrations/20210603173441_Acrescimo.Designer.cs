﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WmsSystem.Repository.Context;

namespace WmsSystem.Repository.Migrations
{
    [DbContext(typeof(WmsContext))]
    [Migration("20210603173441_Acrescimo")]
    partial class Acrescimo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WmsSystem.Domain.Entites.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Acrestimo")
                        .HasColumnType("real");

                    b.Property<float>("Desconto")
                        .HasColumnType("real");

                    b.Property<string>("NomeCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WmsSystem.Domain.Entites.Models.Compra", b =>
                {
                    b.Property<int>("Seq")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdMercadoria")
                        .HasColumnType("int");

                    b.Property<int>("QtdEntrada")
                        .HasColumnType("int");

                    b.HasKey("Seq");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("WmsSystem.Domain.Entites.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriasIdCategoria")
                        .HasColumnType("int");

                    b.Property<bool>("Desativado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Grupo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PCusto")
                        .HasColumnType("real");

                    b.Property<float>("PVenda")
                        .HasColumnType("real");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UndMedida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriasIdCategoria");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WmsSystem.Domain.Entites.Models.Venda", b =>
                {
                    b.Property<int>("Seq")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMercadoria")
                        .HasColumnType("int");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<int>("QtdSaida")
                        .HasColumnType("int");

                    b.HasKey("Seq");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("WmsSystem.Domain.Entites.Models.Produto", b =>
                {
                    b.HasOne("WmsSystem.Domain.Entites.Models.Categoria", "Categorias")
                        .WithMany()
                        .HasForeignKey("CategoriasIdCategoria");

                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}
