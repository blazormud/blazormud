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
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkInstances",
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
                    table.PrimaryKey("PK_LinkInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkInstances_Areas_DestinationAreaId",
                        column: x => x.DestinationAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkInstances_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkInstances_LinkTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LinkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkInstances_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPlacements",
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
                    table.PrimaryKey("PK_LinkPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkPlacements_Areas_DestinationAreaId",
                        column: x => x.DestinationAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPlacements_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPlacements_LinkTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LinkTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPlacements_Regions_RegionId",
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
                name: "VehicleInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehicleInstanceId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleInstances_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleInstances_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleInstances_VehicleInstances_ParentVehicleInstanceId",
                        column: x => x.ParentVehicleInstanceId,
                        principalTable: "VehicleInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleInstances_VehicleTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "VehicleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePlacements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehiclePlacementId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePlacements_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiclePlacements_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePlacements_VehiclePlacements_ParentVehiclePlacementId",
                        column: x => x.ParentVehiclePlacementId,
                        principalTable: "VehiclePlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiclePlacements_VehicleTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "VehicleTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehicleInstanceId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentPersistedVehicleId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorInstances_ActorTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ActorTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorInstances_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorInstances_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorInstances_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorInstances_VehicleInstances_ParentVehicleInstanceId",
                        column: x => x.ParentVehicleInstanceId,
                        principalTable: "VehicleInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersistedActors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehicleInstanceId = table.Column<long>(type: "INTEGER", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersistedActors_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersistedActors_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersistedActors_VehicleInstances_ParentVehicleInstanceId",
                        column: x => x.ParentVehicleInstanceId,
                        principalTable: "VehicleInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActorPlacements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehiclePlacementId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorPlacements_ActorTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ActorTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorPlacements_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorPlacements_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorPlacements_VehiclePlacements_ParentVehiclePlacementId",
                        column: x => x.ParentVehiclePlacementId,
                        principalTable: "VehiclePlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemInstances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehicleInstanceId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentActorInstanceId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentItemInstanceId = table.Column<long>(type: "INTEGER", nullable: true),
                    StaticFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DynamicFlags = table.Column<ulong>(type: "INTEGER", nullable: false),
                    WearFlags = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInstances_ActorInstances_ParentActorInstanceId",
                        column: x => x.ParentActorInstanceId,
                        principalTable: "ActorInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemInstances_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemInstances_ItemInstances_ParentItemInstanceId",
                        column: x => x.ParentItemInstanceId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemInstances_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInstances_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInstances_VehicleInstances_ParentVehicleInstanceId",
                        column: x => x.ParentVehicleInstanceId,
                        principalTable: "VehicleInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersistedItems_PersistedItems_ParentPersistedItemId",
                        column: x => x.ParentPersistedItemId,
                        principalTable: "PersistedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersistedItems_PersistedVehicles_ParentPersistedVehicleId",
                        column: x => x.ParentPersistedVehicleId,
                        principalTable: "PersistedVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPlacements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionId = table.Column<long>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentAreaId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentVehiclePlacementId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentActorPlacementId = table.Column<long>(type: "INTEGER", nullable: true),
                    ParentItemPlacementId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPlacements_ActorPlacements_ParentActorPlacementId",
                        column: x => x.ParentActorPlacementId,
                        principalTable: "ActorPlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPlacements_Areas_ParentAreaId",
                        column: x => x.ParentAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPlacements_ItemPlacements_ParentItemPlacementId",
                        column: x => x.ParentItemPlacementId,
                        principalTable: "ItemPlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPlacements_ItemTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPlacements_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPlacements_VehiclePlacements_ParentVehiclePlacementId",
                        column: x => x.ParentVehiclePlacementId,
                        principalTable: "VehiclePlacements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorInstances_ParentAreaId",
                table: "ActorInstances",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorInstances_ParentPersistedVehicleId",
                table: "ActorInstances",
                column: "ParentPersistedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorInstances_ParentVehicleInstanceId",
                table: "ActorInstances",
                column: "ParentVehicleInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorInstances_RegionId",
                table: "ActorInstances",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorInstances_TemplateId",
                table: "ActorInstances",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorPlacements_ParentAreaId",
                table: "ActorPlacements",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorPlacements_ParentVehiclePlacementId",
                table: "ActorPlacements",
                column: "ParentVehiclePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorPlacements_RegionId",
                table: "ActorPlacements",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorPlacements_TemplateId",
                table: "ActorPlacements",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorTemplates_RegionId",
                table: "ActorTemplates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_RegionId",
                table: "Areas",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ParentActorInstanceId",
                table: "ItemInstances",
                column: "ParentActorInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ParentAreaId",
                table: "ItemInstances",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ParentItemInstanceId",
                table: "ItemInstances",
                column: "ParentItemInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ParentVehicleInstanceId",
                table: "ItemInstances",
                column: "ParentVehicleInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_RegionId",
                table: "ItemInstances",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_TemplateId",
                table: "ItemInstances",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlacements_ParentActorPlacementId",
                table: "ItemPlacements",
                column: "ParentActorPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlacements_ParentAreaId",
                table: "ItemPlacements",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlacements_ParentItemPlacementId",
                table: "ItemPlacements",
                column: "ParentItemPlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlacements_ParentVehiclePlacementId",
                table: "ItemPlacements",
                column: "ParentVehiclePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlacements_RegionId",
                table: "ItemPlacements",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlacements_TemplateId",
                table: "ItemPlacements",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_RegionId",
                table: "ItemTemplates",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_DestinationAreaId",
                table: "LinkInstances",
                column: "DestinationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_ParentAreaId",
                table: "LinkInstances",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_RegionId",
                table: "LinkInstances",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkInstances_TemplateId",
                table: "LinkInstances",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPlacements_DestinationAreaId",
                table: "LinkPlacements",
                column: "DestinationAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPlacements_ParentAreaId",
                table: "LinkPlacements",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPlacements_RegionId",
                table: "LinkPlacements",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPlacements_TemplateId",
                table: "LinkPlacements",
                column: "TemplateId");

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
                name: "IX_PersistedActors_ParentPersistedVehicleId",
                table: "PersistedActors",
                column: "ParentPersistedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedActors_ParentVehicleInstanceId",
                table: "PersistedActors",
                column: "ParentVehicleInstanceId");

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
                name: "IX_VehicleInstances_ParentAreaId",
                table: "VehicleInstances",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInstances_ParentVehicleInstanceId",
                table: "VehicleInstances",
                column: "ParentVehicleInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInstances_RegionId",
                table: "VehicleInstances",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInstances_TemplateId",
                table: "VehicleInstances",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlacements_ParentAreaId",
                table: "VehiclePlacements",
                column: "ParentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlacements_ParentVehiclePlacementId",
                table: "VehiclePlacements",
                column: "ParentVehiclePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlacements_RegionId",
                table: "VehiclePlacements",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlacements_TemplateId",
                table: "VehiclePlacements",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTemplates_RegionId",
                table: "VehicleTemplates",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemInstances");

            migrationBuilder.DropTable(
                name: "ItemPlacements");

            migrationBuilder.DropTable(
                name: "LinkInstances");

            migrationBuilder.DropTable(
                name: "LinkPlacements");

            migrationBuilder.DropTable(
                name: "PersistedItems");

            migrationBuilder.DropTable(
                name: "PersistedLinks");

            migrationBuilder.DropTable(
                name: "ActorInstances");

            migrationBuilder.DropTable(
                name: "ActorPlacements");

            migrationBuilder.DropTable(
                name: "ItemTemplates");

            migrationBuilder.DropTable(
                name: "PersistedActors");

            migrationBuilder.DropTable(
                name: "LinkTemplates");

            migrationBuilder.DropTable(
                name: "ActorTemplates");

            migrationBuilder.DropTable(
                name: "VehiclePlacements");

            migrationBuilder.DropTable(
                name: "PersistedVehicles");

            migrationBuilder.DropTable(
                name: "VehicleInstances");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "VehicleTemplates");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
