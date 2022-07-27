namespace WeatherForecastApiToApi.Models
{
    public class Weather
    {
        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string TimeZone { get; set; }

        public string LocalTime { get; set; }

        public double Temp_c { get; set; }

        public string WindDirection { get; set; }

        public string Condition { get; set; }

        public string ConditionIcon { get; set; }

        public double Wind_kph { get; set; }

        public double Feelslike_c { get; set; }

        public string Last_updated { get; set; }
    }
}
