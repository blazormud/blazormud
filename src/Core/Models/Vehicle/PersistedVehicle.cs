using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class PersistedVehicle : IVehicle
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentPersistedVehicle")]
        public long? ParentPersistedVehicleId { get; set; }
        public PersistedVehicle ParentPersistedVehicle { get; set; }

        public VehicleStaticFlags StaticFlags { get; set; }
        public VehicleDynamicFlags DynamicFlags { get; set; }
    }
}
