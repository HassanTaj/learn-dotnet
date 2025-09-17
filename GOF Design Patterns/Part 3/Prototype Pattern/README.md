# Prototype Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype."*

### **Simplified Explanation**

- The Prototype Pattern allows you to **create new objects by cloning existing ones** instead of instantiating them from scratch.  
- It avoids costly object creation (especially for resource-heavy objects).  
- Clients can create new objects **without knowing their exact classes**—only needing a prototype to clone.  

## **Background**

The Prototype Pattern is useful when:  
- Object creation is **expensive** (e.g., large data, complex initialization).  
- We need to **avoid subclassing** to create object variants.  
- We want to **decouple client code** from the concrete classes.  

### **Example: Document Cloning System**

Imagine a document editor where you want to create new documents (Word, Excel, PDF).  
- Instead of instantiating from scratch every time, you can keep a **prototype of each document type**.  
- When needed, simply **clone the prototype** to get a new copy.  

## **Implementation**

### **Step 1: Define the Prototype Interface**

```csharp
public interface IPrototype<T>
{
    T Clone();
}
```

## Step 2: Create Concrete Prototypes

```csharp
public class Document : IPrototype<Document>
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Document(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public Document Clone()
    {
        return (Document)this.MemberwiseClone();
    }

    public void Print()
    {
        Console.WriteLine($"Title: {Title}, Content: {Content}");
    }
}
```

## Step 3: Use Prototype in Client Code

```csharp
class Program
{
    static void Main()
    {
        // Original document
        var original = new Document("Report", "This is the original content.");
        original.Print();

        // Clone document
        var copy = original.Clone();
        copy.Title = "Copied Report"; // Modify clone without affecting original
        copy.Print();

        // Verify original remains unchanged
        original.Print();
    }
}
```

## Comparison: Prototype vs Factory Method

| Feature         | Prototype Pattern                             | Factory Method Pattern                          |
| --------------- | --------------------------------------------- | ----------------------------------------------- |
| Purpose         | ✅ Create new objects by cloning existing ones | ✅ Create new objects through subclass factories |
| Object Creation | ✅ Based on existing prototype                 | ✅ Based on class instantiation                  |
| Extensibility   | ✅ Easy to add new prototypes                  | ✅ Easy to introduce new factory subclasses      |
| Best for        | ✅ When object creation is expensive/complex   | ✅ When creating families of related objects     |

## Problems Solved by the Prototype Pattern

- ✅ **Simplifies Object Creation** – Eliminates complex instantiation by cloning existing objects.  
- ✅ **Improves Performance** – Avoids expensive initialization when creating many similar objects.  
- ✅ **Supports Dynamic Object Configuration** – Objects can be customized and cloned at runtime.  
- ✅ **Reduces Class Hierarchies** – Avoids subclassing just to create variations of an object.  
