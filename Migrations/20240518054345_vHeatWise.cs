using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeatWise_Sprint_2.Net.Migrations
{
    /// <inheritdoc />
    public partial class vHeatWise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    PlanoId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.PlanoId);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    FormaPagamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PlanoId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Plano",
                        principalColumn: "PlanoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Usuario = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EmpresaId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Relatorio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TempoTelaAtiva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempoInatividade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroCliquesMouse = table.Column<int>(type: "int", nullable: false),
                    NumeroTeclasPressionadas = table.Column<int>(type: "int", nullable: false),
                    TempoMedioConclusaoTarefas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarefasConcluidasPorTempo = table.Column<int>(type: "int", nullable: false),
                    TaxaErros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempoMedioCorrecaoErros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndiceEficiencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisfacaoUsuario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SiteId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analise_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analise_SiteId",
                table: "Analise",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_PlanoId",
                table: "Empresa",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_EmpresaId",
                table: "Site",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analise");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Plano");
        }
    }
}
