using System;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Data;
using BlazorMUD.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorMUD.Server.Services
{
    public interface ILinkService : IInstanceService<LinkInstance, LinkTemplate> { }

    public class LinkService : ILinkService
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly ILogger<LinkService> _logger;

        public LinkService(Data.ApplicationDbContext context, ILogger<LinkService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<LinkTemplate> CreateTemplateAsync(LinkTemplate entity)
        {
            _logger.LogDebug($"Creating LinkTemplate\n{entity.ToJsonLog()}");
            var template = await _context.LinkTemplates.AddAsync(entity);
            await _context.SaveChangesAsync();
            return template.Entity;
        }
        public async Task<LinkTemplate> GetTemplateAsync(long templateId)
        {
            return await _context.LinkTemplates
                .Include((template) => template.Source)
                .Include((template) => template.Destination)
                .FirstOrDefaultAsync(template => template.Id == templateId);
        }
        public async Task<LinkTemplate> UpdateTemplateAsync(LinkTemplate template)
        {
            _logger.LogDebug($"Updating LinkTemplate\n{template.ToJsonLog()}");
            _context.LinkTemplates.Update(template);
            await _context.SaveChangesAsync();
            return template;
        }
        public async Task DeleteTemplateAsync(long templateId)
        {
            _logger.LogDebug($"Deleting LinkTemplate {templateId}");
            var template = await _context.LinkTemplates.FindAsync(templateId);
            if (template == null)
            {
                throw new ArgumentException("Template id does not exist.");
            }
            _context.LinkTemplates.Remove(template);
            await _context.SaveChangesAsync();
        }

        public async Task<LinkInstance> CreateInstanceAsync(LinkInstance entity)
        {
            _logger.LogDebug($"Creating LinkInstance\n{entity.ToJsonLog()}");
            var instance = await _context.LinkInstances.AddAsync(entity);
            await _context.SaveChangesAsync();
            return instance.Entity;
        }
        public async Task<LinkInstance> GetInstanceAsync(long templateId)
        {
            return await _context.LinkInstances
                .Include((instance) => instance.Source)
                //.Include((instance) => instance.Destination)
                .FirstOrDefaultAsync(instance => instance.TemplateId == templateId);
        }
        public async Task<LinkInstance> UpdateInstanceAsync(LinkInstance instance)
        {
            _logger.LogDebug($"Updating LinkInstance\n{instance.ToJsonLog()}");
            _context.LinkInstances.Update(instance);
            await _context.SaveChangesAsync();
            return instance;
        }
        public async Task DeleteInstanceAsync(long instanceId)
        {
            _logger.LogDebug($"Deleting LinkInstance {instanceId}");
            var instance = await _context.LinkInstances.FindAsync(instanceId);
            if (instance == null)
            {
                throw new ArgumentException("Instance id does not exist.");
            }
            _context.LinkInstances.Remove(instance);
            await _context.SaveChangesAsync();
        }
    }
}
