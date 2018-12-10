using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGBP.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    AuditoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Aprovado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.AuditoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(400)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Responsavels",
                columns: table => new
                {
                    ResponsavelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavels", x => x.ResponsavelId);
                });

            migrationBuilder.CreateTable(
                name: "BemPatrimonials",
                columns: table => new
                {
                    BemPatrimonialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    NumeroTombo = table.Column<string>(type: "varchar(30)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    ResponsavelId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BemPatrimonials", x => x.BemPatrimonialId);
                    table.ForeignKey(
                        name: "FK_BemPatrimonials_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BemPatrimonials_Responsavels_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsavels",
                        principalColumn: "ResponsavelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "varchar(400)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(200)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(12)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(9)", nullable: true),
                    ResponsavelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Responsavels_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsavels",
                        principalColumn: "ResponsavelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BemPatrimonialAuditorias",
                columns: table => new
                {
                    BemPatrimonialAuditoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BemPatrimonialId = table.Column<int>(nullable: false),
                    AuditoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BemPatrimonialAuditorias", x => x.BemPatrimonialAuditoriaId);
                    table.ForeignKey(
                        name: "FK_BemPatrimonialAuditorias_Auditorias_AuditoriaId",
                        column: x => x.AuditoriaId,
                        principalTable: "Auditorias",
                        principalColumn: "AuditoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BemPatrimonialAuditorias_BemPatrimonials_BemPatrimonialId",
                        column: x => x.BemPatrimonialId,
                        principalTable: "BemPatrimonials",
                        principalColumn: "BemPatrimonialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BemPatrimonialAuditorias_AuditoriaId",
                table: "BemPatrimonialAuditorias",
                column: "AuditoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_BemPatrimonialAuditorias_BemPatrimonialId",
                table: "BemPatrimonialAuditorias",
                column: "BemPatrimonialId");

            migrationBuilder.CreateIndex(
                name: "IX_BemPatrimonials_CategoriaId",
                table: "BemPatrimonials",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_BemPatrimonials_ResponsavelId",
                table: "BemPatrimonials",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ResponsavelId",
                table: "Enderecos",
                column: "ResponsavelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BemPatrimonialAuditorias");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "BemPatrimonials");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Responsavels");
        }
    }
}
