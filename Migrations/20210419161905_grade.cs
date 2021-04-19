using Microsoft.EntityFrameworkCore.Migrations;

namespace Album.Migrations
{
    public partial class grade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gradeManagemens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grade = table.Column<int>(nullable: false),
                    DeadIdG = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradeManagemens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gradeManagemens_Deadlines_DeadIdG",
                        column: x => x.DeadIdG,
                        principalTable: "Deadlines",
                        principalColumn: "dl_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gradeManagemens_DeadIdG",
                table: "gradeManagemens",
                column: "DeadIdG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gradeManagemens");
        }
    }
}
