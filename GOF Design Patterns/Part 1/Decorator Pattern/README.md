Decorator Pattern

Gang of Four Definition
According to the Gang of Four (GoF):

    "The Decorator Pattern attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality."

Simplified Explanation
The Decorator Pattern is about using composition to dynamically add new behavior to objects, instead of relying on inheritance. Rather than creating a subclass to extend functionality, decorators "wrap" an existing object and enhance its behavior. This allows you to add or modify behavior without changing the original object's structure.

Background
Decorator is useful when you want to extend the functionality of an object without modifying its existing code or class hierarchy. It’s particularly helpful when dealing with classes that might need different, interchangeable behaviors at runtime, without creating a large number of subclasses.

Example: Adding Features to a Coffee Order

Imagine a coffee shop that offers basic coffee, but you want to add extra features like milk, sugar, or whipped cream dynamically. Instead of creating multiple subclasses for each type of coffee with different combinations of add-ons, you can use decorators to dynamically enhance the coffee object with the desired features.

Implementation
Step 1: Define the Component Interface

public interface ICoffee
{
    string GetDescription();
    double Cost();
}

Step 2: Create Concrete Component

public class BasicCoffee : ICoffee
{
    public string GetDescription() => "Basic Coffee";
    public double Cost() => 5.00;
}

Step 3: Define Decorator Base Class

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee) => _coffee = coffee;

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double Cost() => _coffee.Cost();
}

Step 4: Implement Concrete Decorators

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

Step 5: Use Decorators in Client Code

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

Comparison: Decorator vs. Inheritance
Feature	Decorator Pattern	Inheritance
Extends functionality	✅ Dynamically at runtime	❌ Fixed at compile-time
Flexibility	✅ High (Can add or remove features at runtime)	❌ Low (Requires subclassing for every new feature)
Composability	✅ Can compose multiple decorators	❌ Inheritance tree can become deep and rigid
Maintainability	✅ Easier to maintain (modular features)	❌ Can lead to code duplication and rigid structures

Problems Solved by the Decorator Pattern
✅ Flexible Object Extension – Enables dynamic behavior addition without changing the original object.
✅ Reduced Subclassing – Eliminates the need for multiple subclasses, reducing complexity and promoting reusable code.
✅ Modular Design – Each decorator represents a specific feature or behavior, leading to a cleaner and more modular design.
✅ Runtime Composition – Offers the ability to mix and match behaviors at runtime, making it easier to create customized objects.

Conclusion
The Decorator Pattern is a powerful way to extend the functionality of objects without modifying their underlying class structure. It provides a flexible, dynamic alternative to subclassing and offers a cleaner, more modular approach to adding behaviors. Whether it's adding features to a basic object or combining multiple behaviors in a scalable way, the Decorator Pattern is essential for creating flexible and maintainable object-oriented designs.
