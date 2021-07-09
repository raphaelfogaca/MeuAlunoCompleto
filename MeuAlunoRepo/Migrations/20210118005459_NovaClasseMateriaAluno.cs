using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuAlunoRepo.Migrations
{
    public partial class NovaClasseMateriaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Alunos_AlunoId",
                table: "Materias");

            migrationBuilder.DropIndex(
                name: "IX_Materias_AlunoId",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Materias");

            migrationBuilder.CreateTable(
                name: "MateriaAluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaAluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MateriaAluno_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAluno_AlunoId",
                table: "MateriaAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAluno_MateriaId",
                table: "MateriaAluno",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaAluno");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Materias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_AlunoId",
                table: "Materias",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Alunos_AlunoId",
                table: "Materias",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
