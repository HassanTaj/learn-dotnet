# Visitor Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Represent an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates."

### Simplified Explanation

- The **Visitor Pattern** allows you to add further operations to an **object structure** without modifying the structures themselves.
- It involves **separating algorithms** from the objects on which they operate. Instead of adding functionality directly to the objects, you add it to a **visitor** class that can visit the objects.
- This pattern is useful when you have an **object structure** that needs to be operated upon in different ways, and you want to add new operations without altering the classes of the objects.

## Background

The Visitor Pattern is useful when you need to perform operations on objects of various types in an object structure, and you want to **avoid altering** the classes themselves. This is commonly used in **complex object structures**, such as abstract syntax trees, data models, or UI components, where you need to perform operations like **rendering**, **validation**, or **logging**.

### Example: Shape Visitor

Consider a drawing application where you have various shapes, such as **Circle**, **Rectangle**, and **Triangle**, and you want to apply various operations to them (e.g., **area calculation**, **drawing**).

Instead of adding the operations directly to each shape class, we use the **Visitor Pattern** to add new operations without modifying the shape classes.

## Implementation

### Step 1: Define the Visitor Interface

```csharp
public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
    void Visit(Triangle triangle);
}
```

### Step 2: Create Concrete Visitors

```csharp
public class AreaCalculator : IShapeVisitor
{
    public void Visit(Circle circle)
    {
        double area = Math.PI * Math.Pow(circle.Radius, 2);
        Console.WriteLine($"Area of Circle: {area}");
    }

    public void Visit(Rectangle rectangle)
    {
        double area = rectangle.Width * rectangle.Height;
        Console.WriteLine($"Area of Rectangle: {area}");
    }

    public void Visit(Triangle triangle)
    {
        double area = 0.5 * triangle.Base * triangle.Height;
        Console.WriteLine($"Area of Triangle: {area}");
    }
}

public class DrawingVisitor : IShapeVisitor
{
    public void Visit(Circle circle)
    {
        Console.WriteLine("Drawing Circle");
    }

    public void Visit(Rectangle rectangle)
    {
        Console.WriteLine("Drawing Rectangle");
    }

    public void Visit(Triangle triangle)
    {
        Console.WriteLine("Drawing Triangle");
    }
}
```

### Step 3: Define the Elements (Shapes)

```csharp
public interface IShape
{
    void Accept(IShapeVisitor visitor);
}

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius) => Radius = radius;

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

public class Triangle : IShape
{
    public double Base { get; }
    public double Height { get; }

    public Triangle(double baseLength, double height)
    {
        Base = baseLength;
        Height = height;
    }

    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}
```

### Step 4: Use Visitor in Client Code

```csharp
class Program
{
    static void Main()
    {
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(10, 5);
        IShape triangle = new Triangle(6, 3);

        IShapeVisitor areaVisitor = new AreaCalculator();
        IShapeVisitor drawingVisitor = new DrawingVisitor();

        circle.Accept(areaVisitor);
        rectangle.Accept(areaVisitor);
        triangle.Accept(areaVisitor);

        circle.Accept(drawingVisitor);
        rectangle.Accept(drawingVisitor);
        triangle.Accept(drawingVisitor);
    }
}
```

### Comparison: Visitor vs Other Patterns

| Feature     | Visitor Pattern                                                         | Strategy Pattern                                                 | Command Pattern                                               |
| ----------- | ----------------------------------------------------------------------- | ---------------------------------------------------------------- | ------------------------------------------------------------- |
| Purpose     | Allows operations to be added to objects without changing their classes | Allows algorithms to be selected dynamically at runtime          | Encapsulates requests as objects                              |
| Structure   | Defines operations in separate classes (Visitors)                       | Encapsulates algorithms as objects                               | Defines requests that can be executed or undone               |
| Flexibility | Adds new operations easily by creating new visitors                     | Swaps behavior dynamically without altering the context          | Separates requests from the code that invokes them            |
| When to Use | When you need to add new operations without modifying object structure  | When you need to vary an algorithm independently from the client | When you need to decouple the sender and receiver of requests |


### Problems Solved by Visitor Pattern
- ✅ Adding New Operations Without Modifying Objects – The pattern allows you to add new operations to an object structure without changing the object classes.
- ✅ Separation of Concerns – It separates the logic for performing operations from the object structure, making it easier to maintain.
- ✅ Extending Functionality – You can extend the functionality of existing objects by creating new visitors.
- ✅ Visitor Chaining – Supports the ability to perform multiple operations on an object structure by chaining visitors together.
- ✅ Easier Maintenance – Since the object structure is not modified, maintenance of objects and operations is easier and less prone to errors.

### Conclusion

The Visitor Pattern is a behavioral pattern that lets you add operations to an object structure without modifying the objects themselves. It is highly useful in scenarios where you need to perform multiple operations on a set of objects, and you want to avoid changing their classes. By creating a visitor that "visits" each object, you can easily add new operations and maintain flexibility in the system. Whether you're dealing with complex data structures, abstract syntax trees, or custom operations, the Visitor Pattern helps manage the operations effectively and without breaking existing code.
