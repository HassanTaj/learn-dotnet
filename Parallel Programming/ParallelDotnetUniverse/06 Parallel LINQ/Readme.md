# Parallel LINQ (PLINQ) in .NET

## Overview
- **LINQ (Language Integrated Query)** is a powerful abstraction for querying data with operators such as `Select()`, `Sum()`, `Aggregate()`, etc.  
- By default, LINQ executes **sequentially**.  
- **PLINQ** (Parallel LINQ) extends LINQ using the Task Parallel Library (TPL), allowing queries to run in **parallel** across multiple threads.  

This module explores **PLINQ fundamentals**, including cancellation, exceptions, merge options, and custom aggregations.

---

## Topics Covered
1. AsParallel and ParallelQuery  
2. Cancellation and Exceptions  
3. Merge Options  
4. Custom Aggregation  

---

## 1. AsParallel and ParallelQuery

- Use **`AsParallel()`** to convert an enumerable into a **parallel query**.  
- PLINQ automatically partitions work across threads.  
- **`ForAll()`** can be used to consume results in parallel.  
- **`AsOrdered()`** preserves the original ordering if required.  

```csharp
const int count = 50;
var items = Enumerable.Range(1, count).ToArray();
var results = new int[count];

// Parallel processing
items.AsParallel().ForAll(x => {
    int cube = x * x * x;
    Console.WriteLine($"{cube} (Task {Task.CurrentId})");
    results[x - 1] = cube;
});

// Preserving order
var cubes = items.AsParallel().AsOrdered().Select(c => c * c * c);
foreach (var cube in cubes) {
    Console.WriteLine(cube);
}
```

- ✅ Use `AsParallel()` for performance, and `AsOrdered()` when **sequence order matters.**

### 2. Cancellation and Exceptions

- PLINQ queries support cancellation via `CancellationToken`.
- If a query throws exceptions, they are wrapped in an `AggregateException`.

```csharp
var cts = new CancellationTokenSource();
var items = ParallelEnumerable.Range(0, 20);

var results = items
    .WithCancellation(cts.Token)
    .Select(i => {
        double result = Math.Log(i);
        Console.WriteLine($"i = {i}, Task = {Task.CurrentId}");
        return result;
    });

try {
    foreach (var r in results) {
        if (r > 1) cts.Cancel(); // cancel on condition
        Console.WriteLine($"Result = {r}");
    }
}
catch (AggregateException ae) {
    ae.Handle(e => {
        Console.WriteLine($"{e.GetType().Name}: {e.Message}");
        return true;
    });
}
catch (OperationCanceledException) {
    Console.WriteLine("Query was canceled.");
}
```

- ✅ Enables **graceful termination** of long-running queries.
- ✅ Ensures robust error handling with multiple exceptions.

### 3. Merge Options

PLINQ provides merge options to control how results are buffered and streamed:
  - FullyBuffered → All results produced first, then consumed.
  - NotBuffered → Results consumed immediately as they’re produced.
  - AutoBuffered (default) → Balances between throughput and latency.

```csharp
var numbers = Enumerable.Range(0, 20).ToArray();

var results = numbers.AsParallel()
    .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
    .Select(x => {
        var result = Math.Log(x);
        Console.Write($"Produced {result}\t");
        return result;
    });

foreach (var res in results) {
    Console.Write($"Consumed {res}\t");
}
```

- ✅ Choose merge options to trade off between **throughput vs responsiveness**.

### 4. Custom Aggregation

- PLINQ supports parallel aggregation using the Aggregate operator.
- It allows partial results per partition to be combined into a final result.

```csharp
var sum = ParallelEnumerable.Range(1, 1000)
    .Aggregate(
        0,                              // seed
        (partialSum, i) => partialSum + i, // per-thread accumulation
        (total, subtotal) => total + subtotal, // merge partial results
        finalResult => finalResult);        // final projection

Console.WriteLine($"Sum = {sum}");
```

- ✅ Provides **flexible aggregation** beyond built-in methods like `Sum()` or `Count()`.

## Key Takeaways

- ✅ **PLINQ** enables LINQ queries to execute in parallel with minimal code changes.
- ✅ Use `AsParallel()` for parallelization and `AsOrdered()` when ordering is important.
- ✅ **Cancellation and AggregateException** provide robust control over query execution.
- ✅ **Merge options** control responsiveness and result streaming.
- ✅ **Custom aggregation** gives fine-grained control over combining results.
