# Parallel Loops in .NET

## Overview
Parallel loops in .NET (`Parallel.For`, `Parallel.ForEach`, and `Parallel.Invoke`) provide an efficient way to run **iterations concurrently**, taking advantage of multiple processors.  
They offer better performance for compute-bound workloads while still providing flexibility in **cancellation, exceptions, partitioning, and thread-local state**.

---

## Topics Covered
1. Parallel Invoke / For / ForEach  
   - Options and stepped loops  
2. Stopping, Cancellation, and Exceptions  
3. Thread-Local Storage  
4. Partitioning  

---

### 1. Parallel.Invoke, Parallel.For, Parallel.ForEach

The **Parallel class** provides three main entry points for parallel execution:

- `Parallel.Invoke` → Runs multiple actions in parallel.  
- `Parallel.For` → Executes a loop where iterations are indexed.  
- `Parallel.ForEach` → Iterates over collections in parallel.  

```csharp
var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

Parallel.Invoke(a, b, c);

Parallel.For(1, 11, i => {
    Console.WriteLine($"{i * i}");
});

var words = new List<string>() { "words", "what", "the", "hell" };
Parallel.ForEach(words, w => {
    Console.WriteLine($"{w.Length} [Task {Task.CurrentId}]");
});
```

- ✅ Useful for **parallelizing independent tasks or loops**.

### 2. Breaking, Cancellation, and Exceptions

Parallel loops can be stopped or canceled:
  - **Stop()** → Requests loop termination as soon as possible.
  - **Break()** → Stops future iterations beyond the current index but lets already-started ones finish.
  - **Cancellation** → Use `ParallelOptions` with a `CancellationToken`.
  - **Exceptions** → Multiple exceptions are wrapped in an `AggregateException`.

```csharp
var cts = new CancellationTokenSource();
var options = new ParallelOptions { CancellationToken = cts.Token };

try {
    var result = Parallel.For(0, 20, options, (x, state) => {
        Console.WriteLine($"{x}[{Task.CurrentId}]");
        if (x == 10) {
            // state.Stop();
            // state.Break();
            // throw new Exception("Boom!");
            cts.Cancel();
        }
    });

    Console.WriteLine($"Loop completed? {result.IsCompleted}");
    if (result.LowestBreakIteration.HasValue) {
        Console.WriteLine($"Lowest break iteration: {result.LowestBreakIteration}");
    }
}
catch (AggregateException ae) {
    ae.Handle(e => { Console.WriteLine(e.Message); return true; });
}
catch (OperationCanceledException) {
    Console.WriteLine("Loop was canceled.");
}
```
- ✅ Gives **fine-grained control** over loop termination and error handling.

### 3. Thread-Local Storage

- Parallel loops allow defining **per-thread local variables**, aggregated at the end.
- This is more efficient than shared-state synchronization with `Interlocked`.

```csharp
int sum = 0;

Parallel.For(1, 1001,
    () => 0, // thread-local init
    (x, state, localSum) => {
        localSum += x;
        Console.WriteLine($"Task {Task.CurrentId} local sum = {localSum}");
        return localSum;
    },
    localSum => {
        Console.WriteLine($"Final local sum of Task {Task.CurrentId} = {localSum}");
        Interlocked.Add(ref sum, localSum);
    });

Console.WriteLine($"Sum of 1..1000 = {sum}");
```

- ✅ Reduces contention by **isolating intermediate** results per thread.

### 4. Partitioning

- Default parallel loops automatically partition the workload.
- For large datasets, **custom partitioning** improves cache efficiency and reduces overhead.

```csharp
const int count = 100000;
var values = Enumerable.Range(0, count);
var results = new int[count];

// Default partitioning
Parallel.ForEach(values, x => {
    results[x] = (int)Math.Pow(x, 2);
});

// Chunked partitioning
var partitioner = Partitioner.Create(0, count, 10000);
Parallel.ForEach(partitioner, range => {
    for (int i = range.Item1; i < range.Item2; i++) {
        results[i] = (int)Math.Pow(i, 2);
    }
});
```

- ✅ **Partitioner.Create** allows batching work into ranges, leading to **better performance** in some workloads.

## Key Takeaways

- ✅ **Parallel.For / ForEach / Invoke** provide easy ways to parallelize work.
- ✅ **Break, Stop, and CancellationTokens** allow safe early termination.
- ✅ **Exceptions** are aggregated and must be handled carefully.
- ✅ **Thread-local storage** avoids contention and improves scalability.
- ✅ **Partitioning** optimizes workloads by reducing overhead and improving cache locality.
