using System;

namespace WeatherStation
{
    internal class CurrentConditionsDisplay : IObserver<WeatherData>, IDisplayElement
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
            Display($"Current conditions: {value.Temperature}F degrees and {value.Humidity}% humidity.");
        }

        public void OnError(Exception error)
        {
            Display("Current conditions cannot be determined.");
        }

        public void OnCompleted()
        {
            Display($"Weather station has completed transmitting data to {nameof(CurrentConditionsDisplay)}.");
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
