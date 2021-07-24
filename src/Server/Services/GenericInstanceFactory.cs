// using System.Threading.Tasks;
// using BlazorMUD.Core.Models;

// namespace BlazorMUD.Server.Services
// {
//     public class GenericInstanceFactory<TService, TInstance, TTemplate>
//         where TService : IInstanceService<TInstance, TTemplate>
//         where TInstance : class, IInstanceModel<TTemplate>, new()
//         where TTemplate : class
//         //: IGenericInstanceFactory<TService, TModel>
//     {
//         private readonly TService _service;
//         public GenericInstanceFactory(TService service)
//         {
//             _service = service;
//         }

//         public async Task<TInstance> GetAsync(long templateId)
//         {
//             var instance = await _service.GetInstanceAsync(templateId);
//             if (instance == null)
//             {
//                 var template = await _service.GetTemplateAsync(templateId);
//                 instance = new TInstance
//                 {
//                     Template = template
//                 };
//                 instance = await _service.CreateInstanceAsync(instance);
//             }
//             return instance;
//         }
//     }
// }
