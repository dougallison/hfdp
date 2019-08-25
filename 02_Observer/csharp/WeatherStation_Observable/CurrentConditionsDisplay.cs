using System;

namespace WeatherStation
{
    internal class CurrentConditionsDisplay : IObserver<WeatherData>
    {
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
            Console.WriteLine($"Current conditions: {value.Temperature}F degrees and {value.Humidity}% humidity.");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Current conditions cannot be determined.");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Weather station has completed transmitting data to {nameof(CurrentConditionsDisplay)}.");
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }
    }
}
