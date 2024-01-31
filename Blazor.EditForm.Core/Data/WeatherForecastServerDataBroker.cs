namespace Blazor.EditForm.Core
{
    public class WeatherForecastServerDataBroker : IWeatherForecastDataBroker
    {
        private readonly WeatherForecastDataStore weatherForecastDataStore;

        public WeatherForecastServerDataBroker(WeatherForecastDataStore weatherForecastDataStore)
            => this.weatherForecastDataStore = weatherForecastDataStore;
        public async ValueTask<DcoWeatherForecast> GetForecastAsync(Guid Id)
            => await this.weatherForecastDataStore!.GetForecastAsync(Id);

        public async ValueTask<bool> AddForecastAsync(DcoWeatherForecast record)
            => await this.weatherForecastDataStore!.AddForecastAsync(record);

        public async ValueTask<bool> DeleteForecastAsync(Guid Id)
            => await this.weatherForecastDataStore!.DeleteForecastAsync(Id);

        public async ValueTask<bool> UpdateForecastAsync(DcoWeatherForecast record)
            => await this.weatherForecastDataStore!.UpdateForecastAsync(record);

        public async ValueTask<IEnumerable<DcoWeatherForecast>> GetWeatherForecastsAsync()
            => await this.weatherForecastDataStore!.GetWeatherForecastsAsync();
    }
}
