using System;

namespace WeatherStation
{
    internal class ForecastDisplay : IObserver<WeatherData>
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

            Console.Write("Forecast: ");
            if (CurrentPressure > LastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (Math.Abs(CurrentPressure - LastPressure) < Tolerance)
            {
                Console.WriteLine("More of the same");
            }
            else
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Forecast cannot be determined.");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Weather station has completed transmitting data to {nameof(ForecastDisplay)}.");
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }
    }
}
