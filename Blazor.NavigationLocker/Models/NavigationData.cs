namespace Blazor.NavigationLocker
{
    public class NavigationData
    {
        public bool IsCanceled { get; set; }

        public string NewLocation { get; set; } = string.Empty;

        public string? CurrentLocation { get; set; } = String.Empty;

        public bool IsNavigationIntercepted { get; set; }
    }
}
