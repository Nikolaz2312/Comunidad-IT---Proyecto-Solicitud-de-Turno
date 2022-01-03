using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnoProyecto.Migrations
{
    public partial class turnoDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDb",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechadenacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDb", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "UserSDb",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechadenacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSDb", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "TurnoDb",
                columns: table => new
                {
                    turnoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aturno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fturno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoDb", x => x.turnoid);
                    table.ForeignKey(
                        name: "FK_TurnoDb_UserDb_userid",
                        column: x => x.userid,
                        principalTable: "UserDb",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignarDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    turnoid = table.Column<int>(type: "int", nullable: false),
                    UserModelDatosuserid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignarDB", x => x.id);
                    table.ForeignKey(
                        name: "FK_AsignarDB_TurnoDb_turnoid",
                        column: x => x.turnoid,
                        principalTable: "TurnoDb",
                        principalColumn: "turnoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignarDB_UserDb_UserModelDatosuserid",
                        column: x => x.UserModelDatosuserid,
                        principalTable: "UserDb",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "FK_AsignarDB_UserSDb_userid",
                        column: x => x.userid,
                        principalTable: "UserSDb",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NTurnoDb",
                columns: table => new
                {
                    Nturnoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponible = table.Column<int>(type: "int", nullable: false),
                    Ocupados = table.Column<int>(type: "int", nullable: false),
                    turnoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NTurnoDb", x => x.Nturnoid);
                    table.ForeignKey(
                        name: "FK_NTurnoDb_TurnoDb_turnoid",
                        column: x => x.turnoid,
                        principalTable: "TurnoDb",
                        principalColumn: "turnoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignarDB_turnoid",
                table: "AsignarDB",
                column: "turnoid");

            migrationBuilder.CreateIndex(
                name: "IX_AsignarDB_userid",
                table: "AsignarDB",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_AsignarDB_UserModelDatosuserid",
                table: "AsignarDB",
                column: "UserModelDatosuserid");

            migrationBuilder.CreateIndex(
                name: "IX_NTurnoDb_turnoid",
                table: "NTurnoDb",
                column: "turnoid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TurnoDb_userid",
                table: "TurnoDb",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignarDB");

            migrationBuilder.DropTable(
                name: "NTurnoDb");

            migrationBuilder.DropTable(
                name: "UserSDb");

            migrationBuilder.DropTable(
                name: "TurnoDb");

            migrationBuilder.DropTable(
                name: "UserDb");
        }
    }
}
