


using Blazor.Core;
using Blazor.EditForm.Core;
using Microsoft.AspNetCore.Components.Forms;

namespace EditForm.Demo
{
    public partial class DeveloperDetailBase : BaseEditForm, IDisposable
    {
        
        [Inject] public WeatherForecastViewService? ViewService { get; set; }

        public WeatherForecastViewService viewService => this.ViewService!;
        public DeveloperDetailBase()
        {
            
        }

        protected async override Task OnInitializedAsync()
        {
            base.LoadState = ComponentState.Loading;
            await this.viewService.GetForecastAsync(Id);
            base.editContent = new EditContext(this.viewService.EditModel);
            base.editStateContext = new EditStateContext(base.editContent);
            base.editStateContext.EditStateChanged += base.OnEditStateChanged;
            base.LoadState = ComponentState.Loaded;
        }

        public async Task SaveRecord()
        {
            await this.viewService.UpdateRecordAsync();
            base.editStateContext?.NotifySaved();
        }

        private async Task AddRecord()
        => await this.viewService.AddRecordAsync(
            new DcoWeatherForecast
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Summary = "Balmy",
                TemperatureC = 14
            });

        protected override void BaseExit()
        => this.NavManager?.NavigateTo("/weatherforecast");


        public void Dispose()
        {
            if (base.editStateContext is not null)
                base.editStateContext.EditStateChanged -= base.OnEditStateChanged;
        }
    }
}
