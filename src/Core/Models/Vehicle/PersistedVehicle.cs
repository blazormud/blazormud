using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class PersistedVehicle : IVehicle
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        [ForeignKey(nameof(ParentPersistedVehicle))]
        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;
    }

    public class PersistedVehicleEntityTypeConfiguration : IEntityTypeConfiguration<PersistedVehicle>
    {
        public void Configure(EntityTypeBuilder<PersistedVehicle> builder)
        {
            builder
                .HasOne(nameof(PersistedVehicle.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(PersistedVehicle.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedVehicle.ParentPersistedVehicle))
                .WithMany()
                .HasForeignKey(nameof(PersistedVehicle.ParentPersistedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
