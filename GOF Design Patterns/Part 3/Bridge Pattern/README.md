# Bridge Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Decouples an abstraction from its implementation so that the two can vary independently."*

### **Simplified Explanation**

- The Bridge Pattern **separates abstraction (what something does)** from **implementation (how it does it)**.
- It allows both abstraction and implementation to **evolve independently** without tightly coupling them.
- This is achieved by using **composition over inheritance**—the abstraction holds a reference to the implementation.

## **Background**

The Bridge Pattern is useful when a class has multiple dimensions of change (e.g., shape type and rendering style). Instead of creating a large hierarchy of classes for every combination, the Bridge Pattern separates these concerns.

It is often used when:
- We want to **avoid a permanent binding** between abstraction and implementation.
- Both the abstraction and its implementation should be **extensible independently**.
- We want to **reduce class explosion** caused by multiplying inheritance hierarchies.

### **Example: Shapes with Drawing APIs**

Consider a scenario where we need to draw different shapes (like **Circle** and **Square**) using different drawing APIs (like **OpenGL** and **DirectX**).  

Without the Bridge Pattern, we would end up with many classes like `OpenGLCircle`, `DirectXCircle`, `OpenGLSquare`, `DirectXSquare`, and so on.  

The Bridge Pattern helps by **separating shape abstractions from drawing implementations**, reducing class explosion.

## **Implementation**

### **Step 1: Define the Implementor Interface**

```csharp
public interface IDrawAPI
{
    void DrawCircle(int radius, int x, int y);
}
```

### **Step 2: Create Concrete Implementations**

```csharp
public class OpenGLAPI : IDrawAPI
{
    public void DrawCircle(int radius, int x, int y)
        => Console.WriteLine($"OpenGL: Drawing Circle [radius={radius}, x={x}, y={y}]");
}

public class DirectXAPI : IDrawAPI
{
    public void DrawCircle(int radius, int x, int y)
        => Console.WriteLine($"DirectX: Drawing Circle [radius={radius}, x={x}, y={y}]");
}

```

### **Step 3: Define the Abstraction**

```csharp
public abstract class Shape
{
    protected IDrawAPI drawAPI;
    protected Shape(IDrawAPI api) => drawAPI = api;
    public abstract void Draw();
}
```

## **Step 4: Create Refined Abstractions**

```csharp
public class Circle : Shape
{
    private int x, y, radius;
    public Circle(int x, int y, int radius, IDrawAPI api) : base(api)
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public override void Draw()
    {
        drawAPI.DrawCircle(radius, x, y);
    }
}
```

## **Step 5: Use the Bridge in Client Code**
```csharp
class Program
{
    static void Main()
    {
        Shape circle1 = new Circle(10, 20, 5, new OpenGLAPI());
        Shape circle2 = new Circle(30, 40, 10, new DirectXAPI());

        circle1.Draw();
        circle2.Draw();
    }
}
```
## **Comparison: Bridge vs Adapter**

| Feature               | Bridge Pattern                              | Adapter Pattern                                       |
| --------------------- | ------------------------------------------- | ----------------------------------------------------- |
| Purpose               | ✅ Decouples abstraction from implementation | ✅ Makes incompatible interfaces work together        |
| Focus                 | ✅ Flexibility and extensibility             | ✅ Compatibility and reuse                            |
| Relationship          | ✅ Built at design time                      | ✅ Often applied retroactively                        |
| Best for              | ✅ Evolving systems with multiple dimensions | ✅ Integrating legacy code with new systems           |

### Problems Solved by the Bridge Pattern

- ✅ **Decouples Abstraction and Implementation** – Allows both to evolve independently.  
- ✅ **Reduces Class Explosion** – Avoids creating separate subclasses for every abstraction-implementation combination.  
- ✅ **Improves Extensibility** – New abstractions or implementations can be added without modifying existing code.  
- ✅ **Encourages Composition over Inheritance** – Promotes cleaner, more maintainable designs.  


## **Conclusion**

The Bridge Pattern is a powerful design pattern for separating abstraction from implementation. It prevents rigid inheritance structures, reduces code duplication, and promotes flexibility. Whether dealing with multiple platforms, UI rendering systems, or any scenario with two orthogonal dimensions of change, the Bridge Pattern is an elegant solution.
