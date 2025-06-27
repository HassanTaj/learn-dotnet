# Abstract Factory Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Provides an interface for creating families of related or dependent objects without specifying their concrete classes."*

### **Simplified Explanation**

- The Abstract Factory Pattern is like the **Factory Method Pattern**, but at a higher level of abstraction.
- It is **a factory for other factories**, meaning it encapsulates the creation logic of multiple related objects.
- This pattern ensures that related objects are created together and are compatible with one another.

## **Background**

Abstract Factory is useful when the client needs to create objects that are **somehow related** but shouldn't specify their concrete classes. It helps when we need to ensure consistency among multiple related objects.

### **Example: Showroom Selling Samsung Smartphones**

Consider a showroom that exclusively sells smartphones and gets a query for **Samsung smart devices**. The showroom does not know the exact type of Samsung device to provide but knows that the customer is looking for a Samsung-branded smartphone.

This is where Abstract Factory comes into play—it allows us to create related objects (Samsung smart devices) without exposing the exact implementation to the client.

## **Implementation**

### **Step 1: Define Abstract Products**

```csharp
public interface IPhone
{
    void GetModelDetails();
}

public interface ITablet
{
    void GetTabletDetails();
}
```

### **Step 2: Create Concrete Products**

```csharp
public class GalaxyS21 : IPhone
{
    public void GetModelDetails() => Console.WriteLine("Samsung Galaxy S21");
}

public class GalaxyTab : ITablet
{
    public void GetTabletDetails() => Console.WriteLine("Samsung Galaxy Tab S7");
}
```

### **Step 3: Define Abstract Factory**

```csharp
public interface ISamsungFactory
{
    IPhone CreatePhone();
    ITablet CreateTablet();
}
```

### **Step 4: Implement Concrete Factory**

```csharp
public class SamsungFactory : ISamsungFactory
{
    public IPhone CreatePhone() => new GalaxyS21();
    public ITablet CreateTablet() => new GalaxyTab();
}
```

### **Step 5: Use Factory in Client Code**

```csharp
public class Showroom
{
    private readonly ISamsungFactory _factory;
    public Showroom(ISamsungFactory factory) => _factory = factory;
  
    public void DisplayProducts()
    {
        var phone = _factory.CreatePhone();
        var tablet = _factory.CreateTablet();
        phone.GetModelDetails();
        tablet.GetTabletDetails();
    }
}

class Program
{
    static void Main()
    {
        ISamsungFactory factory = new SamsungFactory();
        Showroom showroom = new Showroom(factory);
        showroom.DisplayProducts();
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

## **Problems Solved by Abstract Factory**

✅ **Encapsulation of Object Families** – Ensures that related objects are created together, maintaining consistency.
✅ **Decouples Implementation from Clients** – Clients depend on interfaces rather than concrete classes, improving maintainability.
✅ **Enhances Scalability** – Adding a new product family (e.g., another smartphone brand) only requires implementing a new factory.
✅ **Improves Code Maintainability** – Reduces dependencies between classes, leading to cleaner and more modular code.

## **Conclusion**

The Abstract Factory Pattern is a powerful design pattern for managing object creation in complex systems where multiple families of related objects exist. It enforces consistency, decouples implementations, and makes the system more maintainable and scalable. Whether you are developing cross-platform applications or ensuring consistent product creation in an enterprise system, Abstract Factory is a great choice.
