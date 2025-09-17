# Memento Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Without violating encapsulation, captures and externalizes an object’s internal state so that the object can be restored to this state later."*

### **Simplified Explanation**

- The Memento Pattern lets us **save and restore an object’s state** without exposing its internal implementation.  
- It involves three roles:  
  - **Originator** – The object whose state needs to be saved.  
  - **Memento** – A snapshot of the Originator’s state.  
  - **Caretaker** – Manages saved states (but cannot modify them).  
- Commonly used for **undo/redo functionality** in applications.  

## **Background**

The Memento Pattern is useful when:  
- You need to implement **undo/redo operations**.  
- You want to **save checkpoints** in a system.  
- You must **protect encapsulation**—the internal state should not be exposed to external classes.  

### **Example: Text Editor with Undo Feature**

Consider a text editor where the user types text.  
- The **Originator** is the text editor.  
- Each version of the text is stored as a **Memento**.  
- The **Caretaker** manages the history of states, allowing undo/redo functionality.  

## **Implementation**

### **Step 1: Create the Memento Class**

```csharp
public class Memento
{
    public string State { get; }
    public Memento(string state) => State = state;
}
```

## **Step 2: Create the Originator**

```csharp
public class TextEditor
{
    public string Text { get; private set; } = "";

    public void Type(string words)
    {
        Text += words;
    }

    public Memento Save()
    {
        return new Memento(Text);
    }

    public void Restore(Memento memento)
    {
        Text = memento.State;
    }

    public void Print()
    {
        Console.WriteLine("Current Text: " + Text);
    }
}
```

## **Step 3: Create the Caretaker**

```chsarp
public class History
{
    private readonly Stack<Memento> mementos = new();

    public void Save(Memento m) => mementos.Push(m);
    public Memento Undo() => mementos.Pop();
}
```

## Step 4: Use Memento in Client Code

```csharp
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var history = new History();

        editor.Type("Hello ");
        editor.Type("World!");
        editor.Print();

        history.Save(editor.Save());

        editor.Type(" More text...");
        editor.Print();

        editor.Restore(history.Undo());
        editor.Print();
    }
}
```

## Comparison: Memento vs Command

| Feature       | Memento Pattern                             | Command Pattern                                    |
| ------------- | ------------------------------------------- | -------------------------------------------------- |
| Purpose       | ✅ Captures and restores object state        | ✅ Encapsulates a request as an object              |
| Focus         | ✅ State management (undo/redo, checkpoints) | ✅ Action management (execute, queue, log requests) |
| Encapsulation | ✅ Preserves internal state privacy          | ❌ State may need to be exposed in command logic    |
| Best for      | ✅ Undo/Redo functionality                   | ✅ Task scheduling, transactional behavior          |


## Problems Solved by the Memento Pattern

- ✅ **Enables Undo/Redo** – Restores objects to previous states seamlessly.  
- ✅ **Preserves Encapsulation** – Keeps internal details hidden from external objects.  
- ✅ **Supports Checkpointing** – Allows saving snapshots of state at key moments.  
- ✅ **Improves Maintainability** – Provides a clean way to manage object state history.  
