namespace EditForm.Demo
{

    public class DeveloperCreateBase : ComponentBase, IDisposable
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        
        public DeveloperCreateBase()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            NavigationManager!.LocationChanged += LocationChangeHandler;
            await base.OnInitializedAsync();
        }

        private void LocationChangeHandler(object? sender, LocationChangedEventArgs e)
        {
            bool isNavigationIntercepted = e.IsNavigationIntercepted;
            string location = e.Location;
            System.Console.WriteLine($"IsNavigationIntercepted : {isNavigationIntercepted}" +
                $"Location: {location}");
        }

        protected async Task DeveloperCreateAsync()
        {
            NavigationManager!.NavigateTo(RoutingSetting.DetailPage!);
            await Task.CompletedTask;
        }

        protected async Task DeveloperCancelAsync()
        {
            NavigationManager!.NavigateTo(RoutingSetting.GridPage!);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            NavigationManager!.LocationChanged -= LocationChangeHandler;
        }
    }
}
