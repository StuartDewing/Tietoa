namespace DotNetApi.Models
{
    public class WeatherForecastDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double CurrentTemp { get; set; }
        public string Condition { get; set; }
    }
}