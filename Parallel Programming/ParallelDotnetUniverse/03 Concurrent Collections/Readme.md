# Concurrent Collections in .NET

## Overview
When working with multithreaded applications, traditional collections like `List<T>` or `Dictionary<TKey,TValue>` are not thread-safe.  
Accessing them from multiple threads without synchronization can lead to **race conditions** and corrupted state.  

**Concurrent Collections** in .NET solve this by providing **thread-safe data structures** that allow safe concurrent access with minimal locking overhead.  

---

## Topics Covered
1. ConcurrentDictionary  
2. Producer–Consumer Collections  
   - ConcurrentQueue  
   - ConcurrentStack  
   - ConcurrentBag  
3. Producer–Consumer Pattern with BlockingCollection  

---

### 1. ConcurrentDictionary
- A thread-safe alternative to `Dictionary<TKey,TValue>`.  
- Supports atomic operations like **add, update, and remove**.  

```csharp
var capitals = new ConcurrentDictionary<string, string>();

capitals.TryAdd("France", "Paris");
capitals["Russia"] = "Leningrad";

// Atomically add or update
capitals.AddOrUpdate("Russia", "Moscow", (k, old) => $"{old} → Moscow");

Console.WriteLine($"Capital of Russia: {capitals["Russia"]}");

// Safe removal
string removed;
if (capitals.TryRemove("Russia", out removed)) {
    Console.WriteLine($"Removed {removed}");
}
```
- ✅ Ensures safe, concurrent modifications without external locks.

### 2. Concurrent Queue

- Implements FIFO (First-In, First-Out) ordering.
- Multiple threads can safely enqueue and dequeue items.

```csharp
var q = new ConcurrentQueue<int>();
q.Enqueue(1);
q.Enqueue(2);

if (q.TryDequeue(out int result)) {
    Console.WriteLine($"Removed: {result}");
}

if (q.TryPeek(out result)) {
    Console.WriteLine($"Front element: {result}");
}
```

### 3. Concurrent Stack

- Implements LIFO (Last-In, First-Out) ordering.
- Thread-safe `Push`, `Pop`, and `Peek` operations.

```csharp
var stack = new ConcurrentStack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

if (stack.TryPeek(out int result)) {
    Console.WriteLine($"{result} is on top");
}

if (stack.TryPop(out result)) {
    Console.WriteLine($"Popped {result}");
}

// Pop multiple at once
var items = new int[5];
int count = stack.TryPopRange(items, 0, items.Length);
Console.WriteLine($"Popped {count} items: {string.Join(", ", items)}");
```

### 4. Concurrent Bag

- An unordered collection optimized for scenarios where:
   - Multiple threads are adding and removing items frequently.
   - Order does not matter.

```csharp
var bag = new ConcurrentBag<int>();

bag.Add(42);

if (bag.TryTake(out int item)) {
    Console.WriteLine($"Removed {item}");
}

if (bag.TryPeek(out item)) {
    Console.WriteLine($"Peeked {item}");
}
```
- ✅ Best for high-throughput producer–consumer scenarios.

### 5. Producer–Consumer Pattern with BlockingCollection

- `BlockingCollection<T>` builds on top of concurrent collections (e.g., `ConcurrentBag`, `ConcurrentQueue`).
- Provides bounded capacity and blocking operations (`Add`, `Take`).
- Ideal for producer–consumer scenarios.

```csharp
var messages = new BlockingCollection<int>(new ConcurrentBag<int>(), 10);
var cts = new CancellationTokenSource();

// Producer
var producer = Task.Factory.StartNew(() => {
    var rand = new Random();
    while (!cts.Token.IsCancellationRequested) {
        int value = rand.Next(100);
        messages.Add(value);
        Console.WriteLine($"+{value}");
        Thread.Sleep(rand.Next(100));
    }
}, cts.Token);

// Consumer
var consumer = Task.Factory.StartNew(() => {
    foreach (var item in messages.GetConsumingEnumerable()) {
        Console.WriteLine($"-{item}");
        Thread.Sleep(1000);
    }
}, cts.Token);
```

- ✅ Provides automatic blocking when the collection is full or empty.
- ✅ Supports graceful cancellation with CancellationToken.

## Key Takeaways

- ✅ **ConcurrentDictionary** is the go-to replacement for `Dictionary` in multithreaded scenarios.
- ✅ **ConcurrentQueue** and ConcurrentStack provide FIFO and LIFO semantics with thread safety.
- ✅ **ConcurrentBag** is ideal when order does not matter and throughput is important.
- ✅ **BlockingCollection** simplifies implementing the producer–consumer pattern.
- ✅ Using concurrent collections reduces the need for explicit locks, improving **performance** and **code clarity**.
