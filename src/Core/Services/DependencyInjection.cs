using BlazorMUD.Core.Services.Area;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMUD.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBlazorMudServices(this IServiceCollection @this)
        {
            return @this
                .AddScoped<IAreaService, AreaService>();
        }
    }
}
