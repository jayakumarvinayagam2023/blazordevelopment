namespace Blazor.EditForm.Core
{
    public interface IWeatherForecastDataBroker
    {
        public ValueTask<bool> AddForecastAsync(DcoWeatherForecast record);

        public ValueTask<bool> UpdateForecastAsync(DcoWeatherForecast record);

        public ValueTask<DcoWeatherForecast> GetForecastAsync(Guid Id);

        public ValueTask<bool> DeleteForecastAsync(Guid Id);

        public ValueTask<IEnumerable<DcoWeatherForecast>> GetWeatherForecastsAsync();
    }
}
