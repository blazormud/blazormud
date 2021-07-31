using System;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorMUD.Core.Services.Area
{
    public class AreaService : IAreaService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AreaService> _logger;

        public AreaService(ApplicationDbContext context, ILogger<AreaService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AreaTemplate> CreateAsync(AreaTemplate area)
        {
            _logger.LogDebug($"Creating Area\n{area.ToJsonLog()}");
            var trackedArea = await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
            return trackedArea.Entity;
        }

        public async Task<AreaTemplate> GetAsync(long id)
        {
            return await _context.Areas
                // .Include((area) => area.PersistedLinks)
                // .ThenInclude((link) => link.DestinationArea)
                // .ThenInclude((area) => area.InstancedActors)
                .FirstOrDefaultAsync(area => area.Id == id);
        }

        public async Task<AreaTemplate> UpdateAsync(AreaTemplate area)
        {
            _logger.LogDebug($"Updating Area\n{area.ToJsonLog()}");
            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
            return area;
        }

        public async Task DeleteAsync(AreaTemplate area)
        {
            _logger.LogDebug($"Deleting Area\n{area.ToJsonLog()}");
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            _logger.LogDebug($"Deleting Area {id}");
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                throw new ArgumentException("Area id does not exist.");
            }
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }
    }
}
