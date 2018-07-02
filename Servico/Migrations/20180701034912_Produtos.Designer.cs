﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Servico.BancoDeDados;

namespace Servico.Migrations
{
    [DbContext(typeof(BlockchainClientContexto))]
    [Migration("20180701034912_Produtos")]
    partial class Produtos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlockChain.Entidades.Bloco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Altura");

                    b.Property<int>("Bits");

                    b.Property<string>("Chave")
                        .HasMaxLength(400);

                    b.Property<string>("ChaveBlocoAnterior")
                        .HasMaxLength(400);

                    b.Property<string>("ChaveBlocoSucessor")
                        .HasMaxLength(400);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<long>("Prova");

                    b.HasKey("Id");

                    b.ToTable("Blocos");
                });

            modelBuilder.Entity("BlockChain.Entidades.DispositivoNo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnderecoUrl")
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Dispositivos");
                });

            modelBuilder.Entity("BlockChain.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasMaxLength(50);

                    b.Property<string>("Descricao")
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("BlockChain.Entidades.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlocoId");

                    b.Property<string>("Destinatario")
                        .HasMaxLength(400);

                    b.Property<int>("Quantidade");

                    b.Property<string>("Remetente")
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.HasIndex("BlocoId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("BlockChain.Entidades.Transacao", b =>
                {
                    b.HasOne("BlockChain.Entidades.Bloco")
                        .WithMany("Transacoes")
                        .HasForeignKey("BlocoId");
                });
#pragma warning restore 612, 618
        }
    }
}