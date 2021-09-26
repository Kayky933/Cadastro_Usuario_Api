﻿// <auto-generated />
using System;
using Api_Cadastro_Usuario.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api_Cadastro_Usuario.Migrations
{
    [DbContext(typeof(Api_Cadastro_UsuarioContext))]
    [Migration("20210926152916_NovoCampoRoleUsuario")]
    partial class NovoCampoRoleUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api_Cadastro_Usuario.Models.TasksToDoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Horario_Agendado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Horario_Post")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Task")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Api_Cadastro_Usuario.Models.UsuarioModel", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Codigo");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Api_Cadastro_Usuario.Models.TasksToDoModel", b =>
                {
                    b.HasOne("Api_Cadastro_Usuario.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
