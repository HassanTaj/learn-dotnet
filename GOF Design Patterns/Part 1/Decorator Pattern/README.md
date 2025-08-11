# Decorator Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "The Decorator Pattern attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality."

---

## Simplified Explanation

The Decorator Pattern is about using **composition** to dynamically add new behavior to objects, instead of relying on inheritance. Rather than creating a subclass to extend functionality, decorators "wrap" an existing object and enhance its behavior. This allows you to add or modify behavior without changing the original object's structure.

---

## Also Known As
The **Decorator Pattern** is sometimes referred to as the **Wrapper Pattern** because the processes it uses involve "wrapping" objects.

---

## Background

The Decorator Pattern is particularly useful when you want to extend the functionality of an object without modifying its existing code or class hierarchy. It’s helpful when an object needs to have different, interchangeable behaviors at runtime without the complexity of multiple subclasses.

### Example: Adding Features to a Coffee Order

Imagine a coffee shop that offers basic coffee, but you want to add extra features like milk, sugar, or whipped cream dynamically. Instead of creating multiple subclasses for each combination of features, you can use decorators to dynamically enhance the coffee object with the desired add-ons.

---

## Implementation

### Step 1: Define the Component Interface

```csharp
public interface ICoffee
{
    string GetDescription();
    double Cost();
}
```

### Step 2: Create Concrete Component

```csharp
public class BasicCoffee : ICoffee
{
    public string GetDescription() => "Basic Coffee";
    public double Cost() => 5.00;
}
```

### Step 3: Define Decorator Base Class

```csharp
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee) => _coffee = coffee;

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double Cost() => _coffee.Cost();
}
```

### Step 4: Implement Concrete Decorators

```csharp
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Milk";
    public override double Cost() => _coffee.Cost() + 1.50;
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Sugar";
    public override double Cost() => _coffee.Cost() + 0.75;
}
```

### Step 5: Use Decorators in Client Code

```csharp
class Program
{
    static void Main()
    {
        ICoffee coffee = new BasicCoffee();
        Console.WriteLine($"{coffee.GetDescription()} | Cost: {coffee.Cost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} | Cost: {coffee.Cost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} | Cost: {coffee.Cost()}");
    }
}
```

### Comparison: Decorator vs. Inheritance

| Feature               | Decorator Pattern                           | Inheritance                                            |
| --------------------- | ------------------------------------------- | ------------------------------------------------------ |
| Extends functionality | ✅ Dynamically at runtime                    | ❌ Fixed at compile-time                                |
| Flexibility           | ✅ High (Can add/remove features at runtime) | ❌ Low (Requires subclassing for each new feature)      |
| Composability         | ✅ Can combine multiple decorators           | ❌ Inheritance tree can become deep and rigid           |
| Maintainability       | ✅ Easier to maintain (modular features)     | ❌ Can lead to code duplication and complex hierarchies |


Problems Solved by the Decorator Pattern

✅ Flexible Object Extension – Enables dynamic behavior addition without changing the original object.
✅ Reduced Subclassing – Eliminates the need for multiple subclasses, reducing complexity and promoting reusable code.
✅ Modular Design – Each decorator represents a specific feature or behavior, leading to a cleaner and more modular design.
✅ Runtime Composition – Offers the ability to mix and match behaviors at runtime, making it easier to create customized objects.


### Conclusion

The Decorator Pattern is a powerful way to extend the functionality of objects without modifying their underlying class structure. It provides a flexible, dynamic alternative to subclassing and offers a cleaner, more modular approach to adding behaviors. Whether it's adding features to a basic object or combining multiple behaviors in a scalable way, the Decorator Pattern is essential for creating flexible and maintainable object-oriented designs.
