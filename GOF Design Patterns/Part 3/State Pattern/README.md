# State Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Allows an object to alter its behavior when its internal state changes. The object will appear to change its class."*

### **Simplified Explanation**

- The State Pattern lets an object **change its behavior dynamically** when its internal state changes.  
- It encapsulates state-specific behavior into **separate state classes**, removing large conditional statements.  
- The context delegates work to the current state object, making the system more extensible.  

## **Background**

The State Pattern is useful when:  
- An object’s behavior depends on its **state**, and it must change behavior at runtime.  
- You want to **replace complex conditional logic** (`if/else` or `switch` statements) with cleaner code.  
- Multiple states share the same interface but implement different behavior.  

### **Example: Media Player**

Consider a media player with states: **Playing, Paused, and Stopped**.  
- Instead of writing conditionals everywhere, each state has its own class.  
- The **Context (MediaPlayer)** delegates calls to its current state object.  

## **Implementation**

### **Step 1: Define the State Interface**

```csharp
public interface IState
{
    void Handle(MediaPlayer player);
}
```

## Step 2: Create Concrete States

```csharp
public class PlayingState : IState
{
    public void Handle(MediaPlayer player)
    {
        Console.WriteLine("Currently Playing → Pausing now...");
        player.SetState(new PausedState());
    }
}

public class PausedState : IState
{
    public void Handle(MediaPlayer player)
    {
        Console.WriteLine("Currently Paused → Stopping now...");
        player.SetState(new StoppedState());
    }
}

public class StoppedState : IState
{
    public void Handle(MediaPlayer player)
    {
        Console.WriteLine("Currently Stopped → Playing now...");
        player.SetState(new PlayingState());
    }
}
```

## Step 3: Create the Context

```csharp
public class MediaPlayer
{
    private IState _state;

    public MediaPlayer(IState state)
    {
        _state = state;
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}
```

## Step 4: Use State in Client Code

```csharp
class Program
{
    static void Main()
    {
        MediaPlayer player = new MediaPlayer(new StoppedState());

        player.Request(); // Stopped → Playing
        player.Request(); // Playing → Paused
        player.Request(); // Paused → Stopped
    }
}
```

## Comparison: State vs Strategy

| Feature               | State Pattern                              | Strategy Pattern                         |
| --------------------- | ------------------------------------------ | ---------------------------------------- |
| Purpose               | ✅ Change behavior when state changes       | ✅ Encapsulate interchangeable algorithms |
| Focus                 | ✅ Object behavior depends on current state | ✅ Choosing which algorithm to use        |
| State/Strategy Change | ✅ Triggered internally by the context      | ✅ Chosen externally by the client        |
| Best for              | ✅ Modeling dynamic behavior at runtime     | ✅ Selecting algorithms at runtime        |

### Problems Solved by the State Pattern

- ✅ **Removes Complex Conditionals** – Eliminates large `if/else` or `switch` statements for state logic.  
- ✅ **Encapsulates State Behavior** – Each state has its own class, making the code cleaner and modular.  
- ✅ **Supports Dynamic Behavior** – Objects change behavior automatically when their state changes.  
- ✅ **Improves Maintainability** – Adding new states doesn’t require modifying existing code.  

