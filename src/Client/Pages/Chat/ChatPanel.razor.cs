using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMUD.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorMUD.Client.Pages.Chat
{
    [Authorize]
    public partial class ChatPanel : IAsyncDisposable
    {
        [Inject]
        private IAccessTokenProvider AccessTokenProvider { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private HubConnection HubConnection { get; set; }
        public bool IsConnected => HubConnection.State == HubConnectionState.Connected;

        private readonly List<string> messages = new();
        //private string userInput;
        private string messageInput;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await InitializeHubAsync();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private async Task InitializeHubAsync()
        {
            HubConnection = new HubConnectionBuilder()
                .WithUrl(
                    NavigationManager.ToAbsoluteUri(Constants.SignalR.ChatHub.Uri),
                    options =>
                    {
                        options.AccessTokenProvider = async () =>
                        {
                            var accessTokenResult = await AccessTokenProvider.RequestAccessToken();
                            accessTokenResult.TryGetToken(out var accessToken);
                            return accessToken.Value;
                        };
                    }
                )
                .WithAutomaticReconnect()
                .Build();

            HubConnection.On<string, string>(Constants.SignalR.ChatHub.ReceiveMessage, ReceiveMessage);

            await HubConnection.StartAsync();
        }

        private async Task Send()
        {
            await HubConnection.SendAsync(Constants.SignalR.ChatHub.SendMessage, messageInput);
        }

        private void ReceiveMessage(string user, string message)
        {
            var encodedMsg = $"{user}: {message}";
            messages.Add(encodedMsg);
            StateHasChanged();
        }

        public async ValueTask DisposeAsync()
        {
            if (HubConnection is not null) await HubConnection.DisposeAsync();
        }
    }
}
