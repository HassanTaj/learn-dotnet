# Chain of Responsibility Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it."

### Simplified Explanation

- The **Chain of Responsibility Pattern** allows a request to be passed along a **chain of handlers**.
- Each handler can either **process the request** or **pass it on to the next handler** in the chain.
- This pattern is useful for **decoupling the sender** from the receiver of a request and distributing the responsibility to a series of objects.

## Background

In many systems, requests need to be processed in a certain order. However, sometimes we want to avoid hard-coding the exact handling logic or chaining the request processing too tightly. The Chain of Responsibility Pattern provides a **flexible mechanism** to process requests with varying levels of priority or responsibility.

### Example: Support Ticket System

Imagine a customer support system where a user can submit a ticket. Depending on the type of the issue, different departments handle it:

- **Technical Support** handles technical issues.
- **Billing** handles payment-related issues.
- **Customer Service** handles general inquiries.

The request can be passed along the chain of responsibility until it reaches the department that can handle it.

## Implementation

### Step 1: Define the Handler Interface

```csharp
public interface IHandler
{
    void SetNext(IHandler handler);
    void HandleRequest(string request);
}
```

### Step 2: Create Concrete Handlers

```csharp
public class TechnicalSupport : IHandler
{
    private IHandler _nextHandler;

    public void SetNext(IHandler handler) => _nextHandler = handler;

    public void HandleRequest(string request)
    {
        if (request.Contains("technical"))
        {
            Console.WriteLine("Technical Support handling request.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}

public class Billing : IHandler
{
    private IHandler _nextHandler;

    public void SetNext(IHandler handler) => _nextHandler = handler;

    public void HandleRequest(string request)
    {
        if (request.Contains("billing"))
        {
            Console.WriteLine("Billing handling request.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}

public class CustomerService : IHandler
{
    private IHandler _nextHandler;

    public void SetNext(IHandler handler) => _nextHandler = handler;

    public void HandleRequest(string request)
    {
        if (request.Contains("general"))
        {
            Console.WriteLine("Customer Service handling request.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}
```

### Step 3: Use Chain of Responsibility in Client Code

```csharp
class Program
{
    static void Main()
    {
        IHandler technicalSupport = new TechnicalSupport();
        IHandler billing = new Billing();
        IHandler customerService = new CustomerService();

        technicalSupport.SetNext(billing);
        billing.SetNext(customerService);

        string request = "billing issue";
        technicalSupport.HandleRequest(request);
        
        request = "general inquiry";
        technicalSupport.HandleRequest(request);
        
        request = "technical problem";
        technicalSupport.HandleRequest(request);
    }
}
```

### Comparison: Chain of Responsibility vs Other Patterns

| Feature        | Chain of Responsibility                                                                          | Command Pattern                                                | State Pattern                                                |
| -------------- | ------------------------------------------------------------------------------------------------ | -------------------------------------------------------------- | ------------------------------------------------------------ |
| Purpose        | Pass requests through a chain                                                                    | Encapsulate requests as objects                                | Manage state transitions                                     |
| Responsibility | Distributes responsibility                                                                       | Assigns responsibility to specific handlers                    | Transitions between states based on conditions               |
| Flexibility    | High flexibility in chaining handlers                                                            | Low flexibility (commands are fixed)                           | Transitions are limited to states                            |
| When to Use    | When multiple handlers can process requests, but the specific handler is not known ahead of time | When you need to decouple the sender and receiver of a request | When you need to manage different states an object can be in |

### Problems Solved by Chain of Responsibility Pattern
- ✅ Decoupling Request Senders and Handlers – The sender doesn't need to know which handler will process the request, promoting flexibility.
- ✅ Multiple Handlers for Requests – Allows different parts of a system to handle a request without hard-coding specific handlers.
- ✅ Dynamic Request Processing – The chain can be modified dynamically to add new handlers or change the handling order.
- ✅ Simplifies Complex Conditionals – Prevents the need for complex condition checks in a single handler or class.

### Conclusion

The Chain of Responsibility Pattern is a behavioral pattern that allows requests to be processed by a series of handlers. It helps to decouple request senders from their handlers, distributes responsibilities, and allows for dynamic chain configurations. Whether you're building customer service systems, event-driven architectures, or workflows, this pattern simplifies processing and enhances flexibility.
