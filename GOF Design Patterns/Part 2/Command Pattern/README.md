# Command Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Encapsulates a request as an object, thereby letting you parameterize clients with queues, requests, and operations."

### Simplified Explanation

- The **Command Pattern** turns a request into a stand-alone object.
- It allows you to **parameterize** objects with operations (i.e., requests).
- This pattern is ideal for scenarios where you want to decouple the sender of a request from the object that performs the action.

## Background

The Command Pattern is used when you need to decouple an object that sends a request from the one that receives it. Instead of invoking a method directly, you encapsulate the request as an object and pass it along to be executed later. It also allows you to queue requests, log requests, and even undo operations.

### Example: Remote Control for Devices

Consider a remote control that can perform multiple functions:

- **Turn on/off the TV**
- **Adjust the volume**
- **Change channels**

Rather than directly invoking the TV methods, the remote control will send commands to a `Receiver` (the TV), encapsulating the actions.

## Implementation

### Step 1: Define the Command Interface

```csharp
public interface ICommand
{
    void Execute();
}
```

#### Step 2: Create Concrete Commands

```csharp
public class TurnOnTVCommand : ICommand
{
    private readonly TV _tv;

    public TurnOnTVCommand(TV tv) => _tv = tv;

    public void Execute() => _tv.TurnOn();
}

public class TurnOffTVCommand : ICommand
{
    private readonly TV _tv;

    public TurnOffTVCommand(TV tv) => _tv = tv;

    public void Execute() => _tv.TurnOff();
}

public class ChangeChannelCommand : ICommand
{
    private readonly TV _tv;
    private readonly int _channel;

    public ChangeChannelCommand(TV tv, int channel)
    {
        _tv = tv;
        _channel = channel;
    }

    public void Execute() => _tv.ChangeChannel(_channel);
}
```

### Step 3: Create the Receiver (Receiver of the Command)

```csharp
public class TV
{
    public void TurnOn() => Console.WriteLine("TV is now ON.");

    public void TurnOff() => Console.WriteLine("TV is now OFF.");

    public void ChangeChannel(int channel) => Console.WriteLine($"TV channel changed to {channel}.");
}
```

### Step 4: Create the Invoker (Invoker of the Command)

```csharp
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command) => _command = command;

    public void PressButton() => _command.Execute();
}
```

### Step 5: Use Command in Client Code

```csharp
class Program
{
    static void Main()
    {
        TV tv = new TV();
        ICommand turnOnTV = new TurnOnTVCommand(tv);
        ICommand turnOffTV = new TurnOffTVCommand(tv);
        ICommand changeChannel = new ChangeChannelCommand(tv, 5);

        RemoteControl remote = new RemoteControl();

        // Turn on the TV
        remote.SetCommand(turnOnTV);
        remote.PressButton();

        // Change channel
        remote.SetCommand(changeChannel);
        remote.PressButton();

        // Turn off the TV
        remote.SetCommand(turnOffTV);
        remote.PressButton();
    }
}
```

### Comparison: Command vs Other Patterns

| Feature        | Command Pattern                                       | Strategy Pattern                                                 | State Pattern                                        |
| -------------- | ----------------------------------------------------- | ---------------------------------------------------------------- | ---------------------------------------------------- |
| Purpose        | Encapsulate requests as objects                       | Encapsulate algorithms or behaviors                              | Handle state transitions                             |
| Responsibility | Assigns responsibility to specific commands           | Decouples algorithms from context                                | Controls an object's state over time                 |
| Flexibility    | Allows for queuing, undo, and logging of commands     | Changes the behavior of an object at runtime                     | Transitions are based on an object’s state           |
| When to Use    | When you need to decouple an invoker from its actions | When you need to choose between different algorithms dynamically | When an object's behavior changes based on its state |


### Problems Solved by Command Pattern
- ✅ Decoupling Sender and Receiver – The sender doesn’t need to know anything about the receiver's implementation or how the request is handled.
- ✅ Support for Undo/Redo Operations – The pattern can easily support the concept of undo or redo, especially when the command objects store previous states.
- ✅ Queuing Requests – Commands can be queued and executed later, allowing for flexible execution.
- ✅ Logging Requests – Each command object can log information about the requests, making it easier to track which operations were performed.
- ✅ Parameterizing Objects with Operations – You can easily create and pass commands with different operations to invokers, leading to more flexible and reusable code.

### Conclusion

The Command Pattern is a behavioral design pattern that encapsulates a request as an object, allowing for flexible and decoupled execution. It is useful in situations where you need to decouple the sender of a request from the one that performs the action, support undo/redo functionality, or queue requests for deferred execution. Whether you're building remote control systems, event handlers, or task scheduling systems, the Command Pattern can provide the flexibility and modularity you need.
