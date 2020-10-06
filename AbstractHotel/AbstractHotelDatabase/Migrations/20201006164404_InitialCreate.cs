using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbstractHotelDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: false),
                    ClientLastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lunches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeLunch = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomsType = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Сonferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    СonferenceName = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    DataCreate = table.Column<DateTime>(nullable: false),
                    isReserved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сonferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сonferences_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestLunches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    LunchId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLunches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestLunches_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestLunches_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LunchRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LunchId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LunchRooms_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsСonferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    СonferenceId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    RoomsType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsСonferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsСonferences_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsСonferences_Сonferences_СonferenceId",
                        column: x => x.СonferenceId,
                        principalTable: "Сonferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LunchRooms_LunchId",
                table: "LunchRooms",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchRooms_RoomId",
                table: "LunchRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLunches_LunchId",
                table: "RequestLunches",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLunches_RequestId",
                table: "RequestLunches",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsСonferences_RoomId",
                table: "RoomsСonferences",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsСonferences_СonferenceId",
                table: "RoomsСonferences",
                column: "СonferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Сonferences_ClientId",
                table: "Сonferences",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunchRooms");

            migrationBuilder.DropTable(
                name: "RequestLunches");

            migrationBuilder.DropTable(
                name: "RoomsСonferences");

            migrationBuilder.DropTable(
                name: "Lunches");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Сonferences");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
