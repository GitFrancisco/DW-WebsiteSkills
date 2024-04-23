﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillPull.Data;

#nullable disable

namespace SkillPull.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillPull.Models.Ensina", b =>
                {
                    b.Property<int>("SkillsFK")
                        .HasColumnType("int");

                    b.Property<int>("MentorFK")
                        .HasColumnType("int");

                    b.HasKey("SkillsFK", "MentorFK");

                    b.HasIndex("MentorFK");

                    b.ToTable("Ensina");
                });

            modelBuilder.Entity("SkillPull.Models.Ofere", b =>
                {
                    b.Property<int>("SkillsFK")
                        .HasColumnType("int");

                    b.Property<int>("SubscricaoFK")
                        .HasColumnType("int");

                    b.HasKey("SkillsFK", "SubscricaoFK");

                    b.HasIndex("SubscricaoFK");

                    b.ToTable("Ofere");
                });

            modelBuilder.Entity("SkillPull.Models.Recurso", b =>
                {
                    b.Property<int>("IdRecurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecurso"));

                    b.Property<string>("ConteudoRecurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeRecurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillsFK")
                        .HasColumnType("int");

                    b.Property<string>("TipoRecurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRecurso");

                    b.HasIndex("SkillsFK");

                    b.ToTable("Recurso");
                });

            modelBuilder.Entity("SkillPull.Models.Skills", b =>
                {
                    b.Property<int>("SkillsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillsId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dificuldade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillsFK")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("SubscricaoFK")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("Tempo")
                        .HasColumnType("int");

                    b.HasKey("SkillsId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SkillPull.Models.Subscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoFK")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoFK");

                    b.ToTable("Subscricao");
                });

            modelBuilder.Entity("SkillPull.Models.Utilizadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilizadores");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Utilizadores");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SkillPull.Models.Aluno", b =>
                {
                    b.HasBaseType("SkillPull.Models.Utilizadores");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Aluno");
                });

            modelBuilder.Entity("SkillPull.Models.Mentor", b =>
                {
                    b.HasBaseType("SkillPull.Models.Utilizadores");

                    b.Property<int>("NumMentor")
                        .HasColumnType("int");

                    b.Property<int>("SkillsFK")
                        .HasColumnType("int");

                    b.HasIndex("SkillsFK");

                    b.HasDiscriminator().HasValue("Mentor");
                });

            modelBuilder.Entity("SkillPull.Models.Ensina", b =>
                {
                    b.HasOne("SkillPull.Models.Mentor", "Mentor")
                        .WithMany("ListaEnsina")
                        .HasForeignKey("MentorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillPull.Models.Skills", "Skills")
                        .WithMany("ListaEnsina")
                        .HasForeignKey("SkillsFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("SkillPull.Models.Ofere", b =>
                {
                    b.HasOne("SkillPull.Models.Skills", "Skills")
                        .WithMany()
                        .HasForeignKey("SkillsFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillPull.Models.Subscricao", "Subscricao")
                        .WithMany()
                        .HasForeignKey("SubscricaoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skills");

                    b.Navigation("Subscricao");
                });

            modelBuilder.Entity("SkillPull.Models.Recurso", b =>
                {
                    b.HasOne("SkillPull.Models.Skills", "Skill")
                        .WithMany("ListaRecursos")
                        .HasForeignKey("SkillsFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("SkillPull.Models.Subscricao", b =>
                {
                    b.HasOne("SkillPull.Models.Aluno", "Aluno")
                        .WithMany("ListaSubscricoes")
                        .HasForeignKey("AlunoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("SkillPull.Models.Mentor", b =>
                {
                    b.HasOne("SkillPull.Models.Skills", "Skills")
                        .WithMany()
                        .HasForeignKey("SkillsFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("SkillPull.Models.Skills", b =>
                {
                    b.Navigation("ListaEnsina");

                    b.Navigation("ListaRecursos");
                });

            modelBuilder.Entity("SkillPull.Models.Aluno", b =>
                {
                    b.Navigation("ListaSubscricoes");
                });

            modelBuilder.Entity("SkillPull.Models.Mentor", b =>
                {
                    b.Navigation("ListaEnsina");
                });
#pragma warning restore 612, 618
        }
    }
}
