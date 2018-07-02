using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Servico.Migrations
{
    public partial class InclusaoItemTransacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Blocos_BlocoId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Transacoes");

            migrationBuilder.AlterColumn<int>(
                name: "BlocoId",
                table: "Transacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ItansTransacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    TransacaoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItansTransacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItansTransacao_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItansTransacao_Transacoes_TransacaoId",
                        column: x => x.TransacaoId,
                        principalTable: "Transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItansTransacao_ProdutoId",
                table: "ItansTransacao",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItansTransacao_TransacaoId",
                table: "ItansTransacao",
                column: "TransacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Blocos_BlocoId",
                table: "Transacoes",
                column: "BlocoId",
                principalTable: "Blocos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Blocos_BlocoId",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "ItansTransacao");

            migrationBuilder.AlterColumn<int>(
                name: "BlocoId",
                table: "Transacoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Transacoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Blocos_BlocoId",
                table: "Transacoes",
                column: "BlocoId",
                principalTable: "Blocos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
