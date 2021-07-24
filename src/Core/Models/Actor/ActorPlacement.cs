using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;

namespace BlazorMUD.Core.Models.Actor
{
    public class ActorPlacement
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public ActorTemplate Template { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentVehiclePlacement")]
        public long? ParentVehiclePlacementId { get; set; }
        public VehiclePlacement ParentVehiclePlacement { get; set; }
    }
}
