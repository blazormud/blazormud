namespace BlazorMUD.Core.Models.Region
{
    public enum RegionType
    {
        /// <summary>
        /// A region with no special properties.
        /// </summary>
        Normal,
        /// <summary>
        /// A region containing areas that can be owned and controlled by players.
        /// </summary>
        Property,
        /// <summary>
        /// A region containing game objects that can be used in other regions.
        /// </summary>
        Library,
        /// <summary>
        /// A region containing game objects that can only be used by administrators.
        /// </summary>
        Admin
    }
}
