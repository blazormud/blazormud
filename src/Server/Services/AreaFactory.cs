using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using Microsoft.Extensions.Logging;

namespace BlazorMUD.Server.Services
{
    public class AreaFactory
    {
        // private readonly IAreaService _areaService;
        // private readonly ILinkService _linkService;
        // private readonly ILogger<AreaFactory> _logger;

        // public AreaFactory(IAreaService areaService, ILinkService linkService, ILogger<AreaFactory> logger)
        // {
        //     _areaService = areaService;
        //     _linkService = linkService;
        //     _logger = logger;
        // }

        // public async Task<AreaInstance> GetAreaInstanceAsync(long templateId)
        // {
        //     var instance = await _areaService.GetInstanceAsync(templateId);
        //     if (instance == null)
        //     {
        //         _logger.LogDebug($"Area instance for template {templateId} not found");
        //         var template = await _areaService.GetTemplateAsync(templateId);
        //         instance = new AreaInstance
        //         {
        //             Template = template
        //         };
        //         instance = await _areaService.CreateInstanceAsync(instance);
        //         var linkInstances = new List<LinkInstance>();
        //         foreach (var linkTemplate in template.Links)
        //         {
        //             linkInstances.Add(await _linkService.CreateInstanceAsync(new LinkInstance
        //             {
        //                 TemplateId = linkTemplate.Id,
        //                 SourceId = instance.Id
        //             }));
        //         }
        //         instance.Links = linkInstances;
        //         await _areaService.UpdateInstanceAsync(instance);
        //     }
        //     return instance;
        // }
    }
}
