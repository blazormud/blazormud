using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Data.Migrations
{
    public partial class AddAreasAndLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTemplate_AreaTemplates_AreaTemplateId",
                table: "LinkTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkTemplate",
                table: "LinkTemplate");

            migrationBuilder.DropIndex(
                name: "IX_LinkTemplate_AreaTemplateId",
                table: "LinkTemplate");

            migrationBuilder.DropColumn(
                name: "AreaTemplateId",
                table: "LinkTemplate");

            migrationBuilder.RenameTable(
                name: "LinkTemplate",
                newName: "LinkTemplates");

            migrationBuilder.AddColumn<long>(
                name: "DestinationId",
                table: "LinkTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "LinkTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkTemplates",
                table: "LinkTemplates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AreaInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaInstances_AreaTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "AreaTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    SourceId = table.Column<long>(type: "INTEGER", nullable: false),
                    DestinationId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkInstances_AreaInstances_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "AreaInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkInstances_AreaInstances_SourceId",
                        column: x => x.SourceId,
                        principalTable: "AreaInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkInstances_LinkTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LinkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkTemplates_DestinationId",
                table: "LinkTemplates",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkTemplates_SourceId",
                table: "LinkTemplates",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaInstances_TemplateId",
                table: "AreaInstances",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_DestinationId",
                table: "LinkInstances",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_SourceId",
                table: "LinkInstances",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_TemplateId",
                table: "LinkInstances",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTemplates_AreaTemplates_DestinationId",
                table: "LinkTemplates",
                column: "DestinationId",
                principalTable: "AreaTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTemplates_AreaTemplates_SourceId",
                table: "LinkTemplates",
                column: "SourceId",
                principalTable: "AreaTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTemplates_AreaTemplates_DestinationId",
                table: "LinkTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkTemplates_AreaTemplates_SourceId",
                table: "LinkTemplates");

            migrationBuilder.DropTable(
                name: "LinkInstances");

            migrationBuilder.DropTable(
                name: "AreaInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkTemplates",
                table: "LinkTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LinkTemplates_DestinationId",
                table: "LinkTemplates");

            migrationBuilder.DropIndex(
                name: "IX_LinkTemplates_SourceId",
                table: "LinkTemplates");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "LinkTemplates");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "LinkTemplates");

            migrationBuilder.RenameTable(
                name: "LinkTemplates",
                newName: "LinkTemplate");

            migrationBuilder.AddColumn<long>(
                name: "AreaTemplateId",
                table: "LinkTemplate",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkTemplate",
                table: "LinkTemplate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LinkTemplate_AreaTemplateId",
                table: "LinkTemplate",
                column: "AreaTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTemplate_AreaTemplates_AreaTemplateId",
                table: "LinkTemplate",
                column: "AreaTemplateId",
                principalTable: "AreaTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
