using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace BlazorMUD.Client.Shared.Layouts
{
    [Authorize(Roles = "Builder,Admin,Owner")]
    public partial class BuildLayout
    {
        public string Test(object context) => JsonSerializer.Serialize(context);
        //public string Test => JsonSerializer.Serialize(context);
    }
}
