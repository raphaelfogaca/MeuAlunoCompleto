using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuAlunoRepo.Migrations
{
    public partial class NovaClasseServicoAula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Servicos_ServicoId",
                table: "Aulas");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_ServicoId",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Aulas");

            migrationBuilder.CreateTable(
                name: "ServicoAula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoAula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoAula_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ServicoAula_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicoAula_AulaId",
                table: "ServicoAula",
                column: "AulaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoAula_ServicoId",
                table: "ServicoAula",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicoAula");

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Aulas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_ServicoId",
                table: "Aulas",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Servicos_ServicoId",
                table: "Aulas",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
