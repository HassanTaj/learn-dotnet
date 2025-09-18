# Task Coordination in .NET

## Overview
In parallel programming, tasks often need to **coordinate their execution** rather than running completely independently.  
This module explores techniques and synchronization primitives in .NET that enable structured task coordination, ensuring predictable and safe execution.  

---

## Topics Covered
1. Continuations  
2. Child Tasks  
3. Synchronization Primitives  
   - Barrier  
   - CountdownEvent  
   - ManualResetEventSlim / AutoResetEvent  
   - SemaphoreSlim  

---

### 1. Continuations
- A **continuation** is a task that starts after another task finishes.  
- Helps express **sequential workflows** without blocking threads.  

```csharp
var task = Task.Factory.StartNew(() => {
    Console.WriteLine("Boiling water");
});

var continuation = task.ContinueWith(t => {
    Console.WriteLine($"Completed {t.Id}, pouring water into the cup");
});

continuation.Wait();
```

- You can also use:
  - ContinueWhenAll → Start after all tasks complete.
  - ContinueWhenAny → Start after any task completes.

### 2. Child Tasks

- Tasks can spawn child tasks that are either:
  - **Detached** → Execute independently of the parent.
  - **Attached** → Parent waits for child to complete (and aggregates exceptions).

```csharp
var parent = new Task(() => {
    var child = new Task(() => {
        Console.WriteLine("Child task starting...");
        Thread.Sleep(3000);
        Console.WriteLine("Child task finished.");
        throw new DivideByZeroException();
    }, TaskCreationOptions.AttachedToParent);

    child.ContinueWith(t => {
        Console.WriteLine($"Success! Task {t.Id} completed.");
    }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

    child.ContinueWith(t => {
        Console.WriteLine($"Task {t.Id} failed with {t.Status}");
    }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);

    child.Start();
});

parent.Start();
try {
    parent.Wait();
} catch (AggregateException ae) {
    ae.Handle(e => true); // handle all exceptions
}
```

- ✅ Attached child tasks propagate results and exceptions back to the parent.

### 3. Barrier

- A Barrier lets multiple tasks run in phases, pausing until all participants reach the same point.
- Useful for scenarios like multi-step algorithms where tasks must align at each stage.

```csharp
var barrier = new Barrier(2, b => {
    Console.WriteLine($"Phase {b.CurrentPhaseNumber} finished.");
});

void Water() {
    Console.WriteLine("Boiling water...");
    Thread.Sleep(2000);
    barrier.SignalAndWait();

    Console.WriteLine("Pouring water...");
    barrier.SignalAndWait();

    Console.WriteLine("Putting kettle away");
}

void Cup() {
    Console.WriteLine("Finding a cup...");
    barrier.SignalAndWait();

    Console.WriteLine("Adding tea");
    barrier.SignalAndWait();

    Console.WriteLine("Adding sugar");
}
```

- ✅ Ensures tasks move forward in sync.

### 4. CountdownEvent

- A CountdownEvent allows one or more tasks to wait until a specific number of signals have been received.
- Ideal for waiting until a set of worker tasks complete.

```csharp
int taskCount = 5;
var cte = new CountdownEvent(taskCount);

for (int i = 0; i < taskCount; i++) {
    Task.Factory.StartNew(() => {
        Console.WriteLine($"Task {Task.CurrentId} working...");
        Thread.Sleep(1000);
        cte.Signal(); // decrement counter
        Console.WriteLine($"Task {Task.CurrentId} finished");
    });
}

cte.Wait(); // wait until all tasks have signaled
Console.WriteLine("All tasks completed!");
```

### 5. ManualResetEventSlim & AutoResetEvent

**ManualResetEventSlim:** stays signaled until manually reset.
**AutoResetEvent:** automatically resets after a single waiter is released.

```csharp
var evt = new ManualResetEventSlim();

Task.Factory.StartNew(() => {
    Console.WriteLine("Boiling water");
    evt.Set(); // signal
});

Task.Factory.StartNew(() => {
    Console.WriteLine("Waiting for water...");
    evt.Wait();
    Console.WriteLine("Here is your tea!");
});

var aevt = new AutoResetEvent(false);

Task.Factory.StartNew(() => {
    Console.WriteLine("Boiling water");
    aevt.Set(); // signal (resets automatically after one waiter)
});

Task.Factory.StartNew(() => {
    Console.WriteLine("Waiting for water...");
    aevt.WaitOne();
    Console.WriteLine("Here is your tea!");
});
```

- ✅ Use ManualResetEventSlim for multiple consumers, AutoResetEvent for one-at-a-time signaling.

### 6. SemaphoreSlim

- A SemaphoreSlim limits the number of tasks that can access a resource simultaneously.
- Lighter than Semaphore and works only in-process.

```csharp
var semaphore = new SemaphoreSlim(initialCount: 2, maxCount: 5);

for (int i = 0; i < 10; i++) {
    Task.Factory.StartNew(() => {
        Console.WriteLine($"Task {Task.CurrentId} waiting...");
        semaphore.Wait();
        Console.WriteLine($"Task {Task.CurrentId} entered");
        Thread.Sleep(1000);
        semaphore.Release();
    });
}
```

- ✅ Prevents resource exhaustion by controlling concurrency.

## Key Takeaways

- ✅ **Continuations** chain tasks without blocking threads.
- ✅ **Child tasks** can propagate results and exceptions to their parent.
- ✅ **Barrier** synchronizes tasks across multiple phases.
- ✅ **CountdownEvent** is useful for waiting on a group of tasks.
- ✅ **ManualResetEventSlim / AutoResetEvent** provide signaling between threads.
- ✅ **SemaphoreSlim** efficiently limits concurrency for shared resources.
