using System;

namespace WeatherStation
{
    internal class ForecastDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private const double Tolerance = 0.001f;

        private double CurrentPressure { get; set; }

        private double LastPressure { get; set; }

        public ForecastDisplay()
        {
            CurrentPressure = 29.92f;
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
            LastPressure = CurrentPressure;
            CurrentPressure = value.Pressure;

            const string leader = "Forecast: ";
            if (CurrentPressure > LastPressure)
            {
                Display($"{leader}Improving weather on the way!");
            }
            else if (Math.Abs(CurrentPressure - LastPressure) < Tolerance)
            {
                Display($"{leader}More of the same");
            }
            else
            {
                Display($"{leader}Watch out for cooler, rainy weather");
            }
        }

        public void OnError(Exception error)
        {
            Display("Forecast cannot be determined.");
        }

        public void OnCompleted()
        {
            Display($"Weather station has completed transmitting data to {nameof(ForecastDisplay)}.");
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
