using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Data.Migrations
{
    public partial class AddAreaTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaTemplateId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkTemplate_AreaTemplates_AreaTemplateId",
                        column: x => x.AreaTemplateId,
                        principalTable: "AreaTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkTemplate_AreaTemplateId",
                table: "LinkTemplate",
                column: "AreaTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkTemplate");

            migrationBuilder.DropTable(
                name: "AreaTemplates");
        }
    }
}
