using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Album.Migrations
{
    public partial class fkdeadline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deadlines",
                columns: table => new
                {
                    dl_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dl_Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    dl_TimeDeadline = table.Column<DateTime>(nullable: false),
                    dl_Description = table.Column<string>(nullable: true),
                    dl_CreateBy = table.Column<string>(nullable: true),
                    dl_Status = table.Column<string>(nullable: true),
                    dl_ModifiedBy = table.Column<string>(nullable: true),
                    dl_CreateDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deadlines", x => x.dl_Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterDeadlines",
                columns: table => new
                {
                    rd_DeadineCate = table.Column<int>(nullable: false),
                    rd_DeadlineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterDeadlines", x => x.rd_DeadineCate);
                    table.ForeignKey(
                        name: "FK_RegisterDeadlines_Deadlines_rd_DeadineCate",
                        column: x => x.rd_DeadineCate,
                        principalTable: "Deadlines",
                        principalColumn: "dl_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterDeadlines_DeadlineCate_rd_DeadlineId",
                        column: x => x.rd_DeadlineId,
                        principalTable: "DeadlineCate",
                        principalColumn: "dlCate_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDeadlines_rd_DeadlineId",
                table: "RegisterDeadlines",
                column: "rd_DeadlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterDeadlines");

            migrationBuilder.DropTable(
                name: "Deadlines");
        }
    }
}
