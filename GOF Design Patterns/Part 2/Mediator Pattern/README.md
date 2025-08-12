# Mediator Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Defines an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently."

### Simplified Explanation

- The **Mediator Pattern** is used to **centralize communication** between objects in a system.
- Rather than having objects communicate directly with one another, they interact with a **mediator** object that controls the flow of communication.
- This pattern helps **reduce dependencies** between objects, making the system more flexible and easier to maintain.

## Background

The Mediator Pattern is useful when you have a system with multiple objects that need to communicate with each other. Instead of having each object reference and interact with every other object directly, the Mediator Pattern centralizes this interaction into one object.

This is particularly helpful in systems with **complex relationships** and when you want to **decouple objects** to improve maintainability and scalability.

### Example: Chatroom

Consider a **chatroom** where multiple users can send messages to each other. Instead of each user sending messages directly to other users, they send messages to the **chatroom mediator**, which then broadcasts the message to all users in the room.

## Implementation

### Step 1: Define the Mediator Interface

```csharp
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}
```

### Step 2: Create Concrete Mediator (Chatroom)

```csharp
public class Chatroom : IChatMediator
{
    private readonly List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            if (u != user)
            {
                u.ReceiveMessage(message);
            }
        }
    }
}
```

### Step 3: Create Colleague (User)

```csharp
public class User
{
    private readonly IChatMediator _mediator;
    private readonly string _name;

    public User(IChatMediator mediator, string name)
    {
        _mediator = mediator;
        _name = name;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{_name} sends message: {message}");
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name} receives message: {message}");
    }
}
```

### Step 4: Use Mediator in Client Code

```csharp
class Program
{
    static void Main()
    {
        IChatMediator chatroom = new Chatroom();

        User user1 = new User(chatroom, "User1");
        User user2 = new User(chatroom, "User2");
        User user3 = new User(chatroom, "User3");

        chatroom.AddUser(user1);
        chatroom.AddUser(user2);
        chatroom.AddUser(user3);

        user1.SendMessage("Hello, everyone!");
        user2.SendMessage("Hi, User1!");
    }
}
```
### Comparison: Mediator vs Other Patterns

| Feature     | Mediator Pattern                                                   | Observer Pattern                                                           | Command Pattern                                 |
| ----------- | ------------------------------------------------------------------ | -------------------------------------------------------------------------- | ----------------------------------------------- |
| Purpose     | Centralizes communication and reduces dependencies                 | Allows multiple objects to listen to events from a subject                 | Encapsulates requests as objects                |
| Structure   | Centralized communication through a mediator                       | One-to-many relationship between subject and observers                     | Objects encapsulate commands to be executed     |
| Flexibility | Decouples objects and reduces dependencies                         | Enables broadcast communication between subjects and observers             | Allows for queuing and logging of requests      |
| When to Use | When objects communicate with many others and need to be decoupled | When you need multiple objects to be notified of changes in another object | When requests need to be encapsulated or queued |


### Problems Solved by Mediator Pattern

- ✅ Reduces Object Dependencies – By centralizing communication in a mediator, objects no longer need to reference each other directly.
- ✅ Simplifies Complex Communication – Helps in reducing the complexity of communication between many objects.
- ✅ Improves Maintainability – Changes in communication logic only need to be made in the mediator, not in every individual object.
- ✅ Enhances Flexibility – The interaction between objects is controlled by the mediator, so adding or removing objects doesn't impact other parts of the system.
- ✅ Reduces System Complexity – Mediator allows for easier interaction management by controlling the flow of communication, making the system simpler.

### Conclusion

The Mediator Pattern is a behavioral pattern that centralizes communication between objects to reduce the dependencies and complexities involved in direct communication. It is ideal when you have a complex system where many objects interact with each other. By using a mediator to handle the communication, you can improve the maintainability, scalability, and flexibility of the system. Whether you are designing a chatroom, a workflow system, or any system involving complex object interactions, the Mediator Pattern can simplify communication and reduce the need for tight coupling.
