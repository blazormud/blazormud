using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Link;
using BlazorMUD.Core.Models.Vehicle;

namespace BlazorMUD.Core.Models.Region
{
    public class RegionTemplate
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        // [InverseProperty(nameof(AreaTemplate.Region))]
        // public IQueryable<AreaTemplate> Areas { get; set; } = null;

        // [InverseProperty(nameof(LinkTemplate.Region))]
        // public IQueryable<LinkTemplate> LinkTemplates { get; set; } = null;

        // [InverseProperty(nameof(PlacedLink.Region))]
        // public IQueryable<PlacedLink> PlacedLinks { get; set; } = null;

        // [InverseProperty(nameof(InstancedLink.Region))]
        // public IQueryable<InstancedLink> InstancedLinks { get; set; } = null;

        // [InverseProperty(nameof(VehicleTemplate.Region))]
        // public IQueryable<VehicleTemplate> VehicleTemplates { get; set; } = null;

        // [InverseProperty(nameof(PlacedVehicle.Region))]
        // public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;

        // [InverseProperty(nameof(InstancedVehicle.Region))]
        // public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;

        // [InverseProperty(nameof(ActorTemplate.Region))]
        // public IQueryable<ActorTemplate> ActorTemplates { get; set; } = null;

        // [InverseProperty(nameof(PlacedActor.Region))]
        // public IQueryable<PlacedActor> PlacedActors { get; set; } = null;

        // [InverseProperty(nameof(InstancedActor.Region))]
        // public IQueryable<InstancedActor> InstancedActors { get; set; } = null;

        // [InverseProperty(nameof(ItemTemplate.Region))]
        // public IQueryable<ItemTemplate> ItemTemplates { get; set; } = null;

        // [InverseProperty(nameof(PlacedItem.Region))]
        // public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        // [InverseProperty(nameof(InstancedItem.Region))]
        // public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        #endregion Relationship Properties
    }
}
