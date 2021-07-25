using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Migrations
{
    public partial class AddDynamicPlacedFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "PlacedVehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<ulong>(
                name: "DynamicFlags",
                table: "PlacedVehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "DynamicFlags",
                table: "PlacedLinks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "PlacedItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<ulong>(
                name: "DynamicFlags",
                table: "PlacedItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "PlacedActors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<ulong>(
                name: "DynamicFlags",
                table: "PlacedActors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<long>(
                name: "TemplateId",
                table: "PersistedVehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PersistedVehicles_TemplateId",
                table: "PersistedVehicles",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedVehicles_VehicleTemplates_TemplateId",
                table: "PersistedVehicles",
                column: "TemplateId",
                principalTable: "VehicleTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersistedVehicles_VehicleTemplates_TemplateId",
                table: "PersistedVehicles");

            migrationBuilder.DropIndex(
                name: "IX_PersistedVehicles_TemplateId",
                table: "PersistedVehicles");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "PlacedVehicles");

            migrationBuilder.DropColumn(
                name: "DynamicFlags",
                table: "PlacedVehicles");

            migrationBuilder.DropColumn(
                name: "DynamicFlags",
                table: "PlacedLinks");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "PlacedItems");

            migrationBuilder.DropColumn(
                name: "DynamicFlags",
                table: "PlacedItems");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "PlacedActors");

            migrationBuilder.DropColumn(
                name: "DynamicFlags",
                table: "PlacedActors");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "PersistedVehicles");
        }
    }
}
