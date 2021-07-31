using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Migrations
{
    public partial class AddAreaRegionDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "Flags",
                table: "Regions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Regions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Regions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Regions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Areas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Areas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Article",
                table: "ActorTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "ActorTemplates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ActorTemplates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ActorTemplates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nouns",
                table: "ActorTemplates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "ActorTemplates",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flags",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Article",
                table: "ActorTemplates");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "ActorTemplates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ActorTemplates");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ActorTemplates");

            migrationBuilder.DropColumn(
                name: "Nouns",
                table: "ActorTemplates");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "ActorTemplates");
        }
    }
}
