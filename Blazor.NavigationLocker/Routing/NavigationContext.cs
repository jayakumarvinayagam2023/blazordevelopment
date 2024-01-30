namespace Blazor.NavigationLocker
{
    /// <summary>
    /// Provides information about the current asynchronous navigation event
    /// including the target path and the cancellation token.
    /// </summary>
    public sealed class NavigationContext
    {
        public string? Path { get; }
        public CancellationToken CancellationToken { get; }
        public NavigationContext(string path, CancellationToken cancellationToken)
            => (Path, CancellationToken) = (path, cancellationToken);
    }
}
