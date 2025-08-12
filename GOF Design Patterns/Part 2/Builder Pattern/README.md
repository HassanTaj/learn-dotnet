# Builder Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Separates the construction of a complex object from its representation so that the same construction process can create different representations."

### Simplified Explanation

- The Builder Pattern is used to **construct complex objects** step by step.
- It allows you to **build different representations** of the same type of object.
- The pattern is helpful when you need to create an object with **many possible configurations**.

## Background

The Builder Pattern is ideal when you need to create a complex object with many attributes or when the object construction process is intricate. Instead of calling a constructor with lots of parameters or having a complex constructor, you can use the **builder** to gradually set the various parts of the object.

### Example: Building a Custom House

Imagine you're building a house. A builder can help you construct a house with different configurations, such as:

- Different types of rooms (kitchen, living room, bedroom).
- Multiple floor plans.
- Options for furniture, paint, and accessories.

The builder would manage all these complex configurations in a systematic manner.

## Implementation

### Step 1: Define the Product

```csharp
public class House
{
    public string Foundation { get; set; }
    public string Walls { get; set; }
    public string Roof { get; set; }
    public string Doors { get; set; }
    public string Windows { get; set; }
}
```
### Step 2: Define the Builder Interface
```csharp
public interface IHouseBuilder
{
    void BuildFoundation();
    void BuildWalls();
    void BuildRoof();
    void BuildDoors();
    void BuildWindows();
    House GetHouse();
}
```
### Step 3: Create Concrete Builder
```csharp
public class ConcreteHouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public void BuildFoundation() => _house.Foundation = "Concrete foundation";

    public void BuildWalls() => _house.Walls = "Brick walls";

    public void BuildRoof() => _house.Roof = "Concrete roof";

    public void BuildDoors() => _house.Doors = "Wooden doors";

    public void BuildWindows() => _house.Windows = "Glass windows";

    public House GetHouse() => _house;
}
```
### Step 4: Define the Director
```csharp
public class HouseDirector
{
    private readonly IHouseBuilder _builder;

    public HouseDirector(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public House ConstructHouse()
    {
        _builder.BuildFoundation();
        _builder.BuildWalls();
        _builder.BuildRoof();
        _builder.BuildDoors();
        _builder.BuildWindows();
        return _builder.GetHouse();
    }
}
```
### Step 5: Use Builder in Client Code
```csharp
class Program
{
    static void Main()
    {
        IHouseBuilder builder = new ConcreteHouseBuilder();
        HouseDirector director = new HouseDirector(builder);
        
        House house = director.ConstructHouse();
        
        Console.WriteLine($"House built with: {house.Foundation}, {house.Walls}, {house.Roof}, {house.Doors}, {house.Windows}");
    }
}
```
### Comparison: Builder vs Other Patterns

| Feature     | Builder Pattern                              | Abstract Factory                              | Factory Method                                       |
| ----------- | -------------------------------------------- | --------------------------------------------- | ---------------------------------------------------- |
| Purpose     | Construct complex objects step-by-step       | Create families of related objects            | Create a single product                              |
| Complexity  | High                                         | Medium                                        | Low                                                  |
| Focus       | Object creation process                      | Object families                               | Individual object creation                           |
| Flexibility | Very flexible in customizing object creation | Less flexible, but ensures object consistency | Less flexible and typically produces a single object |


### Problems Solved by Builder Pattern
- Object Construction Complexity – Helps manage the complexity of constructing objects with many parts or configurations.
- Separation of Concerns – Separates the construction logic from the object's representation, which makes the code easier to maintain and test.
- Readable Code – Using a builder to construct objects leads to clearer and more readable client code compared to using constructors with long parameter lists.
- Flexibility – The builder allows the creation of different variations of an object, reducing the need for multiple constructors.

### Conclusion

The Builder Pattern is an excellent solution for creating complex objects in a controlled, step-by-step manner. It offers flexibility, readability, and better management of complex object construction processes. Whether you are building houses, complex UIs, or intricate data structures, the Builder Pattern makes it easier to create and manage your objects in a maintainable way.
