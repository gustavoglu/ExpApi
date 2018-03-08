using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Exp.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaTipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    CriadoPor = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    DeletadoPor = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    RazaoSocial = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true),
                    Funcao = table.Column<string>(nullable: true),
                    Id_cliente = table.Column<Guid>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    CriadoPor = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    DeletadoPor = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Id_contaTipo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TelefoneAdicional = table.Column<string>(nullable: true),
                    TipoDocumento = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Contas_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contas_ContaTipos_Id_contaTipo",
                        column: x => x.Id_contaTipo,
                        principalTable: "ContaTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContaContatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    CriadoPor = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    DeletadoPor = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Funcao = table.Column<string>(nullable: true),
                    Id_conta = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TelefoneAdicional = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaContatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaContatos_Contas_Id_conta",
                        column: x => x.Id_conta,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaEnderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    CriadoPor = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: false),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    DeletadoPor = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Id_conta = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaEnderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaEnderecos_Contas_Id_conta",
                        column: x => x.Id_conta,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaContatos_Id_conta",
                table: "ContaContatos",
                column: "Id_conta");

            migrationBuilder.CreateIndex(
                name: "IX_ContaEnderecos_Id_conta",
                table: "ContaEnderecos",
                column: "Id_conta");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Id_cliente",
                table: "Contas",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Id_contaTipo",
                table: "Contas",
                column: "Id_contaTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaContatos");

            migrationBuilder.DropTable(
                name: "ContaEnderecos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "ContaTipos");
        }
    }
}
