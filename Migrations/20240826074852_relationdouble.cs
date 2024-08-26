using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heroAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationdouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroPowers");

            migrationBuilder.CreateTable(
                name: "HeroPower",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    PowersPowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroPower", x => new { x.HeroId, x.PowersPowerId });
                    table.ForeignKey(
                        name: "FK_HeroPower_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroPower_Power_PowersPowerId",
                        column: x => x.PowersPowerId,
                        principalTable: "Power",
                        principalColumn: "PowerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroPower_PowersPowerId",
                table: "HeroPower",
                column: "PowersPowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroPower");

            migrationBuilder.CreateTable(
                name: "HeroPowers",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    PowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroPowers", x => new { x.HeroId, x.PowerId });
                    table.ForeignKey(
                        name: "FK_HeroPowers_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeroPowers_Power_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Power",
                        principalColumn: "PowerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroPowers_PowerId",
                table: "HeroPowers",
                column: "PowerId");
        }
    }
}
