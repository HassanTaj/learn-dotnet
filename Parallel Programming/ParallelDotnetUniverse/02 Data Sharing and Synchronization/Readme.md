# Data Sharing and Synchronization in .NET

## Overview
In multithreaded applications, multiple threads often need to access and modify shared data.  
Without proper synchronization, this can lead to **race conditions**, **inconsistent state**, and **hard-to-debug errors**.  

This module explores key synchronization techniques and primitives in .NET, ensuring **safe data sharing** and **predictable execution**.

---

## Topics Covered
1. Critical Sections  
2. Interlocked Operations  
3. Spin Locking & Lock Recursion  
4. Mutex  
5. Reader–Writer Locks  

---

## Atomicity

- An operation is **atomic** if it **cannot be interrupted** mid-execution.  
- Example:  
  - ✅ `x = 1;` → Atomic  
  - ❌ `x++;` → Not atomic (it expands into multiple steps: read → increment → write).  

**Implications:**  
- Non-atomic operations are vulnerable to **race conditions**.  
- Atomic operations in .NET include:  
  - Reference assignments  
  - Reads and writes to 32-bit value types  
  - 64-bit reads/writes on a 64-bit system  

---

### 1. Critical Sections
- A **critical section** ensures that only **one thread at a time** executes a block of code.  
- In C#, this is done with the `lock` keyword.  

```csharp
lock (padlock) {
    Balance += amount;
}
```

- ✅ Prevents multiple threads from corrupting shared state.

### 2. Interlocked Operations

- The Interlocked class provides atomic operations without explicit locks.

- Common methods:
  - `Interlocked.Add(ref balance, amount)`
  - `Interlocked.Increment(ref counter)`
  - `Interlocked.Decrement(ref counter)`
  - `Interlocked.Exchange(ref location, newValue)`
  - `Interlocked.CompareExchange(ref location, newValue, comparand)`

### Memory Barriers

- CPUs may reorder instructions for optimization.
- `Thread.MemoryBarrier()` ensures instructions before the barrier cannot be moved after it.
- Useful with `volatile` fields.

- ✅ Eliminates race conditions with minimal overhead.

### 3. Spin Locking & Lock Recursion

- A SpinLock repeatedly checks until a lock becomes available.
- Best used when contention is short (avoids context switching overhead).

```csharp
bool lockTaken = false;
sl.Enter(ref lockTaken);
// critical section
if (lockTaken) sl.Exit();
```

### Lock Recursion

- By default, a SpinLock does not allow recursion.
- If recursion is needed, enable with LockRecursionPolicy.SupportsRecursion.
- ⚠️ Wastes CPU cycles if contention is high.

### 4. Mutex

A Mutex is a synchronization primitive similar to lock, but:
  - Works across processes.
  - Can be named for global system-wide synchronization.

```csharp
var mutex = new Mutex();
mutex.WaitOne();
// critical section
mutex.ReleaseMutex();
```

### Global Mutex
```csharp
const string appName = "MyApp";
var mutex = new Mutex(false, appName);
```

- ✅ Prevents multiple instances of the same application.

### 5. Reader–Writer Locks

- `ReaderWriterLockSlim` allows:
  - Multiple threads to read simultaneously.
  - Only one writer at a time.
  - 
```csharp
padlock.EnterUpgradeableReadLock();
if (condition) {
    padlock.EnterWriteLock();
    x = 123;
    padlock.ExitWriteLock();
}
padlock.ExitUpgradeableReadLock();
```

- ✅ Optimized for read-heavy workloads.
- ✅ Supports upgradeable read locks for safe transitions.

## Key Takeaways
- ✅ Atomicity is essential for preventing race conditions.
- ✅ Use critical sections (lock) for simple thread safety.
- ✅ Use Interlocked for lightweight atomic operations.
- ✅ SpinLocks are efficient for very short waits but waste CPU under high contention.
- ✅ Mutex is heavier but works across processes.
- ✅ Reader–Writer locks improve performance in read-dominated scenarios.
