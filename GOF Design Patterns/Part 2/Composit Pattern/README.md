# Composite Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly."

### Simplified Explanation

- The **Composite Pattern** allows you to treat individual objects and compositions of objects in the same way.
- This pattern is useful when you need to work with a **tree structure** of objects where both the leaves and the branches are treated uniformly.
- It helps to **compose objects** into tree-like structures to represent part-whole hierarchies, making it easier to manage complex systems with nested objects.

## Background

The Composite Pattern is most useful when you have a **hierarchical structure** of objects, and you want to be able to treat both individual objects and groups of objects uniformly. It allows clients to work with both **simple objects** and **composed objects** in the same way without having to know the difference.

### Example: File System Structure

Consider a file system where you have both **files** and **folders**. A folder can contain other folders or files, forming a **tree structure**.

- **File** is a leaf in the tree structure.
- **Folder** is a composite object that can contain other files or folders.

With the Composite Pattern, both files and folders can be treated uniformly.

## Implementation

### Step 1: Define the Component Interface

```csharp
public interface IComponent
{
    void Display();
}
```

### Step 2: Create Leaf Objects

```csharp
public class File : IComponent
{
    private readonly string _name;

    public File(string name) => _name = name;

    public void Display() => Console.WriteLine($"File: {_name}");
}
```

### Step 3: Create Composite Objects

```csharp
public class Folder : IComponent
{
    private readonly List<IComponent> _children = new List<IComponent>();
    private readonly string _name;

    public Folder(string name) => _name = name;

    public void Add(IComponent component) => _children.Add(component);
    
    public void Remove(IComponent component) => _children.Remove(component);

    public void Display()
    {
        Console.WriteLine($"Folder: {_name}");
        foreach (var child in _children)
        {
            child.Display();
        }
    }
}
```

### Step 4: Use Composite in Client Code

```csharp
class Program
{
    static void Main()
    {
        IComponent file1 = new File("File1.txt");
        IComponent file2 = new File("File2.txt");
        IComponent folder1 = new Folder("Folder1");
        
        folder1.Add(file1);
        folder1.Add(file2);
        
        IComponent folder2 = new Folder("Folder2");
        folder2.Add(new File("File3.txt"));
        
        IComponent root = new Folder("Root");
        root.Add(folder1);
        root.Add(folder2);
        
        root.Display();
    }
}
```
### Comparison: Composite vs Other Patterns

| Feature     | Composite Pattern                        | Decorator Pattern                                                 | Strategy Pattern                                                |
| ----------- | ---------------------------------------- | ----------------------------------------------------------------- | --------------------------------------------------------------- |
| Purpose     | Treat objects and composites uniformly   | Add additional responsibilities to an object dynamically          | Change behavior of an object at runtime                         |
| Structure   | Hierarchical tree structure              | Single object with added responsibilities                         | Defines multiple strategies for behavior                        |
| Flexibility | High flexibility in object composition   | Focuses on adding behavior to one object                          | Focuses on changing behavior of an object                       |
| When to Use | When objects form part-whole hierarchies | When you need to add behavior without changing the object’s class | When you need to choose between different behaviors dynamically |

### Problems Solved by Composite Pattern

- ✅ Uniform Treatment of Objects and Composites – Allows both individual objects and groups of objects to be treated uniformly.
- ✅ Simplifies Tree Structure Management – Makes it easier to work with hierarchical structures by treating all elements in the hierarchy the same way.
- ✅ Easier to Add New Types of Components – You can easily extend the system to include new types of leaf or composite objects.
- ✅ Reduces Complexity in Client Code – The client code can work with all objects (whether they are leaves or composites) using a single interface.
- ✅ Supports Recursive Composition – Supports complex tree structures with recursive compositions.

### Conclusion

The Composite Pattern is a structural pattern that allows you to treat both individual objects and compositions of objects uniformly. It’s most effective when working with tree structures, such as file systems or UI components. The pattern simplifies the management of complex hierarchies and allows you to easily add new components or modify the structure without changing the client code. Whether you're working on file systems, graphical user interfaces, or any application involving hierarchical data, the Composite Pattern can be a powerful tool to simplify your design.
