using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbstractHotelDatabaseImplement.Migrations
{
    public partial class client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomsСonferences");

            migrationBuilder.DropColumn(
                name: "DataCreate",
                table: "Сonferences");

            migrationBuilder.DropColumn(
                name: "isReserved",
                table: "Сonferences");

            migrationBuilder.DropColumn(
                name: "СonferenceName",
                table: "Сonferences");

            migrationBuilder.DropColumn(
                name: "ClientLastName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Сonferences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ClientFIO",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "СonferenceRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    RoomsType = table.Column<string>(nullable: true),
                    СonferenceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_СonferenceRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_СonferenceRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_СonferenceRooms_Сonferences_СonferenceId",
                        column: x => x.СonferenceId,
                        principalTable: "Сonferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_СonferenceRooms_RoomId",
                table: "СonferenceRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_СonferenceRooms_СonferenceId",
                table: "СonferenceRooms",
                column: "СonferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СonferenceRooms");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Сonferences");

            migrationBuilder.DropColumn(
                name: "ClientFIO",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCreate",
                table: "Сonferences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isReserved",
                table: "Сonferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "СonferenceName",
                table: "Сonferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientLastName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoomsСonferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    СonferenceId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_RoomsСonferences_RoomId",
                table: "RoomsСonferences",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsСonferences_СonferenceId",
                table: "RoomsСonferences",
                column: "СonferenceId");
        }
    }
}
