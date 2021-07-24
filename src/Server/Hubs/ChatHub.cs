using System.Security.Claims;
using System.Threading.Tasks;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace BlazorMUD.Server.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public UserManager<ApplicationUser> UserManager { get; init; }
        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public async Task SendMessage(string message)
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await UserManager.FindByIdAsync(userId);

            await Clients.All.SendAsync(Constants.SignalR.ChatHub.ReceiveMessage, user?.UserName ?? "unknown", message);
        }
    }
}
