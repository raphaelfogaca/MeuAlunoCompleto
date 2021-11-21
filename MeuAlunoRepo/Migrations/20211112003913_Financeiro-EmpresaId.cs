using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuAlunoRepo.Migrations
{
    public partial class FinanceiroEmpresaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Financeiros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Financeiros");
        }
    }
}
