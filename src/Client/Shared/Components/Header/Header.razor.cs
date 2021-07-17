namespace BlazorMUD.Client.Shared.Components.Header
{
    public partial class Header
    {
        protected int CurrentCount { get; set; } = 0;

        protected void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
