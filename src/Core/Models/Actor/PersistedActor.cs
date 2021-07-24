using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Vehicle;

namespace BlazorMUD.Core.Models.Actor
{
    public class PersistedActor : IActor
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentVehicleInstance")]
        public long? ParentVehicleInstanceId { get; set; }
        public VehicleInstance ParentVehicleInstance { get; set; }

        [ForeignKey("ParentPersistedVehicle")]
        public long? ParentPersistedVehicleId { get; set; }
        public PersistedVehicle ParentPersistedVehicle { get; set; }

        public ActorStaticFlags StaticFlags { get; set; }
        public ActorDynamicFlags DynamicFlags { get; set; }
    }
}
