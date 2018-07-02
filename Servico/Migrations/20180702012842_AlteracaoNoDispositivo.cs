using Microsoft.EntityFrameworkCore.Migrations;

namespace Servico.Migrations
{
    public partial class AlteracaoNoDispositivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Erro",
                table: "Dispositivos",
                maxLength: 600,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Inacessivel",
                table: "Dispositivos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Erro",
                table: "Dispositivos");

            migrationBuilder.DropColumn(
                name: "Inacessivel",
                table: "Dispositivos");
        }
    }
}
