﻿namespace Blazor.EditForm.Core
{
    public class WeatherForecastViewService
    {
        private readonly IWeatherForecastDataBroker? weatherForecastDataBroker;

        private readonly WeatherForecastsViewService weatherForecastsViewService;

        public DcoWeatherForecast Record { get; private set; } = new DcoWeatherForecast();

        public DeoWeatherForecast EditModel { get; private set; } = new DeoWeatherForecast();

        public WeatherForecastViewService(IWeatherForecastDataBroker weatherForecastDataBroker, WeatherForecastsViewService weatherForecastsViewService)
        {
            this.weatherForecastDataBroker = weatherForecastDataBroker!;
            this.weatherForecastsViewService = weatherForecastsViewService;
        }

        public async ValueTask GetForecastAsync(Guid Id)
        {
            this.Record = await weatherForecastDataBroker!.GetForecastAsync(Id);
            this.EditModel.Populate(this.Record);
        }

        public async ValueTask AddRecordAsync(DcoWeatherForecast record)
        {
            this.Record = record;
            await weatherForecastDataBroker!.AddForecastAsync(this.Record);
            weatherForecastsViewService.NotifyListChanged(this, EventArgs.Empty);
        }

        public async ValueTask UpdateRecordAsync()
        {
            this.Record = EditModel.ToDco;
            await weatherForecastDataBroker!.UpdateForecastAsync(this.Record);
            weatherForecastsViewService.NotifyListChanged(this, EventArgs.Empty);
        }

        public async ValueTask DeleteRecordAsync(Guid Id)
        {
            _ = await weatherForecastDataBroker!.DeleteForecastAsync(Id);
            weatherForecastsViewService.NotifyListChanged(this, EventArgs.Empty);
        }
    }
}
