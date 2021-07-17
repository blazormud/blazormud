using System;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Server.Services
{
    public interface ILinkService : IInstanceService<LinkInstance, LinkTemplate> { }

    public class LinkService : ILinkService
    {
        private readonly ApplicationDbContext _context;

        public LinkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LinkTemplate> CreateTemplateAsync(LinkTemplate entity)
        {
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
            _context.LinkTemplates.Update(template);
            await _context.SaveChangesAsync();
            return template;
        }
        public async Task DeleteTemplateAsync(long templateId)
        {
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
            _context.LinkInstances.Update(instance);
            await _context.SaveChangesAsync();
            return instance;
        }
        public async Task DeleteInstanceAsync(long instanceId)
        {
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
