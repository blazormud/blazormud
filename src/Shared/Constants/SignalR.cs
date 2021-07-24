namespace BlazorMUD.Shared
{
    public static partial class Constants
    {
        public static class SignalR
        {
            public const string BaseUri = "/hubs";
            public static class ChatHub
            {
                public const string Uri = BaseUri + "/chathub";
                public const string SendMessage = "SendMessage";
                public const string ReceiveMessage = "ReceiveMessage";
            }

            public static class PlayHub
            {

            }
        }
    }
}
