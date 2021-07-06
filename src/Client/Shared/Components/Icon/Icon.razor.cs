using Microsoft.AspNetCore.Components;

namespace BlazorMUD.Client.Shared.Components.Icon
{
    public partial class Icon
    {
        [Parameter]
        public string MaterialIcon { get; set; } = "";
        [Parameter]
        public string GameIcon { get; set; } = "";
        [Parameter]
        public string SizeInRem { get; set; } = "";

        protected string BlockSize => SizeInRem + "rem";
        protected MarkupString GameIconHex => (MarkupString)IconMapper.NameToGameIconUnicode(GameIcon);
    }
}
