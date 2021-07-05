using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorMUD.Client.Shared.Layouts
{
    public partial class AdminLayout
    {
        public string Test(object context) => JsonSerializer.Serialize(context);
        //public string Test => JsonSerializer.Serialize(context);
    }
}
