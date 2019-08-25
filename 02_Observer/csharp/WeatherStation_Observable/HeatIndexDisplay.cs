using System;

namespace WeatherStation
{
    internal class HeatIndexDisplay : IObserver<WeatherData>
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
            Console.WriteLine($"Heat index is {ComputeHeatIndex(value.Temperature, value.Humidity):N1}");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Heat index cannot be calculated.");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Weather station has completed transmitting data to {nameof(HeatIndexDisplay)}.");
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }

        private static double ComputeHeatIndex(double t, double rh)
        {
            var index = (double)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
                                 (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
                                 (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
                                 (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
                                                                                                     (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
                                 (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
                                 0.000000000843296 * (t * t * rh * rh * rh)) -
                                (0.0000000000481975 * (t * t * t * rh * rh * rh)));
            return index;
        }
    }
}
