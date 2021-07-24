using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorMUD.Client.Pages.Test
{
    [Authorize]
    public partial class Testbed
    {
        [Inject]
        public HttpClient Http { get; set; }

        //private IEnumerable<AreaTemplate> output;

        //public AreaInstance Area { get; set; }

        // protected override async Task OnInitializedAsync()
        // {
        //     try
        //     {
        //         //output = await Http.GetFromJsonAsync<IEnumerable<AreaTemplate>>("testing");
        //         //Area = await Http.GetFromJsonAsync<AreaInstance>("area");
        //     }
        //     catch (AccessTokenNotAvailableException exception)
        //     {
        //         exception.Redirect();
        //     }
        // }
    }
}
