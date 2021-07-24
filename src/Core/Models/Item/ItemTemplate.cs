using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Item
{
    public class ItemTemplate
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        public ItemStaticFlags StaticFlags { get; set; }
        public ItemDynamicFlags DynamicFlags { get; set; }
        public ItemWearFlags WearFlags { get; set; }
    }
}
