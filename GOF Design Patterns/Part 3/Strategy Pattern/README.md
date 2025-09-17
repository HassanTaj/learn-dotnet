# Strategy Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it."*

### **Simplified Explanation**

- The Strategy Pattern allows you to **define multiple algorithms** for a task and choose which one to use at runtime.  
- It encapsulates each algorithm in its own class, following the **Open/Closed Principle** (open for extension, closed for modification).  
- Clients can switch strategies dynamically without changing their code.  

## **Background**

The Strategy Pattern is useful when:  
- You want to **choose between multiple algorithms** at runtime.  
- You need to **avoid code duplication** caused by multiple conditional branches.  
- You want to keep algorithms **separate and reusable** across different clients.  

### **Example: Payment Processing System**

Imagine an e-commerce application that supports multiple payment methods (**Credit Card, PayPal, and Crypto**).  
Instead of hardcoding all logic into one class, each payment method is encapsulated into its own **Strategy** class.  

## **Implementation**

### **Step 1: Define the Strategy Interface**

```csharp
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}
```

### Step 2: Create Concrete Strategies

```csharp
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using Credit Card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using PayPal.");
    }
}

public class CryptoPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using Cryptocurrency.");
    }
}
```

### Step 3: Create the Context

```csharp
public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void PayAmount(decimal amount)
    {
        _strategy.Pay(amount);
    }
}
```

### Step 4: Use Strategy in Client Code

```csharp
class Program
{
    static void Main()
    {
        PaymentContext context = new PaymentContext();

        context.SetStrategy(new CreditCardPayment());
        context.PayAmount(100);

        context.SetStrategy(new PayPalPayment());
        context.PayAmount(200);

        context.SetStrategy(new CryptoPayment());
        context.PayAmount(300);
    }
}
```

### Comparison: Strategy vs State

| Feature            | Strategy Pattern                                 | State Pattern                                 |
| ------------------ | ------------------------------------------------ | --------------------------------------------- |
| Purpose            | ✅ Select from a family of algorithms             | ✅ Change behavior when internal state changes |
| Trigger for Change | ✅ Chosen externally by the client                | ✅ Triggered internally by the context         |
| Focus              | ✅ Algorithm encapsulation and interchangeability | ✅ Modeling dynamic state transitions          |
| Best for           | ✅ Replacing conditional logic for algorithms     | ✅ Representing objects with multiple states   |


### Problems Solved by the Strategy Pattern

- ✅ **Eliminates Conditional Logic** – Removes complex `if/else` or `switch` statements for algorithm selection.  
- ✅ **Encapsulates Algorithms** – Keeps each algorithm separate and reusable.  
- ✅ **Supports Runtime Flexibility** – Clients can change strategies dynamically.  
- ✅ **Improves Maintainability** – Adding new strategies doesn’t require modifying existing code.  
