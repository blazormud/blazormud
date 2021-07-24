using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class VehicleTemplate
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        public VehicleStaticFlags StaticFlags { get; set; }
        public VehicleDynamicFlags DynamicFlags { get; set; }
    }
}
