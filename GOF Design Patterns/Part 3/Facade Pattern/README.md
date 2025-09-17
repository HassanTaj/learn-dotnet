# Facade Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Provides a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use."*

### **Simplified Explanation**

- The Facade Pattern provides a **simplified interface** to a complex subsystem.  
- It acts as a **front-facing interface**, hiding the complexity of underlying classes and operations.  
- Clients interact with the facade rather than dealing directly with multiple subsystems.  

## **Background**

The Facade Pattern is useful when:  
- A system is very complex or has multiple subsystems.  
- You want to provide a **simple entry point** for clients.  
- You want to **reduce coupling** between clients and subsystems.  
- You want to structure a system into layers (e.g., UI → Facade → Subsystems).  

### **Example: Home Theater System**

Consider a **home theater system** with multiple components like DVD Player, Projector, Surround Sound System, and Lights.  

Instead of requiring the user to operate each device individually, the Facade Pattern allows creating a **`HomeTheaterFacade`** class that provides simple methods like `WatchMovie()` or `EndMovie()`.  

## **Implementation**

### **Step 1: Create Subsystem Classes**

```csharp
public class DVDPlayer
{
    public void On() => Console.WriteLine("DVD Player is ON");
    public void Play(string movie) => Console.WriteLine($"Playing movie: {movie}");
    public void Off() => Console.WriteLine("DVD Player is OFF");
}

public class Projector
{
    public void On() => Console.WriteLine("Projector is ON");
    public void Off() => Console.WriteLine("Projector is OFF");
}

public class SoundSystem
{
    public void On() => Console.WriteLine("Sound System is ON");
    public void SetSurroundSound() => Console.WriteLine("Surround Sound mode enabled");
    public void Off() => Console.WriteLine("Sound System is OFF");
}

public class Lights
{
    public void Dim(int level) => Console.WriteLine($"Lights dimmed to {level}%");
}
```

## **Step 2: Create the Facade**

```csharp
public class HomeTheaterFacade
{
    private readonly DVDPlayer dvd;
    private readonly Projector projector;
    private readonly SoundSystem sound;
    private readonly Lights lights;

    public HomeTheaterFacade(DVDPlayer dvd, Projector projector, SoundSystem sound, Lights lights)
    {
        this.dvd = dvd;
        this.projector = projector;
        this.sound = sound;
        this.lights = lights;
    }

    public void WatchMovie(string movie)
    {
        Console.WriteLine("Get ready to watch a movie...");
        lights.Dim(30);
        projector.On();
        sound.On();
        sound.SetSurroundSound();
        dvd.On();
        dvd.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting movie theater down...");
        dvd.Off();
        sound.Off();
        projector.Off();
        lights.Dim(100);
    }
}
```

## **Step 3: Use the Facade in Client Code**

```csharp
class Program
{
    static void Main()
    {
        var dvd = new DVDPlayer();
        var projector = new Projector();
        var sound = new SoundSystem();
        var lights = new Lights();

        var homeTheater = new HomeTheaterFacade(dvd, projector, sound, lights);

        homeTheater.WatchMovie("Inception");
        Console.WriteLine();
        homeTheater.EndMovie();
    }
}
```

## **Comparison: Facade vs Adapter**

| Feature      | Facade Pattern                                | Adapter Pattern                                    |
| ------------ | --------------------------------------------- | -------------------------------------------------- |
| Purpose      | ✅ Provides a simplified interface to a system | ✅ Makes incompatible interfaces work together      |
| Focus        | ✅ Ease of use, reducing complexity            | ✅ Compatibility and reuse                          |
| Relationship | ✅ One facade to many subsystems               | ✅ One adapter to make two interfaces work together |
| Best for     | ✅ Simplifying complex subsystems              | ✅ Integrating legacy or third-party code           |

## Problems Solved by the Facade Pattern

- ✅ **Simplifies Complex Systems** – Provides a unified interface to multiple subsystems.  
- ✅ **Reduces Client-Subsystem Coupling** – Clients depend only on the facade, not the complex subsystem details.  
- ✅ **Improves Code Readability** – Clients call simple high-level methods instead of managing multiple objects.  
- ✅ **Supports Layered Architecture** – Helps structure systems into layers (UI, Facade, Subsystems).  
