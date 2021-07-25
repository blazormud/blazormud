using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class VehicleTemplate
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [InverseProperty(nameof(PlacedVehicle.Template))]
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;

        [InverseProperty(nameof(InstancedVehicle.Template))]
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;

        [InverseProperty(nameof(PersistedVehicle.Template))]
        public IQueryable<PersistedVehicle> PersistedVehicles { get; set; } = null;

        #endregion Relationship Properties

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;
    }
}
