using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMUD.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly AreaFactory _areaFactory;

        public AreaController(AreaFactory areaFactory)
        {
            _areaFactory = areaFactory;
        }

        [HttpGet] // api/area/id
        public async Task<ActionResult<AreaInstance>> Get()
        {
            return await _areaFactory.GetAreaInstanceAsync(2L);
        }
    }
}
