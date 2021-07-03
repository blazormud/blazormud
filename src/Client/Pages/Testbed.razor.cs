using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorMUD.Core;
using BlazorMUD.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorMUD.Client.Pages
{
    [Authorize]
    public partial class Testbed
    {
        [Inject]
        public HttpClient Http { get; set; }

        private IEnumerable<AreaTemplate> output;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //output = await Http.GetFromJsonAsync<string>("api/testbed/GetApplicationUser/ffc2d3f6-7389-41cc-9518-f2dd0da0b7f9");
                output = await Http.GetFromJsonAsync<IEnumerable<AreaTemplate>>("Testing");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
