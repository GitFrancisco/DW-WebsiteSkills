﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillPull.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsFK = table.Column<int>(type: "int", nullable: false),
                    SubscricaoFK = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificuldade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    IdRecurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRecurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConteudoRecurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRecurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillsFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.IdRecurso);
                    table.ForeignKey(
                        name: "FK_Recurso_Skills_SkillsFK",
                        column: x => x.SkillsFK,
                        principalTable: "Skills",
                        principalColumn: "SkillsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IdAluno = table.Column<int>(type: "int", nullable: true),
                    DataInscricao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumMentor = table.Column<int>(type: "int", nullable: true),
                    SkillsFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizadores_Skills_SkillsFK",
                        column: x => x.SkillsFK,
                        principalTable: "Skills",
                        principalColumn: "SkillsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ensina",
                columns: table => new
                {
                    SkillsFK = table.Column<int>(type: "int", nullable: false),
                    MentorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensina", x => new { x.SkillsFK, x.MentorFK });
                    table.ForeignKey(
                        name: "FK_Ensina_Skills_SkillsFK",
                        column: x => x.SkillsFK,
                        principalTable: "Skills",
                        principalColumn: "SkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ensina_Utilizadores_MentorFK",
                        column: x => x.MentorFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlunoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscricao_Utilizadores_AlunoFK",
                        column: x => x.AlunoFK,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofere",
                columns: table => new
                {
                    SkillsFK = table.Column<int>(type: "int", nullable: false),
                    SubscricaoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofere", x => new { x.SkillsFK, x.SubscricaoFK });
                    table.ForeignKey(
                        name: "FK_Ofere_Skills_SkillsFK",
                        column: x => x.SkillsFK,
                        principalTable: "Skills",
                        principalColumn: "SkillsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ofere_Subscricao_SubscricaoFK",
                        column: x => x.SubscricaoFK,
                        principalTable: "Subscricao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ensina_MentorFK",
                table: "Ensina",
                column: "MentorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Ofere_SubscricaoFK",
                table: "Ofere",
                column: "SubscricaoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_SkillsFK",
                table: "Recurso",
                column: "SkillsFK");

            migrationBuilder.CreateIndex(
                name: "IX_Subscricao_AlunoFK",
                table: "Subscricao",
                column: "AlunoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizadores_SkillsFK",
                table: "Utilizadores",
                column: "SkillsFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ensina");

            migrationBuilder.DropTable(
                name: "Ofere");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropTable(
                name: "Subscricao");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
