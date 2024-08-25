using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heroAPI.Migrations
{
    /// <inheritdoc />
    public partial class heroservice3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroPowers_Hero_HeroId",
                table: "HeroPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroPowers_Power_PowerId",
                table: "HeroPowers");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPowers_Hero_HeroId",
                table: "HeroPowers",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPowers_Power_PowerId",
                table: "HeroPowers",
                column: "PowerId",
                principalTable: "Power",
                principalColumn: "PowerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroPowers_Hero_HeroId",
                table: "HeroPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroPowers_Power_PowerId",
                table: "HeroPowers");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPowers_Hero_HeroId",
                table: "HeroPowers",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "HeroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroPowers_Power_PowerId",
                table: "HeroPowers",
                column: "PowerId",
                principalTable: "Power",
                principalColumn: "PowerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
