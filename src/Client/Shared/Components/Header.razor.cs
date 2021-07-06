namespace BlazorMUD.Client.Shared
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
