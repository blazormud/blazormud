using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMUD.Server.Migrations
{
    public partial class AddCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorInstances_Areas_ParentAreaId",
                table: "ActorInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorInstances_PersistedVehicles_ParentPersistedVehicleId",
                table: "ActorInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ActorInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorPlacements_Areas_ParentAreaId",
                table: "ActorPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ActorPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_ActorInstances_ParentActorInstanceId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_Areas_ParentAreaId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_ItemInstances_ParentItemInstanceId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_ActorPlacements_ParentActorPlacementId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_Areas_ParentAreaId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_ItemPlacements_ParentItemPlacementId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedActors_Areas_ParentAreaId",
                table: "PersistedActors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedActors_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedActors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedActors_VehicleInstances_ParentVehicleInstanceId",
                table: "PersistedActors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_Areas_ParentAreaId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_PersistedActors_ParentPersistedActorId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_PersistedItems_ParentPersistedItemId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedVehicles_Areas_ParentAreaId",
                table: "PersistedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedVehicles_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInstances_Areas_ParentAreaId",
                table: "VehicleInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "VehicleInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlacements_Areas_ParentAreaId",
                table: "VehiclePlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "VehiclePlacements");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorInstances_Areas_ParentAreaId",
                table: "ActorInstances",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorInstances_PersistedVehicles_ParentPersistedVehicleId",
                table: "ActorInstances",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ActorInstances",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPlacements_Areas_ParentAreaId",
                table: "ActorPlacements",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ActorPlacements",
                column: "ParentVehiclePlacementId",
                principalTable: "VehiclePlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_ActorInstances_ParentActorInstanceId",
                table: "ItemInstances",
                column: "ParentActorInstanceId",
                principalTable: "ActorInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_Areas_ParentAreaId",
                table: "ItemInstances",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_ItemInstances_ParentItemInstanceId",
                table: "ItemInstances",
                column: "ParentItemInstanceId",
                principalTable: "ItemInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ItemInstances",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_ActorPlacements_ParentActorPlacementId",
                table: "ItemPlacements",
                column: "ParentActorPlacementId",
                principalTable: "ActorPlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_Areas_ParentAreaId",
                table: "ItemPlacements",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_ItemPlacements_ParentItemPlacementId",
                table: "ItemPlacements",
                column: "ParentItemPlacementId",
                principalTable: "ItemPlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ItemPlacements",
                column: "ParentVehiclePlacementId",
                principalTable: "VehiclePlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedActors_Areas_ParentAreaId",
                table: "PersistedActors",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedActors_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedActors",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedActors_VehicleInstances_ParentVehicleInstanceId",
                table: "PersistedActors",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_Areas_ParentAreaId",
                table: "PersistedItems",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_PersistedActors_ParentPersistedActorId",
                table: "PersistedItems",
                column: "ParentPersistedActorId",
                principalTable: "PersistedActors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_PersistedItems_ParentPersistedItemId",
                table: "PersistedItems",
                column: "ParentPersistedItemId",
                principalTable: "PersistedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedItems",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedVehicles_Areas_ParentAreaId",
                table: "PersistedVehicles",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedVehicles_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedVehicles",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInstances_Areas_ParentAreaId",
                table: "VehicleInstances",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "VehicleInstances",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlacements_Areas_ParentAreaId",
                table: "VehiclePlacements",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "VehiclePlacements",
                column: "ParentVehiclePlacementId",
                principalTable: "VehiclePlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorInstances_Areas_ParentAreaId",
                table: "ActorInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorInstances_PersistedVehicles_ParentPersistedVehicleId",
                table: "ActorInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ActorInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorPlacements_Areas_ParentAreaId",
                table: "ActorPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ActorPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_ActorInstances_ParentActorInstanceId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_Areas_ParentAreaId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_ItemInstances_ParentItemInstanceId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_ActorPlacements_ParentActorPlacementId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_Areas_ParentAreaId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_ItemPlacements_ParentItemPlacementId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ItemPlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedActors_Areas_ParentAreaId",
                table: "PersistedActors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedActors_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedActors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedActors_VehicleInstances_ParentVehicleInstanceId",
                table: "PersistedActors");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_Areas_ParentAreaId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_PersistedActors_ParentPersistedActorId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_PersistedItems_ParentPersistedItemId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedItems_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedVehicles_Areas_ParentAreaId",
                table: "PersistedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersistedVehicles_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInstances_Areas_ParentAreaId",
                table: "VehicleInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "VehicleInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlacements_Areas_ParentAreaId",
                table: "VehiclePlacements");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "VehiclePlacements");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorInstances_Areas_ParentAreaId",
                table: "ActorInstances",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorInstances_PersistedVehicles_ParentPersistedVehicleId",
                table: "ActorInstances",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ActorInstances",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPlacements_Areas_ParentAreaId",
                table: "ActorPlacements",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ActorPlacements",
                column: "ParentVehiclePlacementId",
                principalTable: "VehiclePlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_ActorInstances_ParentActorInstanceId",
                table: "ItemInstances",
                column: "ParentActorInstanceId",
                principalTable: "ActorInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_Areas_ParentAreaId",
                table: "ItemInstances",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_ItemInstances_ParentItemInstanceId",
                table: "ItemInstances",
                column: "ParentItemInstanceId",
                principalTable: "ItemInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "ItemInstances",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_ActorPlacements_ParentActorPlacementId",
                table: "ItemPlacements",
                column: "ParentActorPlacementId",
                principalTable: "ActorPlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_Areas_ParentAreaId",
                table: "ItemPlacements",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_ItemPlacements_ParentItemPlacementId",
                table: "ItemPlacements",
                column: "ParentItemPlacementId",
                principalTable: "ItemPlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "ItemPlacements",
                column: "ParentVehiclePlacementId",
                principalTable: "VehiclePlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedActors_Areas_ParentAreaId",
                table: "PersistedActors",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedActors_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedActors",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedActors_VehicleInstances_ParentVehicleInstanceId",
                table: "PersistedActors",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_Areas_ParentAreaId",
                table: "PersistedItems",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_PersistedActors_ParentPersistedActorId",
                table: "PersistedItems",
                column: "ParentPersistedActorId",
                principalTable: "PersistedActors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_PersistedItems_ParentPersistedItemId",
                table: "PersistedItems",
                column: "ParentPersistedItemId",
                principalTable: "PersistedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedItems_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedItems",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedVehicles_Areas_ParentAreaId",
                table: "PersistedVehicles",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersistedVehicles_PersistedVehicles_ParentPersistedVehicleId",
                table: "PersistedVehicles",
                column: "ParentPersistedVehicleId",
                principalTable: "PersistedVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInstances_Areas_ParentAreaId",
                table: "VehicleInstances",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInstances_VehicleInstances_ParentVehicleInstanceId",
                table: "VehicleInstances",
                column: "ParentVehicleInstanceId",
                principalTable: "VehicleInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlacements_Areas_ParentAreaId",
                table: "VehiclePlacements",
                column: "ParentAreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlacements_VehiclePlacements_ParentVehiclePlacementId",
                table: "VehiclePlacements",
                column: "ParentVehiclePlacementId",
                principalTable: "VehiclePlacements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
