# Iterator Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> *"Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation."*

### **Simplified Explanation**

- The **Iterator Pattern** provides a way to access and iterate through collections in a consistent manner, regardless of type.
- This means you can traverse different types of collections (such as lists, arrays, or custom data structures) using the same interface.

## **Background**

The Iterator Pattern is useful when you want to provide a standard way to access elements of a collection without exposing the underlying structure. It promotes loose coupling and enhances the flexibility of code.

### **Example: Book Collection**

Consider a library that has a collection of books. The library wants to allow users to iterate through the collection without revealing how the books are stored (e.g., in an array, list, or database).

By implementing the Iterator Pattern, the library can provide a uniform way to access the books, regardless of their internal representation.

## **Implementation**

### **Step 1: Define Iterator Interface**

```csharp
public interface IBookIterator
{
    bool HasNext();
    Book Next();
}
```

Step 2: Define Aggregate Interface

``` csharp
public interface IBookCollection
{
    IBookIterator CreateIterator();
}
```

### Step 3: Create Concrete Collection

```csharp
public class BookCollection : IBookCollection
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book) => _books.Add(book);

    public IBookIterator CreateIterator() => new BookIterator(this);

    public int Count => _books.Count;

    public Book this[int index] => _books[index];
}
```

### Step 4: Implement Concrete Iterator

```csharp
public class BookIterator : IBookIterator
{
    private readonly BookCollection _collection;
    private int _currentIndex = 0;

    public BookIterator(BookCollection collection)
    {
        _collection = collection;
    }

    public bool HasNext() => _currentIndex < _collection.Count;

    public Book Next() => _collection[_currentIndex++];
}

### Step 5: Use Iterator in Client Code

```csharp
class Program
{
    static void Main()
    {
        BookCollection books = new BookCollection();
        books.AddBook(new Book("1984", "George Orwell"));
        books.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));

        IBookIterator iterator = books.CreateIterator();
        while (iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }
}
```

### Problems Solved by Iterator Pattern

- ✅ Encapsulation of Collection Structure – Clients can iterate through collections without knowing their internal representation.
- ✅ Consistent Interface – Provides a uniform way to access different types of collections.
- ✅ Separation of Concerns – Iteration logic is separated from the collection logic, enhancing code maintainability.
- ✅ Flexibility – New collection types can be introduced without changing the iteration logic.

### Conclusion

The Iterator Pattern is a powerful design pattern that simplifies the process of accessing elements in a collection. It promotes encapsulation, consistency, and flexibility, making it an essential pattern for developers working with various data structures.
