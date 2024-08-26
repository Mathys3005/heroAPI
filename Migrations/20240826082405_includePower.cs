using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heroAPI.Migrations
{
    /// <inheritdoc />
    public partial class includePower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroPower_Hero_HeroId",
                table: "HeroPower");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroPower_Power_PowersPowerId",
                table: "HeroPower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroPower",
                table: "HeroPower");

            migrationBuilder.RenameTable(
                name: "HeroPower",
                newName: "HeroPowers");

            migrationBuilder.RenameIndex(
                name: "IX_HeroPower_PowersPowerId",
                table: "HeroPowers",
                newName: "IX_HeroPowers_PowersPowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroPowers",
                table: "HeroPowers",
                columns: new[] { "HeroId", "PowersPowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPowers_Hero_HeroId",
                table: "HeroPowers",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPowers_Power_PowersPowerId",
                table: "HeroPowers",
                column: "PowersPowerId",
                principalTable: "Power",
                principalColumn: "PowerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroPowers_Hero_HeroId",
                table: "HeroPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroPowers_Power_PowersPowerId",
                table: "HeroPowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroPowers",
                table: "HeroPowers");

            migrationBuilder.RenameTable(
                name: "HeroPowers",
                newName: "HeroPower");

            migrationBuilder.RenameIndex(
                name: "IX_HeroPowers_PowersPowerId",
                table: "HeroPower",
                newName: "IX_HeroPower_PowersPowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroPower",
                table: "HeroPower",
                columns: new[] { "HeroId", "PowersPowerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPower_Hero_HeroId",
                table: "HeroPower",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPower_Power_PowersPowerId",
                table: "HeroPower",
                column: "PowersPowerId",
                principalTable: "Power",
                principalColumn: "PowerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
