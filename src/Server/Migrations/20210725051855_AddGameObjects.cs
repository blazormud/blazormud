using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Migrations
{
    public partial class AddGameObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorTemplates_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    Flags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    WearFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTemplates_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkTemplates_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTemplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTemplates_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersistedVehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersistedVehicles_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedVehicles_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedVehicles_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstancedLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: false),
                    DestinationAreaId = table.Column<long>(type: "INTEGER", nullable: false),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstancedLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstancedLinks_Areas_DestinationAreaId",
                        column: x => x.DestinationAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedLinks_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedLinks_LinkTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LinkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedLinks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersistedLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: false),
                    DestinationAreaId = table.Column<long>(type: "INTEGER", nullable: false),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersistedLinks_Areas_DestinationAreaId",
                        column: x => x.DestinationAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedLinks_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedLinks_LinkTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LinkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacedLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: false),
                    DestinationAreaId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacedLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacedLinks_Areas_DestinationAreaId",
                        column: x => x.DestinationAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedLinks_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedLinks_LinkTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LinkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedLinks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstancedVehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentInstancedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstancedVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstancedVehicles_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedVehicles_InstancedVehicles_ParentInstancedVehicleId",
                        column: x => x.ParentInstancedVehicleId,
                        principalTable: "InstancedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedVehicles_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedVehicles_VehicleTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "VehicleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacedVehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPlacedVehicleId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacedVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacedVehicles_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedVehicles_PlacedVehicles_ParentPlacedVehicleId",
                        column: x => x.ParentPlacedVehicleId,
                        principalTable: "PlacedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedVehicles_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedVehicles_VehicleTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "VehicleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstancedActors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentInstancedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstancedActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstancedActors_ActorTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ActorTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedActors_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedActors_InstancedVehicles_ParentInstancedVehicleId",
                        column: x => x.ParentInstancedVehicleId,
                        principalTable: "InstancedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedActors_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedActors_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersistedActors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentInstancedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersistedActors_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedActors_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedActors_InstancedVehicles_ParentInstancedVehicleId",
                        column: x => x.ParentInstancedVehicleId,
                        principalTable: "InstancedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedActors_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacedActors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPlacedVehicleId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacedActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacedActors_ActorTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ActorTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedActors_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedActors_PlacedVehicles_ParentPlacedVehicleId",
                        column: x => x.ParentPlacedVehicleId,
                        principalTable: "PlacedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedActors_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstancedItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentInstancedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentInstancedActorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentInstancedItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    WearFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstancedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstancedItems_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedItems_InstancedActors_ParentInstancedActorId",
                        column: x => x.ParentInstancedActorId,
                        principalTable: "InstancedActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedItems_InstancedItems_ParentInstancedItemId",
                        column: x => x.ParentInstancedItemId,
                        principalTable: "InstancedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedItems_InstancedVehicles_ParentInstancedVehicleId",
                        column: x => x.ParentInstancedVehicleId,
                        principalTable: "InstancedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedItems_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstancedItems_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersistedItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedActorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    WearFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersistedItems_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedItems_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedItems_PersistedActors_ParentPersistedActorId",
                        column: x => x.ParentPersistedActorId,
                        principalTable: "PersistedActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedItems_PersistedItems_ParentPersistedItemId",
                        column: x => x.ParentPersistedItemId,
                        principalTable: "PersistedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedItems_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacedItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPlacedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPlacedActorId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPlacedItemId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacedItems_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedItems_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedItems_PlacedActors_ParentPlacedActorId",
                        column: x => x.ParentPlacedActorId,
                        principalTable: "PlacedActors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedItems_PlacedItems_ParentPlacedItemId",
                        column: x => x.ParentPlacedItemId,
                        principalTable: "PlacedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedItems_PlacedVehicles_ParentPlacedVehicleId",
                        column: x => x.ParentPlacedVehicleId,
                        principalTable: "PlacedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlacedItems_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorTemplates_RegionId",
                table: "ActorTemplates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_RegionId",
                table: "Areas",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedActors_ParentAreaId",
                table: "InstancedActors",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedActors_ParentInstancedVehicleId",
                table: "InstancedActors",
                column: "ParentInstancedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedActors_ParentPersistedVehicleId",
                table: "InstancedActors",
                column: "ParentPersistedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedActors_RegionId",
                table: "InstancedActors",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedActors_TemplateId",
                table: "InstancedActors",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedItems_ParentAreaId",
                table: "InstancedItems",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedItems_ParentInstancedActorId",
                table: "InstancedItems",
                column: "ParentInstancedActorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedItems_ParentInstancedItemId",
                table: "InstancedItems",
                column: "ParentInstancedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedItems_ParentInstancedVehicleId",
                table: "InstancedItems",
                column: "ParentInstancedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedItems_RegionId",
                table: "InstancedItems",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedItems_TemplateId",
                table: "InstancedItems",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedLinks_DestinationAreaId",
                table: "InstancedLinks",
                column: "DestinationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedLinks_ParentAreaId",
                table: "InstancedLinks",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedLinks_RegionId",
                table: "InstancedLinks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedLinks_TemplateId",
                table: "InstancedLinks",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedVehicles_ParentAreaId",
                table: "InstancedVehicles",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedVehicles_ParentInstancedVehicleId",
                table: "InstancedVehicles",
                column: "ParentInstancedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedVehicles_RegionId",
                table: "InstancedVehicles",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstancedVehicles_TemplateId",
                table: "InstancedVehicles",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_RegionId",
                table: "ItemTemplates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkTemplates_RegionId",
                table: "LinkTemplates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedActors_OwnerId",
                table: "PersistedActors",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedActors_ParentAreaId",
                table: "PersistedActors",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedActors_ParentInstancedVehicleId",
                table: "PersistedActors",
                column: "ParentInstancedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedActors_ParentPersistedVehicleId",
                table: "PersistedActors",
                column: "ParentPersistedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedItems_ParentAreaId",
                table: "PersistedItems",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedItems_ParentPersistedActorId",
                table: "PersistedItems",
                column: "ParentPersistedActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedItems_ParentPersistedItemId",
                table: "PersistedItems",
                column: "ParentPersistedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedItems_ParentPersistedVehicleId",
                table: "PersistedItems",
                column: "ParentPersistedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedItems_TemplateId",
                table: "PersistedItems",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedLinks_DestinationAreaId",
                table: "PersistedLinks",
                column: "DestinationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedLinks_ParentAreaId",
                table: "PersistedLinks",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedLinks_TemplateId",
                table: "PersistedLinks",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedVehicles_OwnerId",
                table: "PersistedVehicles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedVehicles_ParentAreaId",
                table: "PersistedVehicles",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedVehicles",
                column: "ParentPersistedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedActors_ParentAreaId",
                table: "PlacedActors",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedActors_ParentPlacedVehicleId",
                table: "PlacedActors",
                column: "ParentPlacedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedActors_RegionId",
                table: "PlacedActors",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedActors_TemplateId",
                table: "PlacedActors",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedItems_ParentAreaId",
                table: "PlacedItems",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedItems_ParentPlacedActorId",
                table: "PlacedItems",
                column: "ParentPlacedActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedItems_ParentPlacedItemId",
                table: "PlacedItems",
                column: "ParentPlacedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedItems_ParentPlacedVehicleId",
                table: "PlacedItems",
                column: "ParentPlacedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedItems_RegionId",
                table: "PlacedItems",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedItems_TemplateId",
                table: "PlacedItems",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedLinks_DestinationAreaId",
                table: "PlacedLinks",
                column: "DestinationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedLinks_ParentAreaId",
                table: "PlacedLinks",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedLinks_RegionId",
                table: "PlacedLinks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedLinks_TemplateId",
                table: "PlacedLinks",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedVehicles_ParentAreaId",
                table: "PlacedVehicles",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedVehicles_ParentPlacedVehicleId",
                table: "PlacedVehicles",
                column: "ParentPlacedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedVehicles_RegionId",
                table: "PlacedVehicles",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacedVehicles_TemplateId",
                table: "PlacedVehicles",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTemplates_RegionId",
                table: "VehicleTemplates",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstancedItems");

            migrationBuilder.DropTable(
                name: "InstancedLinks");

            migrationBuilder.DropTable(
                name: "PersistedItems");

            migrationBuilder.DropTable(
                name: "PersistedLinks");

            migrationBuilder.DropTable(
                name: "PlacedItems");

            migrationBuilder.DropTable(
                name: "PlacedLinks");

            migrationBuilder.DropTable(
                name: "InstancedActors");

            migrationBuilder.DropTable(
                name: "PersistedActors");

            migrationBuilder.DropTable(
                name: "ItemTemplates");

            migrationBuilder.DropTable(
                name: "PlacedActors");

            migrationBuilder.DropTable(
                name: "LinkTemplates");

            migrationBuilder.DropTable(
                name: "InstancedVehicles");

            migrationBuilder.DropTable(
                name: "PersistedVehicles");

            migrationBuilder.DropTable(
                name: "ActorTemplates");

            migrationBuilder.DropTable(
                name: "PlacedVehicles");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "VehicleTemplates");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
