using System;

namespace WeatherStation
{
    internal class StatisticsDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private double MaxTemperature { get; set; }

        private double MinTemperature { get; set; }

        private double TemperatureSum { get; set; }

        private int CountOfReadings { get; set; }

        public StatisticsDisplay()
        {
            MinTemperature = 200;
        }

        private IDisposable Unsubscriber { get; set; }

        public void Subscribe(IObservable<WeatherData> provider)
        {
            if (provider != null)
            {
                Unsubscriber = provider.Subscribe(this);
            }
        }

        public void OnNext(WeatherData value)
        {
            TemperatureSum += value.Temperature;
            CountOfReadings++;

            if (value.Temperature > MaxTemperature)
            {
                MaxTemperature = value.Temperature;
            }

            if (value.Temperature < MinTemperature)
            {
                MinTemperature = value.Temperature;
            }

            Display($"Avg/Max/Min temperature = {TemperatureSum / CountOfReadings}/{MaxTemperature}/{MinTemperature}");
        }

        public void OnError(Exception error)
        {
            Display("Statistics cannot be calculated.");
        }

        public void OnCompleted()
        {
            Display($"Weather station has completed transmitting data to {nameof(StatisticsDisplay)}.");
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }

        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
