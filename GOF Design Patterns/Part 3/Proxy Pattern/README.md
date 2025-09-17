# Proxy Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Provides a surrogate or placeholder for another object to control access to it."*

### **Simplified Explanation**

- The Proxy Pattern creates a **stand-in (proxy) object** that controls access to the real object.  
- It is often used to add extra functionality like **lazy initialization, access control, logging, caching, or remote access**.  
- The client interacts with the proxy as if it were the real object, without knowing the difference.  

## **Background**

The Proxy Pattern is useful when:  
- The real object is **resource-intensive** (e.g., loading a large image or file).  
- You need to **add an access layer** (e.g., authentication, authorization).  
- You want to add **extra behaviors** (logging, caching, monitoring) without modifying the original object.  
- You need **remote proxies** to represent objects in different address spaces.  

### **Example: Image Viewer with Lazy Loading**

Suppose we have an application that loads large images.  
- The **RealImage** class loads the image from disk (expensive).  
- The **ProxyImage** class delays loading until the image is actually needed.  
- The client interacts with the proxy, which manages the real object’s lifecycle.  

## **Implementation**

### **Step 1: Define the Subject Interface**

```csharp
public interface IImage
{
    void Display();
}
```

## Step 2: Create the Real Subject

```csharp
public class RealImage : IImage
{
    private readonly string filename;

    public RealImage(string filename)
    {
        this.filename = filename;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading image: {filename}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {filename}");
    }
}
```

## Step 3: Create the Proxy

```csharp
public class ProxyImage : IImage
{
    private RealImage realImage;
    private readonly string filename;

    public ProxyImage(string filename)
    {
        this.filename = filename;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(filename);
        }
        realImage.Display();
    }
}
```

## Step 4: Use Proxy in Client Code

```csharp
class Program
{
    static void Main()
    {
        IImage image1 = new ProxyImage("photo1.jpg");
        IImage image2 = new ProxyImage("photo2.jpg");

        // Image is loaded only when Display is called
        image1.Display();
        image1.Display(); // Uses cached real object
        image2.Display();
    }
}
```

## Comparison: Proxy vs Decorator

| Feature      | Proxy Pattern                                | Decorator Pattern                                |
| ------------ | -------------------------------------------- | ------------------------------------------------ |
| Purpose      | ✅ Controls access to an object               | ✅ Adds new behavior to an object dynamically     |
| Transparency | ✅ Client often unaware of proxy              | ✅ Client aware object is being decorated         |
| Focus        | ✅ Access control, lazy loading, remote proxy | ✅ Extending functionality without changing class |
| Best for     | ✅ When object access needs regulation        | ✅ When behavior needs to be added at runtime     |

## Problems Solved by the Proxy Pattern

- ✅ **Enables Lazy Initialization** – Delays creation of expensive objects until they are actually needed.  
- ✅ **Controls Access** – Adds security layers like authentication and authorization.  
- ✅ **Supports Remote Proxies** – Represents objects in a different address space.  
- ✅ **Adds Extra Functionality** – Provides logging, caching, and monitoring without changing the real object.  
