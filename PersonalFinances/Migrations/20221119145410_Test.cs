using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalFinances.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENT",
                columns: table => new
                {
                    CLIENT_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENT_EGN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CLIENT_NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CLIENT_SURNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CLIENT_LASTNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CLIENT_EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CLIENT_PHONE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT", x => x.CLIENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "INCOME_EXPNECE",
                columns: table => new
                {
                    INCEXP_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INCEXP_NAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    INCEXP_TYPE = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCOME_EXPNECE", x => x.INCEXP_ID);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENT_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ADDRESS_TYPE = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    ADDRESS_REGION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ADDRES_MUNICIPALITY = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ADDRESS_PLACE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ADDRESS_PCODE = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    ADDRESS_TEXT = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_ADDRESS_REFERENCE_CLIENT",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENT",
                        principalColumn: "CLIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOSSIER",
                columns: table => new
                {
                    DOSSIER_NO = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENT_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    DOSSIER_YEAR = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    DOSSIER_STATUS = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    DOSSIER_MIN_BALANCE = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOSSIER", x => x.DOSSIER_NO);
                    table.ForeignKey(
                        name: "FK_DOSSIER_REFERENCE_CLIENT",
                        column: x => x.CLIENT_ID,
                        principalTable: "CLIENT",
                        principalColumn: "CLIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOSSIER_DETAILS",
                columns: table => new
                {
                    DD_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOSSIER_NO = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    INCEXP_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    DD_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    DD_VALUE = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DD_DOC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOSSIER_DETAILS", x => x.DD_ID);
                    table.ForeignKey(
                        name: "FK_DOSSIER__REFERENCE_DOSSIER",
                        column: x => x.DOSSIER_NO,
                        principalTable: "DOSSIER",
                        principalColumn: "DOSSIER_NO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOSSIER__REFERENCE_INCOME_E",
                        column: x => x.INCEXP_ID,
                        principalTable: "INCOME_EXPNECE",
                        principalColumn: "INCEXP_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_ADDRESS_UQ",
                table: "ADDRESS",
                columns: new[] { "CLIENT_ID", "ADDRESS_TYPE" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_CLIENT_UQ",
                table: "CLIENT",
                column: "CLIENT_EGN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_DOSSIER_UQ",
                table: "DOSSIER",
                columns: new[] { "CLIENT_ID", "DOSSIER_YEAR" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DOSSIER_DETAILS_DOSSIER_NO",
                table: "DOSSIER_DETAILS",
                column: "DOSSIER_NO");

            migrationBuilder.CreateIndex(
                name: "IX_DOSSIER_DETAILS_INCEXP_ID",
                table: "DOSSIER_DETAILS",
                column: "INCEXP_ID");

            migrationBuilder.CreateIndex(
                name: "IDX_INCOME_EXPENCE_UQ",
                table: "INCOME_EXPNECE",
                columns: new[] { "INCEXP_NAME", "INCEXP_TYPE" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "DOSSIER_DETAILS");

            migrationBuilder.DropTable(
                name: "DOSSIER");

            migrationBuilder.DropTable(
                name: "INCOME_EXPNECE");

            migrationBuilder.DropTable(
                name: "CLIENT");
        }
    }
}
