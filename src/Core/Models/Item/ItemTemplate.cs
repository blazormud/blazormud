using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Item
{
    public class ItemTemplate
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [InverseProperty(nameof(PlacedItem.Template))]
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        [InverseProperty(nameof(InstancedItem.Template))]
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        [InverseProperty(nameof(PersistedItem.Template))]
        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }
}
