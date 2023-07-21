namespace wft
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get(int max,int min,int items);
    }
}