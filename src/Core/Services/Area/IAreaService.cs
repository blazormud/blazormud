using System.Threading.Tasks;
using BlazorMUD.Core.Models.Area;

namespace BlazorMUD.Core.Services.Area
{
    public interface IAreaService
    {
        Task<AreaTemplate> CreateAsync(AreaTemplate area);
        Task<AreaTemplate> GetAsync(long id);
        Task<AreaTemplate> UpdateAsync(AreaTemplate area);
        Task DeleteAsync(AreaTemplate area);
        Task DeleteByIdAsync(long id);
    }
}
