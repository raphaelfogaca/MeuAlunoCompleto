using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuAlunoRepo.Migrations
{
    public partial class Contrato2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Clausulas",
                newName: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContratoId",
                table: "Clausulas",
                newName: "EmpresaId");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Contratos",
                type: "int",
                nullable: true);
        }
    }
}
