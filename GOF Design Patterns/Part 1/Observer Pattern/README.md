# Observer Pattern

## **Gang of Four Definition**

According to the Gang of Four (GoF):

> *"Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically."*

### **Simplified Explanation**

- The Observer Pattern creates a **subscription mechanism** where multiple objects (observers) can listen to and react to changes in another object (the subject).
- When the subject changes state, **all subscribed observers are notified**.
- This pattern is often used to **implement event systems** or **real-time updates** in applications.

## **Background**

The Observer Pattern is useful when you need to ensure that multiple objects stay in sync with the state of another object, without tightly coupling them. It promotes **loose coupling** and **dynamic relationships** between objects.

### **Example: Weather Station and Displays**

Consider a weather station that gathers temperature, humidity, and pressure data. There can be multiple display units (e.g., phone app, desktop dashboard, public display) that must update whenever the weather data changes.

The weather station acts as the **subject**, and each display acts as an **observer** that reacts to changes automatically.

## **Implementation**

### **Step 1: Define Observer and Subject Interfaces**

```csharp
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
```

### Step 2: Create Concrete Subject

```csharp
public class WeatherData : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;
    private float humidity;
    private float pressure;

    public void RegisterObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    public void SetMeasurements(float temp, float hum, float pres)
    {
        temperature = temp;
        humidity = hum;
        pressure = pres;
        NotifyObservers();
    }
}
```

### Step 3: Create Concrete Observers

```csharp
public class CurrentConditionsDisplay : IObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"Current Conditions: {temperature}°C, {humidity}% humidity");
    }
}

public class StatisticsDisplay : IObserver
{
    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"Statistics Updated - Temp: {temperature}°C, Humidity: {humidity}%");
    }
}
```

### Step 4: Use the Pattern in Client Code

```chsarp
class Program
{
    static void Main()
    {
        WeatherData weatherData = new WeatherData();

        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay();
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay();

        weatherData.RegisterObserver(currentDisplay);
        weatherData.RegisterObserver(statisticsDisplay);

        weatherData.SetMeasurements(25.5f, 65f, 1013.1f);
        weatherData.SetMeasurements(26.1f, 60f, 1012.5f);
    }
}
```
### Comparison: Observer Pattern vs Other Patterns

| Feature                 | Observer Pattern          | Mediator Pattern                      |
| ----------------------- | ------------------------- | ------------------------------------- |
| Relationship            | One-to-many               | Many-to-many                          |
| Communication Direction | From subject to observers | Central mediator coordinates messages |
| Best for                | Event notifications       | Complex inter-object communications   |

### Problems Solved by Observer Pattern

- ✅ Loose Coupling – Observers and subjects only know about each other through interfaces.
- ✅ Dynamic Relationships – Observers can be added or removed at runtime.
- ✅ Automatic Updates – Changes in the subject automatically propagate to all observers.
- ✅ Scalable Notifications – Multiple observers can react without modifying subject logic.

### Conclusion

The Observer Pattern is ideal for scenarios where changes in one object must be automatically reflected in others, without creating tight dependencies. From GUI frameworks to real-time data systems, it offers a clean, scalable approach to event-driven programming.
