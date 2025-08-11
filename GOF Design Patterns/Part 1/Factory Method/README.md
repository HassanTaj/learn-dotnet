# Factory Method Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Define an interface for creating an object, but let subclasses decide which class to instantiate. This lets a class defer instantiation to subclasses."*

### **Simplified Explanation**

- The **Factory Method Pattern** allows programmers to request objects and have the correct type created behind the scenes and returned.
- It provides a way to delegate the responsibility of instantiation to subclasses, promoting loose coupling.

## **Background**

The Factory Method Pattern is useful when a class cannot anticipate the class of objects it needs to create. It allows for flexibility in object creation, enabling the introduction of new types without modifying existing code.

### **Example: Vehicle Manufacturing**

Consider a vehicle manufacturing company that produces different types of vehicles. The company has a method to create vehicles, but the exact type of vehicle (e.g., car, truck) is determined by subclasses.

This pattern allows the company to create various vehicle types without changing the core logic of the vehicle creation process.

## **Implementation**

### **Step 1: Define Product Interface**

```csharp
public interface IVehicle
{
    void GetVehicleType();
}
```

### Step 2: Create Concrete Products

```csharp
public class Car : IVehicle
{
    public void GetVehicleType() => Console.WriteLine("This is a Car.");
}

public class Truck : IVehicle
{
    public void GetVehicleType() => Console.WriteLine("This is a Truck.");
}
```

### Step 3: Define Creator Abstract Class

```csharp
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}
```

### Step 4: Implement Concrete Creators

```csharp
public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Car();
}

public class TruckFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Truck();
}
```

### Step 5: Use Factory in Client Code

```csharp
class Program
{
    static void Main()
    {
        VehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();
        car.GetVehicleType();

        VehicleFactory truckFactory = new TruckFactory();
        IVehicle truck = truckFactory.CreateVehicle();
        truck.GetVehicleType();
    }
}
```

## **Comparison: Factory Method vs Abstract Factory**

| Feature                          | Factory Method            | Abstract Factory                          |
| -------------------------------- | ------------------------- | ----------------------------------------- |
| Creates a single product         | ✅ Yes                    | ❌ No (creates multiple related products) |
| Level of abstraction             | Lower                     | Higher                                    |
| Encapsulation of object families | ❌ No                     | ✅ Yes                                    |
| Best for                         | Creating single instances | Creating related instances                |



### Problems Solved by Factory Method

- ✅ Decouples Object Creation – Clients are not tightly coupled to specific classes, allowing for easier changes and extensions.
- ✅ Promotes Code Reusability – Common logic can be reused in the creator class while allowing subclasses to define specific behavior.
- ✅ Enhances Flexibility – New product types can be introduced with minimal changes to existing code.
- ✅ Improves Code Maintainability – Reduces dependencies between classes, leading to cleaner and more modular code.

### Conclusion

The Factory Method Pattern is a fundamental design pattern that simplifies object creation by allowing subclasses to determine the specific class to instantiate. It promotes flexibility, reusability, and maintainability, making it an essential pattern for developers working on scalable and adaptable systems.
