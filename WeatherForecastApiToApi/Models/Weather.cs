namespace WeatherForecastApiToApi.Models
{
    public class Weather
    {
        public string City { get; set; }

        public string Country { get; set; }
        public string Temp_c { get; set; }

        public string Wind_kph { get; set; }

        public string Feelslike_c { get; set; }

        public string Last_updated { get; set; }
    }
}
