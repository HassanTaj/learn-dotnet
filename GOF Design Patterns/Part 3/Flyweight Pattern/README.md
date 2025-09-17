# Flyweight Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Uses sharing to support large numbers of fine-grained objects efficiently."*

### **Simplified Explanation**

- The Flyweight Pattern is used to **minimize memory usage** when creating large numbers of similar objects.  
- Instead of creating duplicate objects, it **shares existing instances** wherever possible.  
- It separates **intrinsic state (shared)** from **extrinsic state (unique per object)** to achieve efficiency.  

## **Background**

The Flyweight Pattern is useful when:  
- A system has to support a **large number of objects**.  
- Many objects are **similar in nature** but differ only in a few attributes.  
- We want to **reduce memory usage** and improve performance by sharing common state.  

### **Example: Characters in a Text Editor**

A text editor may need to display millions of characters.  
- Instead of creating a separate object for every single character, the Flyweight Pattern allows **sharing one object per character type** (A, B, C, etc.).  
- The **intrinsic state** (character shape/font) is shared, while the **extrinsic state** (position, color) is passed in at runtime.  

## **Implementation**

### **Step 1: Define the Flyweight Interface**

```csharp
public interface ICharacter
{
    void Display(int x, int y);
}
```

## **Step 2: Create Concrete Flyweights**

```csharp
public class Character : ICharacter
{
    private readonly char symbol; // Intrinsic state

    public Character(char symbol)
    {
        this.symbol = symbol;
    }

    public void Display(int x, int y) // Extrinsic state
    {
        Console.WriteLine($"Character: {symbol} at ({x},{y})");
    }
}
```

## **Step 3: Create the Flyweight Factory**

```csharp
public class CharacterFactory
{
    private readonly Dictionary<char, ICharacter> characters = new();

    public ICharacter GetCharacter(char symbol)
    {
        if (!characters.ContainsKey(symbol))
        {
            characters[symbol] = new Character(symbol);
            Console.WriteLine($"Created new Character object for '{symbol}'");
        }
        return characters[symbol];
    }
}
```

## **Step 4: Use Flyweight in Client Code**

```csharp
class Program
{
    static void Main()
    {
        var factory = new CharacterFactory();

        string text = "AABBC";
        int x = 0;

        foreach (char c in text)
        {
            ICharacter character = factory.GetCharacter(c);
            character.Display(x, 10);
            x += 5;
        }
    }
}
```

## **Comparison: Flyweight vs Singleton**

| Feature  | Flyweight Pattern                                 | Singleton Pattern                                       |
| -------- | ------------------------------------------------- | ------------------------------------------------------- |
| Purpose  | ✅ Share objects to reduce memory usage            | ✅ Ensure only one instance exists in the system         |
| Scope    | ✅ Many shared instances                           | ✅ Exactly one global instance                           |
| Focus    | ✅ Efficiency in handling large numbers of objects | ✅ Controlled global access point                        |
| Best for | ✅ Systems with lots of repeated objects           | ✅ Situations requiring only one instance (e.g., config) |


## Problems Solved by the Flyweight Pattern

- ✅ **Reduces Memory Usage** – Avoids duplicate objects by sharing intrinsic state.  
- ✅ **Improves Performance** – Efficient handling of large numbers of fine-grained objects.  
- ✅ **Supports Large-Scale Systems** – Makes systems with millions of similar objects feasible.  
- ✅ **Separates Intrinsic vs Extrinsic State** – Provides a clean design distinction, improving maintainability.  
