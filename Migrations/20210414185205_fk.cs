using Microsoft.EntityFrameworkCore.Migrations;

namespace Album.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_Name = table.Column<string>(nullable: true),
                    course_Descrition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.course_Id);
                });

            migrationBuilder.CreateTable(
                name: "DeadlineCate",
                columns: table => new
                {
                    dlCate_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dlCate_Name = table.Column<string>(nullable: true),
                    dlCate_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadlineCate", x => x.dlCate_Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterEvents",
                columns: table => new
                {
                    resEvent_CourseId = table.Column<int>(nullable: false),
                    resEvent_UserId = table.Column<string>(nullable: true),
                    resEvent_DeadlineCate = table.Column<int>(nullable: false),
                    resEvent_EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterEvents", x => x.resEvent_CourseId);
                    table.ForeignKey(
                        name: "FK_RegisterEvents_Courses_resEvent_CourseId",
                        column: x => x.resEvent_CourseId,
                        principalTable: "Courses",
                        principalColumn: "course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterEvents_DeadlineCate_resEvent_DeadlineCate",
                        column: x => x.resEvent_DeadlineCate,
                        principalTable: "DeadlineCate",
                        principalColumn: "dlCate_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterEvents_Articles_resEvent_EventId",
                        column: x => x.resEvent_EventId,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterEvents_Users_resEvent_UserId",
                        column: x => x.resEvent_UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_resEvent_DeadlineCate",
                table: "RegisterEvents",
                column: "resEvent_DeadlineCate");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_resEvent_EventId",
                table: "RegisterEvents",
                column: "resEvent_EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEvents_resEvent_UserId",
                table: "RegisterEvents",
                column: "resEvent_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterEvents");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "DeadlineCate");
        }
    }
}
