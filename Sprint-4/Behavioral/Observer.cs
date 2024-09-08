using System;
using System.Collections.Generic;

// Subject Interface
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Observer Interface
public interface IObserver
{
    void Update(float temperature);
}

// Concrete Subject
public class WeatherStation : ISubject
{
    private List<IObserver> observers;
    private float temperature;

    public WeatherStation()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature);
        }
    }

    public void SetTemperature(float temperature)
    {
        this.temperature = temperature;
        NotifyObservers();  // Notify observers when temperature changes
    }
}

// Concrete Observer
public class TemperatureDisplay : IObserver
{
    private float temperature;

    public void Update(float temperature)
    {
        this.temperature = temperature;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Temperature Display: {temperature}°C");
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        WeatherStation weatherStation = new WeatherStation();
        TemperatureDisplay display1 = new TemperatureDisplay();
        TemperatureDisplay display2 = new TemperatureDisplay();
        weatherStation.RegisterObserver(display1);
        weatherStation.RegisterObserver(display2);
        weatherStation.SetTemperature(25.3f);
        weatherStation.SetTemperature(28.7f);
    }
}
