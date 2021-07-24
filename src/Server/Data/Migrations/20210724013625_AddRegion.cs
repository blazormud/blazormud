using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Data.Migrations
{
    public partial class AddRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "LinkTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "AreaTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkTemplates_RegionId",
                table: "LinkTemplates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaTemplates_RegionId",
                table: "AreaTemplates",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaTemplates_Regions_RegionId",
                table: "AreaTemplates",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTemplates_Regions_RegionId",
                table: "LinkTemplates",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaTemplates_Regions_RegionId",
                table: "AreaTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkTemplates_Regions_RegionId",
                table: "LinkTemplates");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_LinkTemplates_RegionId",
                table: "LinkTemplates");

            migrationBuilder.DropIndex(
                name: "IX_AreaTemplates_RegionId",
                table: "AreaTemplates");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "LinkTemplates");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "AreaTemplates");
        }
    }
}
