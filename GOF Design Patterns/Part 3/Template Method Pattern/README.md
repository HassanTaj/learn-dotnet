# Template Method Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Defines the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm’s structure."*

### **Simplified Explanation**

- The Template Method Pattern provides a **blueprint (template)** for an algorithm, while allowing subclasses to fill in the details.  
- The parent class defines the **algorithm skeleton**, and child classes override specific steps without altering the overall flow.  
- It ensures consistency in algorithm structure while allowing flexibility in specific implementations.  

## **Background**

The Template Method Pattern is useful when:  
- Multiple classes share the **same algorithm structure**, but differ in some implementation details.  
- You want to enforce a **consistent workflow**, while still allowing customization.  
- You want to avoid **duplicate code** across subclasses.  

### **Example: Data Processing**

Consider a data processor that:  
1. Reads data.  
2. Processes data.  
3. Writes data.  

The overall steps remain the same, but subclasses can define **how** data is read, processed, and written.  

## **Implementation**

### **Step 1: Define the Abstract Class with Template Method**

```csharp
public abstract class DataProcessor
{
    public void Process()
    {
        ReadData();
        ProcessData();
        WriteData();
    }

    protected abstract void ReadData();
    protected abstract void ProcessData();
    protected abstract void WriteData();
}
```

### Step 2: Implement Concrete Classes

```csharp
public class CsvDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading CSV data...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing CSV data...");
    }

    protected override void WriteData()
    {
        Console.WriteLine("Writing CSV output...");
    }
}

public class JsonDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading JSON data...");
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing JSON data...");
    }

    protected override void WriteData()
    {
        Console.WriteLine("Writing JSON output...");
    }
}
```

### Step 3: Use Template Method in Client Code

```csharp
class Program
{
    static void Main()
    {
        DataProcessor csvProcessor = new CsvDataProcessor();
        csvProcessor.Process();

        DataProcessor jsonProcessor = new JsonDataProcessor();
        jsonProcessor.Process();
    }
}
```

### Comparison: Template Method vs Strategy

| Feature             | Template Method Pattern                        | Strategy Pattern                          |
| ------------------- | ---------------------------------------------- | ----------------------------------------- |
| Algorithm Structure | ✅ Fixed by abstract class                      | ✅ Defined by interchangeable strategies   |
| Variation           | ✅ Achieved by overriding methods in subclasses | ✅ Achieved by swapping strategy objects   |
| Control             | ✅ Parent class controls the algorithm flow     | ✅ Client controls which strategy to use   |
| Best for            | ✅ Reusable algorithm skeletons                 | ✅ Flexible algorithm selection at runtime |


### Problems Solved by the Template Method Pattern

- ✅ **Enforces Algorithm Structure** – Guarantees that the overall flow remains consistent across implementations.  
- ✅ **Encapsulates Invariant Code** – Keeps common steps in the base class, avoiding duplication.  
- ✅ **Supports Customization** – Allows subclasses to redefine only the necessary parts of the algorithm.  
- ✅ **Improves Maintainability** – Adding new variations requires only subclassing without changing core logic.
