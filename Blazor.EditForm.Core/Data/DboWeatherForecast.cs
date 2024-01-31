namespace Blazor.EditForm.Core
{
    public record DboWeatherForecast
    {
        public Guid Id { get; init; }

        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public string? Summary { get; init; }

        public DcoWeatherForecast ToDto()
            => new DcoWeatherForecast
            {
                Id = this.Id,
                Date = this.Date,
                TemperatureC = this.TemperatureC,
                Summary = this.Summary
            };

        public static DboWeatherForecast FromDto(DcoWeatherForecast record)
            => new DboWeatherForecast
            {
                Id = record.Id,
                Date = record.Date,
                TemperatureC = record.TemperatureC,
                Summary = record.Summary
            };
    }
}
