public class WeatherStation {
    public static void main(String[] args) {
        WeatherData weatherData = new WeatherData();

        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
        ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

        // Simulate new weather measurements
        weatherData.setMeasurements(80,65,30.4f);
        weatherData.setMeasurements(82,70,29.92f);
        weatherData.setMeasurements(78,90,29.2f);
    }
}
