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
    [Migration("20180630213424_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlockChain.Entidades.Bloco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Altura");

                    b.Property<int>("Bits");

                    b.Property<string>("Chave");

                    b.Property<string>("ChaveBlocoAnterior");

                    b.Property<string>("ChaveBlocoSucessor");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<long>("Prova");

                    b.HasKey("Id");

                    b.ToTable("Blocos");
                });

            modelBuilder.Entity("BlockChain.Entidades.DispositivoNo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EnderecoUrl");

                    b.HasKey("Id");

                    b.ToTable("Dispositivos");
                });

            modelBuilder.Entity("BlockChain.Entidades.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlocoId");

                    b.Property<string>("Destinatario");

                    b.Property<int>("Quantidade");

                    b.Property<string>("Remetente");

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