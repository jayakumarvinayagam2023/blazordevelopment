namespace Blazor.NavigationLocker
{
    public class RouteContext
    {
        private static readonly char[] Separator = new[] { '/' };
        public string[] Segments { get; }
        public Type? Handler {  get; set; }
        public IReadOnlyDictionary<string, object>? Parameters { get; set; }
        public RouteContext(string path)
        {
            Segments = path.Trim('/')
                .Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < Segments.Length; i++)
            {
                Segments[i] = Uri.UnescapeDataString(Segments[i]);
            }
        }
    }
}
