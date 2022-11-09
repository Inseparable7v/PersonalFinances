using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalFinances.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXPERTS",
                columns: table => new
                {
                    EXPRET_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    EXPERT_TYPE = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    EXPERT_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EXPERT_SURNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EXPERT_LASTNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPERTS", x => x.EXPRET_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_STATUS",
                columns: table => new
                {
                    PSTATUS_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PSTATUS_NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_STATUS", x => x.PSTATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "TASK_STATUS",
                columns: table => new
                {
                    STATUS_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATUS_NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK_STATUS", x => x.STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurrName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS",
                columns: table => new
                {
                    PROJECT_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    PROJECT_NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PROJECT_DESCRIPTION = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    PROJECT_CLIENT = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PROJECT_BEGIN = table.Column<DateTime>(type: "date", nullable: false),
                    PROJECT_END = table.Column<DateTime>(type: "date", nullable: false),
                    PROJECT_STATUS = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    PROJECT_PAY_PER_HOUR = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS", x => x.PROJECT_ID);
                    table.ForeignKey(
                        name: "FK_PROJECTS_REFERENCE_PROJECT_",
                        column: x => x.PROJECT_STATUS,
                        principalTable: "PROJECT_STATUS",
                        principalColumn: "PSTATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT_TASKS",
                columns: table => new
                {
                    TASK_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    PROJECT_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    EXPRET_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    TASK_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TASK_DESCRIPTION = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    TAS_DELIVERABLES = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    TASK_BEGIN = table.Column<DateTime>(type: "date", nullable: false),
                    TASK_END = table.Column<DateTime>(type: "date", nullable: false),
                    TASK_PRIORITY = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    TASK_STATUS = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    TASK_READY = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    TASK_HOURS = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT_TASKS", x => x.TASK_ID);
                    table.ForeignKey(
                        name: "FK_PROJECT__REFERENCE_EXPERTS",
                        column: x => x.EXPRET_ID,
                        principalTable: "EXPERTS",
                        principalColumn: "EXPRET_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROJECT__REFERENCE_PROJECTS",
                        column: x => x.PROJECT_ID,
                        principalTable: "PROJECTS",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROJECT__REFERENCE_TASK_STA",
                        column: x => x.TASK_STATUS,
                        principalTable: "TASK_STATUS",
                        principalColumn: "STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_PROJECT_STATUS_UQ",
                table: "PROJECT_STATUS",
                column: "PSTATUS_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_PROJECT_TASK",
                table: "PROJECT_TASKS",
                columns: new[] { "PROJECT_ID", "TASK_NAME" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TASKS_EXPRET_ID",
                table: "PROJECT_TASKS",
                column: "EXPRET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECT_TASKS_TASK_STATUS",
                table: "PROJECT_TASKS",
                column: "TASK_STATUS");

            migrationBuilder.CreateIndex(
                name: "IDX_PROJECT_UQ",
                table: "PROJECTS",
                column: "PROJECT_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_PROJECT_STATUS",
                table: "PROJECTS",
                column: "PROJECT_STATUS");

            migrationBuilder.CreateIndex(
                name: "IDX_TASK_STATUS_UQ",
                table: "TASK_STATUS",
                column: "STATUS_NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROJECT_TASKS");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EXPERTS");

            migrationBuilder.DropTable(
                name: "PROJECTS");

            migrationBuilder.DropTable(
                name: "TASK_STATUS");

            migrationBuilder.DropTable(
                name: "PROJECT_STATUS");
        }
    }
}
