﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Event_Plus.Context;

#nullable disable

namespace Projeto_Event_Plus.Migrations
{
    [DbContext(typeof(Events_Plus_Context))]
    partial class Events_Plus_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto_Event_Plus.Domains.ComentarioEvento", b =>
                {
                    b.Property<Guid>("ComentarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<Guid?>("EventoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Exibe")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComentarioID");

                    b.HasIndex("EventoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Eventos", b =>
                {
                    b.Property<Guid>("EventosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("InstituicaoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoEventoID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventosID");

                    b.HasIndex("InstituicaoID");

                    b.HasIndex("TipoEventoID");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Instituicao", b =>
                {
                    b.Property<Guid>("InstituicaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("InstituicaoID");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Presenca", b =>
                {
                    b.Property<Guid>("PresencaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Situcao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PresencaID");

                    b.HasIndex("EventoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Presenca");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.TipoEvento", b =>
                {
                    b.Property<Guid>("TipoEventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("TipoEventoID");

                    b.ToTable("TipoEvento");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.TipoUsuario", b =>
                {
                    b.Property<Guid>("TipoUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TipoUsuarioID");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<Guid>("TipoUsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TipoUsuarioID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.ComentarioEvento", b =>
                {
                    b.HasOne("Projeto_Event_Plus.Domains.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoID");

                    b.HasOne("Projeto_Event_Plus.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Eventos");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Eventos", b =>
                {
                    b.HasOne("Projeto_Event_Plus.Domains.Instituicao", "Intituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Event_Plus.Domains.TipoEvento", "TipoEvento")
                        .WithMany()
                        .HasForeignKey("TipoEventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intituicao");

                    b.Navigation("TipoEvento");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Presenca", b =>
                {
                    b.HasOne("Projeto_Event_Plus.Domains.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Event_Plus.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_Event_Plus.Domains.Usuario", b =>
                {
                    b.HasOne("Projeto_Event_Plus.Domains.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
