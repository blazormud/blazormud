using System.Threading.Tasks;

namespace BlazorMUD.Server.Services
{
    public interface IInstanceService<TInstance, TTemplate>
        where TInstance : class
        where TTemplate : class
    {
        Task<TTemplate> CreateTemplateAsync(TTemplate entity);
        Task<TTemplate> GetTemplateAsync(long templateId);
        Task<TTemplate> UpdateTemplateAsync(TTemplate template);
        Task DeleteTemplateAsync(long templateId);
        Task<TInstance> CreateInstanceAsync(TInstance entity);
        Task<TInstance> GetInstanceAsync(long templateId);
        Task<TInstance> UpdateInstanceAsync(TInstance instance);
        Task DeleteInstanceAsync(long instanceId);
    }
}
