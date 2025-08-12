# Adapter Pattern

## Gang of Four Definition

According to the Gang of Four (GoF):

> "Converts the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces."

### Simplified Explanation

- The Adapter Pattern acts as a bridge between two incompatible interfaces.
- It allows a class to work with another class's interface without modifying their source code.
- This pattern is especially useful when integrating legacy code or third-party libraries with different interfaces.

## Background

The Adapter Pattern is ideal when a client expects a particular interface, but the object you have offers a different one. Rather than changing the client or the object, an adapter class sits between them and makes them compatible.

### Example: Charging an iPhone with a USB-C Charger

Imagine you have a USB-C charger, but your iPhone requires a Lightning port. Instead of replacing the charger or the phone, you can use a USB-C to Lightning adapter to make them compatible.

Similarly, in software, when interfaces don’t match, we use an adapter to resolve incompatibility.

## Implementation

### Step 1: Define the Target Interface
```csharp
public interface ILightningPhone
{
    void ConnectLightning();
}
```
### Step 2: Create the Adaptee (Incompatible Interface)
```csharp
public class AndroidPhone
{
    public void ConnectUSBTypeC() => Console.WriteLine("Connected via USB-C");
}
```
### Step 3: Create the Adapter
```csharp
public class LightningToUSBCAdapter : ILightningPhone
{
    private readonly AndroidPhone _androidPhone;

    public LightningToUSBCAdapter(AndroidPhone androidPhone)
    {
        _androidPhone = androidPhone;
    }

    public void ConnectLightning()
    {
        Console.WriteLine("Adapter converts Lightning signal to USB-C...");
        _androidPhone.ConnectUSBTypeC();
    }
}
```
### Step 4: Use Adapter in Client Code
```csharp
public class PhoneCharger
{
    private readonly ILightningPhone _phone;

    public PhoneCharger(ILightningPhone phone) => _phone = phone;

    public void ChargePhone()
    {
        _phone.ConnectLightning();
        Console.WriteLine("Charging started...");
    }
}
class Program
{
    static void Main()
    {
        AndroidPhone androidPhone = new AndroidPhone();
        ILightningPhone adaptedPhone = new LightningToUSBCAdapter(androidPhone);

        PhoneCharger charger = new PhoneCharger(adaptedPhone);
        charger.ChargePhone();
    }
}
```
## Comparison: Adapter vs Other Patterns

| Feature                          | Adapter Pattern               | Decorator Pattern             | Proxy Pattern                   |
| -------------------------------- | ----------------------------- | ----------------------------- | ------------------------------- |
| Purpose                          | Interface compatibility       | Add responsibilities          | Control access                  |
| Alters existing interfaces?      | Yes                           | No                            | No                              |
| Wraps existing objects?          | Yes                           | Yes                           | Yes                             |
| Best for                         | Integration of incompatible APIs | Dynamic behavior changes    | Access control or lazy loading |

## Problems Solved by Adapter Pattern

- ✅ Legacy Code Integration – Allows modern systems to work with legacy classes without modifying them.
- ✅ Incompatible Interfaces – Makes unrelated classes work together.
- ✅ Promotes Reusability – Reuse existing code without rewriting it to fit new interfaces.
- ✅ Decouples Code – Keeps clients and services loosely coupled, enhancing flexibility.

## Conclusion

The Adapter Pattern is a structural design pattern that helps integrate classes with incompatible interfaces. It acts like a translator between components, allowing systems to evolve without breaking compatibility. Whether you're wrapping legacy APIs or enabling different components to work together seamlessly, Adapter provides a clean and scalable solution.
