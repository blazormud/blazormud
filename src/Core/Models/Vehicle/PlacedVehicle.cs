using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class PlacedVehicle
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public VehicleTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        [ForeignKey(nameof(ParentPlacedVehicle))]
        public long? ParentPlacedVehicleId { get; set; } = null;
        public PlacedVehicle ParentPlacedVehicle { get; set; } = null;

        [InverseProperty(nameof(ParentPlacedVehicle))]
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;

        [InverseProperty(nameof(PlacedActor.ParentPlacedVehicle))]
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;

        [InverseProperty(nameof(PlacedItem.ParentPlacedVehicle))]
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        #endregion Relationship Properties

        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;

        public int Count { get; set; }
    }

    public class VehiclePlacementEntityTypeConfiguration : IEntityTypeConfiguration<PlacedVehicle>
    {
        public void Configure(EntityTypeBuilder<PlacedVehicle> builder)
        {
            builder
                .HasOne(nameof(PlacedVehicle.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(PlacedVehicle.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PlacedVehicle.ParentPlacedVehicle))
                .WithMany()
                .HasForeignKey(nameof(PlacedVehicle.ParentPlacedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
