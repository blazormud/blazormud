using System;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Data;
using BlazorMUD.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorMUD.Server.Services
{
    public interface IAreaService : IInstanceService<AreaInstance, AreaTemplate> { }

    public class AreaService : IAreaService
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<AreaService> _logger;

        public AreaService(Data.ApplicationDbContext context, ILogger<AreaService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AreaTemplate> CreateTemplateAsync(AreaTemplate entity)
        {
            _logger.LogDebug($"Creating AreaTemplate\n{entity.ToJsonLog()}");
            var template = await _context.AreaTemplates.AddAsync(entity);
            await _context.SaveChangesAsync();
            return template.Entity;
        }
        public async Task<AreaTemplate> GetTemplateAsync(long templateId)
        {
            return await _context.AreaTemplates
                .Include((template) => template.Links)
                .FirstOrDefaultAsync(template => template.Id == templateId);
        }
        public async Task<AreaTemplate> UpdateTemplateAsync(AreaTemplate template)
        {
            _logger.LogDebug($"Updating AreaTemplate\n{template.ToJsonLog()}");
            _context.AreaTemplates.Update(template);
            await _context.SaveChangesAsync();
            return template;
        }
        public async Task DeleteTemplateAsync(long templateId)
        {
            _logger.LogDebug($"Deleting AreaTemplate {templateId}");
            var template = await _context.AreaTemplates.FindAsync(templateId);
            if (template == null)
            {
                throw new ArgumentException("Template id does not exist.");
            }
            _context.AreaTemplates.Remove(template);
            await _context.SaveChangesAsync();
        }

        public async Task<AreaInstance> CreateInstanceAsync(AreaInstance entity)
        {
            _logger.LogDebug($"Creating AreaInstance\n{entity.ToJsonLog()}");
            var instance = await _context.AreaInstances.AddAsync(entity);
            await _context.SaveChangesAsync();
            return instance.Entity;
        }
        public async Task<AreaInstance> GetInstanceAsync(long templateId)
        {
            return await _context.AreaInstances
                .Include((instance) => instance.Template)
                .Include((instance) => instance.Links)
                .ThenInclude((link) => link.Template)
                .FirstOrDefaultAsync(instance => instance.TemplateId == templateId);
        }
        public async Task<AreaInstance> UpdateInstanceAsync(AreaInstance instance)
        {
            _logger.LogDebug($"Updating AreaInstance\n{instance.ToJsonLog()}");
            _context.AreaInstances.Update(instance);
            await _context.SaveChangesAsync();
            return instance;
        }
        public async Task DeleteInstanceAsync(long instanceId)
        {
            _logger.LogDebug($"Deleting AreaInstance {instanceId}");
            var instance = await _context.AreaInstances.FindAsync(instanceId);
            if (instance == null)
            {
                throw new ArgumentException("Instance id does not exist.");
            }
            _context.AreaInstances.Remove(instance);
            await _context.SaveChangesAsync();
        }
    }
}
