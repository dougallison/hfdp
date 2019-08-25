using System;

namespace WeatherStation
{
    static class Program
    {
        static void Main(string[] args)
        {
            var weatherStation = new WeatherStation();
            var currentConditionDisplay = new CurrentConditionsDisplay();
            currentConditionDisplay.Subscribe(weatherStation);

            var forecastDisplay = new ForecastDisplay();
            forecastDisplay.Subscribe(weatherStation);

            var statisticsDisplay = new StatisticsDisplay();
            statisticsDisplay.Subscribe(weatherStation);

            var heatIndexDisplay = new HeatIndexDisplay();
            heatIndexDisplay.Subscribe(weatherStation);

            weatherStation.TrackWeather(new WeatherData(80, 65, 30.4f));
            weatherStation.TrackWeather(new WeatherData(82, 70, 29.2f));
            weatherStation.TrackWeather(new WeatherData(78, 90, 29.2f));

            Console.WriteLine();
            weatherStation.EndTransmission();
        }
    }
}
