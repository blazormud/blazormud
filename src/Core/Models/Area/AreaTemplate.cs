using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Link;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;

namespace BlazorMUD.Core.Models.Area
{
    public class AreaTemplate
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [InverseProperty(nameof(PlacedLink.ParentArea))]
        public IQueryable<PlacedLink> PlacedLinks { get; set; } = null;

        [InverseProperty(nameof(PlacedLink.DestinationArea))]
        public IQueryable<PlacedLink> DestinationPlacedLinks { get; set; } = null;

        [InverseProperty(nameof(InstancedLink.ParentArea))]
        public IQueryable<InstancedLink> InstancedLinks { get; set; } = null;

        [InverseProperty(nameof(InstancedLink.DestinationArea))]
        public IQueryable<InstancedLink> DestinationInstancedLinks { get; set; } = null;

        [InverseProperty(nameof(PersistedLink.ParentArea))]
        public IQueryable<PersistedLink> PersistedLinks { get; set; } = null;

        [InverseProperty(nameof(PersistedLink.DestinationArea))]
        public IQueryable<PersistedLink> DestinationPersistedLinks { get; set; } = null;

        [InverseProperty(nameof(PlacedVehicle.ParentArea))]
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;

        [InverseProperty(nameof(InstancedVehicle.ParentArea))]
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;

        [InverseProperty(nameof(PersistedVehicle.ParentArea))]
        public IQueryable<PersistedVehicle> PersistedVehicles { get; set; } = null;

        [InverseProperty(nameof(PlacedActor.ParentArea))]
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;

        [InverseProperty(nameof(InstancedActor.ParentArea))]
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;

        [InverseProperty(nameof(PersistedActor.ParentArea))]
        public IQueryable<PersistedActor> PersistedActors { get; set; } = null;

        [InverseProperty(nameof(PlacedItem.ParentArea))]
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        [InverseProperty(nameof(InstancedItem.ParentArea))]
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        [InverseProperty(nameof(PersistedItem.ParentArea))]
        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public AreaFlags Flags { get; set; } = AreaFlags.None;
    }
}
