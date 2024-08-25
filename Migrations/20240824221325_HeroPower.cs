using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heroAPI.Migrations
{
    /// <inheritdoc />
    public partial class HeroPower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Power_Hero_HeroId",
                table: "Power");

            migrationBuilder.DropIndex(
                name: "IX_Power_HeroId",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Power");

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroPowers_Power_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Power",
                        principalColumn: "PowerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroPowers_PowerId",
                table: "HeroPowers",
                column: "PowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroPowers");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Power",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Power_HeroId",
                table: "Power",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Power_Hero_HeroId",
                table: "Power",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
