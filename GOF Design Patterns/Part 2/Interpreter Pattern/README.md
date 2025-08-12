# Interpreter Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language."

### Simplified Explanation

- The **Interpreter Pattern** is used to interpret sentences in a **language**. It defines the grammar of the language and provides an interpreter to evaluate or interpret expressions written in that language.
- This pattern is commonly used for **domain-specific languages** (DSLs) or when you need to **interpret complex expressions** and execute corresponding operations.

## Background

The Interpreter Pattern is useful when you need to process or evaluate expressions that are structured according to specific rules. It is often used in scenarios where you need to interpret a language, such as:

- **Mathematical expressions** (e.g., "3 + 5 * 2")
- **Text parsing** (e.g., extracting information from a natural language)
- **Configuration files** (e.g., interpreting a DSL for configuration)

### Example: Simple Arithmetic Expression Interpreter

Consider an arithmetic expression, such as "5 + 3 * 2". We want to interpret this expression and compute its result based on standard operator precedence.

## Implementation

### Step 1: Define the Abstract Expression

```csharp
public interface IExpression
{
    int Interpret();
}
```

### Step 2: Create Terminal Expressions

```csharp
public class Number : IExpression
{
    private readonly int _value;

    public Number(int value) => _value = value;

    public int Interpret() => _value;
}
```

### Step 3: Create Non-Terminal Expressions (Operators)

```csharp
public class Add : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public Add(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret() => _left.Interpret() + _right.Interpret();
}

public class Multiply : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public Multiply(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret() => _left.Interpret() * _right.Interpret();
}
```

### Step 4: Use Interpreter in Client Code

```csharp
class Program
{
    static void Main()
    {
        // Build expression: (5 + 3) * 2
        IExpression five = new Number(5);
        IExpression three = new Number(3);
        IExpression two = new Number(2);

        IExpression add = new Add(five, three);
        IExpression multiply = new Multiply(add, two);

        Console.WriteLine($"Result: {multiply.Interpret()}");  // Output: 16
    }
}
```
### Comparison: Interpreter vs Other Patterns

| Feature     | Interpreter Pattern                                  | Strategy Pattern                                     | Command Pattern                                        |
| ----------- | ---------------------------------------------------- | ---------------------------------------------------- | ------------------------------------------------------ |
| Purpose     | Define grammar and interpret expressions             | Define algorithms for dynamic selection              | Encapsulate requests as objects                        |
| Structure   | Tree-like structure of expressions                   | Context-based behavior switching                     | Object-based encapsulation of actions                  |
| Flexibility | Interprets sentences or expressions based on grammar | Changes behavior dynamically at runtime              | Supports undo, queueing, and logging of commands       |
| When to Use | When you need to interpret or evaluate expressions   | When you need to choose between different algorithms | When you need to decouple request senders and handlers |


### Problems Solved by Interpreter Pattern
- ✅ Interpreting Domain-Specific Languages (DSLs) – The Interpreter Pattern is perfect for interpreting custom DSLs.
- ✅ Expression Evaluation – Allows for structured evaluation of expressions like mathematical, logical, or string-based expressions.
- ✅ Supports Complex Syntax Parsing – Helps in building parsers for languages or complex structures.
- ✅ Enhances Readability – Makes it easy to define and extend languages by using a tree structure.
- ✅ Reduces Code Complexity – Reduces the complexity of parsing and interpreting large or complex expressions by modularizing it.

### Conclusion

The Interpreter Pattern is a behavioral pattern that provides a way to interpret and evaluate expressions within a language, whether it's mathematical expressions, configuration files, or any other domain-specific language. It can greatly simplify tasks like parsing, evaluating, and executing expressions in a consistent and extensible manner. When you need to define and process languages or expressions, this pattern is invaluable for creating a flexible and maintainable solution.
