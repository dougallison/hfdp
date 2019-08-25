using System;
using System.Collections.Generic;

namespace WeatherStation
{
    internal class WeatherStation : IObservable<WeatherData>
    {
        private List<IObserver<WeatherData>> Observers { get; }

        public WeatherStation()
        {
            Observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }

            return new Unsubscriber(Observers, observer);
        }

        public void TrackWeather(WeatherData weather)
        {
            foreach (var observer in Observers)
            {
                if (weather == null)
                {
                    observer.OnError(new WeatherDataUnknownException());
                }
                else
                {
                    observer.OnNext(weather);
                }
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in Observers.ToArray())
            {
                if (Observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }

            Observers.Clear();
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<WeatherData>> _observers;
            private readonly IObserver<WeatherData> _observer;

            public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
            {
                _observer = observer;
                _observers = observers;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
