using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Album.Migrations
{
    public partial class fkcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    cmt_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_Content = table.Column<string>(nullable: true),
                    comment_DateUpload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.cmt_Id);
                });

            migrationBuilder.CreateTable(
                name: "file",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    PublishDate = table.Column<int>(nullable: true),
                    file_IsSelected = table.Column<bool>(nullable: false),
                    file_DateUpload = table.Column<DateTime>(nullable: false),
                    file_CreateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file", x => x.ID);
                    table.ForeignKey(
                        name: "FK_file_Deadlines_PublishDate",
                        column: x => x.PublishDate,
                        principalTable: "Deadlines",
                        principalColumn: "dl_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterComments",
                columns: table => new
                {
                    rescmt_CmtId = table.Column<int>(nullable: false),
                    rescmt_FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterComments", x => x.rescmt_CmtId);
                    table.ForeignKey(
                        name: "FK_RegisterComments_Comments_rescmt_CmtId",
                        column: x => x.rescmt_CmtId,
                        principalTable: "Comments",
                        principalColumn: "cmt_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterComments_file_rescmt_FileId",
                        column: x => x.rescmt_FileId,
                        principalTable: "file",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_file_PublishDate",
                table: "file",
                column: "PublishDate");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterComments_rescmt_FileId",
                table: "RegisterComments",
                column: "rescmt_FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterComments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "file");
        }
    }
}
