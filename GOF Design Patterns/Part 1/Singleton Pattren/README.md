# Singleton Pattern

## **Gang of Four Definition**

According to the Gang of Four (GoF):

> *"Ensure a class has only one instance and provides a global point of access to it. Singleton defines an instance operation that lets clients access its unique instance."*

### **Simplified Explanation**

- The Singleton Pattern restricts a class to having **only one instance**.
- It provides a **global point of access** to that instance.
- This is useful when exactly one object is needed to coordinate actions across the system.

## **Background**

Singleton is useful when you want to **control access** to some shared resource (e.g., configuration settings, logging service, or a database connection).  
Instead of creating multiple instances that could cause inconsistencies, the Singleton ensures **only one** object exists.

### **Example: Application Configuration Manager**

Imagine a system that loads configuration settings from a file.  
You want to ensure that every part of the application uses the **same configuration instance** to avoid conflicts.

## **Implementation**

### **Step 1: Create the Singleton Class**

```csharp
public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();

    // Private constructor prevents direct instantiation
    private ConfigurationManager()
    {
        Console.WriteLine("Loading configuration...");
    }

    public static ConfigurationManager Instance
    {
        get
        {
            // Double-checked locking for thread safety
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }

    public void ShowSettings()
    {
        Console.WriteLine("Configuration settings displayed here.");
    }
}
```

### Step 2: Use Singleton in Client Code

```csharp
class Program
{
    static void Main()
    {
        var config1 = ConfigurationManager.Instance;
        var config2 = ConfigurationManager.Instance;

        config1.ShowSettings();

        Console.WriteLine(Object.ReferenceEquals(config1, config2)
            ? "Both references point to the same instance."
            : "Different instances exist.");
    }
}
```
### Comparison: Singleton Pattern vs Static Class

| Feature                  | Singleton Pattern               | Static Class                       |
| ------------------------ | ------------------------------- | ---------------------------------- |
| Instance Control         | Single instance, lazily created | No instance, methods always static |
| Interfaces & Inheritance | ✅ Yes                           | ❌ No                               |
| Thread Safety            | Can be implemented              | Not applicable                     |
| State Maintenance        | ✅ Yes                           | ✅ Yes                              |

### Problems Solved by Singleton Pattern

- ✅ **Controlled Access** – Only one instance manages access to a resource.
- ✅ **Global Access Point** – Instance can be accessed anywhere in the application.
- ✅ **Lazy Initialization** – Instance is created only when needed.
- ✅ **Thread Safety** – Can be implemented to ensure safe access in multi-threaded environments.


### Conclusion

The Singleton Pattern ensures that only one instance of a class exists while providing a single global point of access to it.
It’s perfect for shared resources such as configuration managers, logging services, or device drivers. However, it should be used sparingly to avoid making the code too dependent on global state.
