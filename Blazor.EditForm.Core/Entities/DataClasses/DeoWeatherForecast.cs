namespace Blazor.EditForm.Core
{ 
    public class DeoWeatherForecast
    {
        public Guid Id { get; set; } = GuidExtensions.Null;

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; } = String.Empty;

        public bool IsNull => Id == GuidExtensions.Null;

        public void Populate(DcoWeatherForecast record)
        {
            this.Id = record.Id;
            this.Date = record.Date;
            this.Summary = record.Summary;
            this.TemperatureC = record.TemperatureC;
        }

        public DcoWeatherForecast ToDco =>
            new DcoWeatherForecast()
            {
                Id = this.Id,
                Date = this.Date,
                Summary = this.Summary,
                TemperatureC = this.TemperatureC
            };
    }
}
