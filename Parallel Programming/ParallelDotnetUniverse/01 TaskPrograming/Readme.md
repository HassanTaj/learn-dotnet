# Task Programming in .NET

## Overview

This module introduces **Task Programming** in .NET, which provides an abstraction for representing asynchronous operations.  
A **Task** is a unit of work that can run independently on a separate thread, managed by the .NET Task Scheduler.  

### Topics Covered
1. Creating and Starting Tasks  
2. Canceling Tasks  
3. Waiting for Time to Pass  
4. Waiting for Tasks  
5. Exception Handling  

---

## 1. What is a Task?

- A **Task** represents a unit of work.  
- It abstracts away thread management by letting the scheduler decide how and where to execute it.  
- Tasks can run asynchronously, return results, and be coordinated with other tasks.  

---

## 2. Creating and Starting Tasks

There are multiple ways to create and start tasks:

```csharp
// Method 1: Using Task.Factory.StartNew
Task.Factory.StartNew(() => Write('.'));

// Method 2: Explicit Task creation and Start()
var t = new Task(() => Write('?'));
t.Start();
Write('-');

// Passing arguments
Task t1 = new Task(Write, "Hello World");
t1.Start();
Task.Factory.StartNew(Write, 123);

// Returning values from tasks
string text1 = "Hello Task";
string text2 = "Parallel Programming";
var t2 = new Task<int>(TextLength, text1);
t2.Start();
Task<int> t3 = Task.Factory.StartNew(TextLength, text2);

Console.WriteLine($"Length of Text1: {t2.Result}");
Console.WriteLine($"Length of Text2: {t3.Result}");
```

### 3. Canceling Tasks

- Task cancellation is managed through `CancellationTokenSource` and `CancellationToken`.
- A task can be canceled by signaling the token.
- Multiple tokens can be linked for composite cancellation.

```csharp
var cts = new CancellationTokenSource();
var token = cts.Token;

// Register a callback when cancellation is requested
token.Register(() => Console.WriteLine("Cancellation requested"));

// Create a cancellable task
var t = new Task(() =>
{
    int i = 0;
    while (true)
    {
        token.ThrowIfCancellationRequested();
        Console.WriteLine($"{i++}");
    }
}, token);

t.Start();
Console.ReadKey();
cts.Cancel();
```

### Composite cancellation example:

```csharp
var planned = new CancellationTokenSource();
var preventative = new CancellationTokenSource();
var emergency = new CancellationTokenSource();

var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
    planned.Token, preventative.Token, emergency.Token);

Task.Factory.StartNew(() =>
{
    int i = 0;
    while (true)
    {
        paranoid.Token.ThrowIfCancellationRequested();
        Console.WriteLine($"{i++}\t");
        Thread.Sleep(1000);
    }
}, paranoid.Token);

Console.ReadKey();
emergency.Cancel();
```

### 4. Waiting for Time to Pass

Tasks can pause execution in different ways:

- `Thread.Sleep()` – Pauses execution and yields the processor.
- `SpinWait / SpinUntil` – Keeps CPU busy without yielding (less efficient, but doesn’t lose queue position).
- `Waiting with CancellationToken` – Waits with a timeout and reacts to cancellation.

```csharp
var cts = new CancellationTokenSource();
var token = cts.Token;

var t = new Task(() =>
{
    Console.WriteLine("Press any key to disarm bomb, you have 5 seconds...");
    var canceled = token.WaitHandle.WaitOne(5000);
    Console.WriteLine(canceled ? "Bomb disarmed" : "BOOM!");
}, token);

t.Start();
Console.ReadKey();
cts.Cancel();
```

### 5. Waiting for Tasks

- `Task.Wait()` – Waits for one task to finish.
- `Task.WaitAll()` – Waits for all tasks.
- `Task.WaitAny()` – Waits for any one task.

You can also specify timeouts and cancellation tokens.

```csharp
var cts = new CancellationTokenSource();
var token = cts.Token;

var t1 = new Task(() =>
{
    Console.WriteLine("I take 5 seconds...");
    for (int i = 0; i < 5; i++)
    {
        token.ThrowIfCancellationRequested();
        Thread.Sleep(1000);
    }
    Console.WriteLine("Task 1 done.");
}, token);

t1.Start();

Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

// Wait for any task with timeout and cancellation
Task.WaitAny(new[] { t1, t2 }, 4000, token);

Console.WriteLine($"Task1 status: {t1.Status}");
Console.WriteLine($"Task2 status: {t2.Status}");
```

### 6. Exception Handling

- When multiple tasks throw exceptions, they are wrapped in an `AggregateException`.
- Exceptions can be handled selectively using `Handle()`.

```csharp
public static void ExceptionTest()
{
    var t1 = Task.Factory.StartNew(() =>
    {
        throw new InvalidOperationException("Invalid operation!") { Source = "t1" };
    });

    var t2 = Task.Factory.StartNew(() =>
    {
        throw new AccessViolationException("Access violation!") { Source = "t2" };
    });

    try
    {
        Task.WaitAll(t1, t2);
    }
    catch (AggregateException ae)
    {
        ae.Handle(e =>
        {
            if (e is InvalidOperationException)
            {
                Console.WriteLine("Invalid operation handled.");
                return true;
            }
            return false;
        });
    }
}
```

## Key Takeaways

- ✅ **Tasks are the building blocks** of parallel programming in .NET.  
- ✅ They support **asynchronous execution, cancellation, timeouts, and coordination**.  
- ✅ **AggregateException** is the standard way to deal with multiple exceptions.  
- ✅ **Task APIs** allow building scalable, responsive applications with ease.  
