using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetWebApiprojekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class swimmingpoolmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwimmingPools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingPools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwimmingTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    SwimmingPoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwimmingTracks_SwimmingPools_SwimmingPoolId",
                        column: x => x.SwimmingPoolId,
                        principalTable: "SwimmingPools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SwimmingTrackId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_SwimmingTracks_SwimmingTrackId",
                        column: x => x.SwimmingTrackId,
                        principalTable: "SwimmingTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SwimmingTrackId",
                table: "Reservations",
                column: "SwimmingTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_SwimmingTracks_SwimmingPoolId",
                table: "SwimmingTracks",
                column: "SwimmingPoolId");

            migrationBuilder.InsertData(table: "Clients", 
                columns: new string[] { "FirstName", "LastName", "Email" },
                values: new object[,] {
                    { "Jacinta", "Tonna", "jtonna0@businesswire.com" }, { "Sheppard", "Connold", "sconnold1@shop-pro.jp" }, { "Urban", "Grastye", "ugrastye2@omniture.com" }, { "Spence", "Ryves", "sryves3@reference.com" }, { "Jackie", "Schwander", "jschwander4@senate.gov" }, { "Dwayne", "Vlasenko", "dvlasenko5@economist.com" }, { "Enid", "Pipet", "epipet6@wufoo.com" }, { "Wildon", "Kettow", "wkettow7@cisco.com" }, { "Abramo", "Brickhill", "abrickhill8@ucoz.ru" }, { "Jsandye", "Peedell", "jpeedell9@tripadvisor.com" }, { "Malinde", "Parysiak", "mparysiaka@pinterest.com" }, { "Patrizius", "Bugge", "pbuggeb@smh.com.au" }, { "Nedi", "Bruni", "nbrunic@github.com" }, { "Ransell", "Featherstonhaugh", "rfeatherstonhaughd@fc2.com" }, { "Regina", "Utridge", "rutridgee@soup.io" }, { "Rhetta", "Connop", "rconnopf@homestead.com" }, { "Barbe", "Bugge", "bbuggeg@weibo.com" }, { "Ricki", "Imorts", "rimortsh@amazon.co.jp" }, { "Tomkin", "Praill", "tprailli@fema.gov" }, { "Marcelia", "Kummerlowe", "mkummerlowej@usda.gov" }, { "Nana", "Harbottle", "nharbottlek@nationalgeographic.com" }, { "Courtney", "Sagrott", "csagrottl@hugedomains.com" }, { "Paxon", "Fortman", "pfortmanm@springer.com" }, { "Morley", "Lacasa", "mlacasan@opera.com" }, { "Emelda", "Marfell", "emarfello@samsung.com" }
                });

            migrationBuilder.InsertData(table: "SwimmingPools",
                columns: new string[] { "Name", "Location" },
                values: new object[,] {
                    { "Korona", "Kraków" },
                    { "AGH Miasteczko", "Kraków" },
                    { "AWF", "Kraków" }
                });
            migrationBuilder.InsertData(table: "SwimmingTracks",
                columns: new string[] { "Name", "Length", "Capacity", "SwimmingPoolId" },
                values: new object[,] {
                    { "Tor 1", 25, 30, 1 },
                    { "Tor 2", 25, 45, 1 },
                    { "Tor 3", 25, 30, 1 },
                    { "Tor 4", 25, 15, 1 },

                    { "Tor 1", 50, 30, 2 },
                    { "Tor 2", 50, 45, 2 },
                    { "Tor 3", 50, 30, 2 },
                    { "Tor 4", 50, 15, 2 },

                    { "Tor 1", 50, 5, 3 },
                    { "Tor 2", 50, 6, 3 },
                    { "Tor 3", 50, 7, 3 },
                    { "Tor 4", 50, 8, 3 },
                });
            migrationBuilder.InsertData(table: "Reservations",
               columns: new string[] { "ClientId", "SwimmingTrackId", "Price", "StartTime", "EndTime" },
               values: new object[,] {
                    { 1, 1, 300, "2023-03-05 9:00", "2023-03-02 11:00" },
                    { 3, 6, 450, "2023-03-05 12:00", "2023-03-02 15:00" },
                    { 5, 8, 250, "2023-03-05 16:00", "2023-03-02 18:00" },
                    { 8, 10, 300, "2023-03-05 13:00", "2023-03-02 17:00" },
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SwimmingTracks");

            migrationBuilder.DropTable(
                name: "SwimmingPools");
        }
    }
}
