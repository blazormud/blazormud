using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Data.Migrations
{
    public partial class UpdateLinkInstance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkInstances_AreaInstances_DestinationId",
                table: "LinkInstances");

            migrationBuilder.DropIndex(
                name: "IX_LinkInstances_DestinationId",
                table: "LinkInstances");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "LinkInstances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DestinationId",
                table: "LinkInstances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_DestinationId",
                table: "LinkInstances",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkInstances_AreaInstances_DestinationId",
                table: "LinkInstances",
                column: "DestinationId",
                principalTable: "AreaInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
