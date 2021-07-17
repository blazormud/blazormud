using System;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Server.Services
{
    public interface IAreaService : IInstanceService<AreaInstance, AreaTemplate> { }

    public class AreaService : IAreaService
    {
        private readonly ApplicationDbContext _context;

        public AreaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AreaTemplate> CreateTemplateAsync(AreaTemplate entity)
        {
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
            _context.AreaTemplates.Update(template);
            await _context.SaveChangesAsync();
            return template;
        }
        public async Task DeleteTemplateAsync(long templateId)
        {
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
            _context.AreaInstances.Update(instance);
            await _context.SaveChangesAsync();
            return instance;
        }
        public async Task DeleteInstanceAsync(long instanceId)
        {
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
