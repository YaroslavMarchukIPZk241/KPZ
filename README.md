# lab1
## The principles I used:
### Single Responsibility Principle
Each class is responsible for one responsibility:
- [Product](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Product.cs) – responsible for product data (name, price, quantity, etc.).
- [Money](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Money.cs) – responsible for processing monetary units and currencies.
- [Reporting](.https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs) – responsible for displaying reports and operations on products (adding, subtracting, etc.).
- [Warehouse](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Warehouse.cs) – manages the list of products and interacts with reports.
- [Printers](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Printers.cs) – outputs money and goods data.
- [WarehouseOperation](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/WarehouseOperation.cs) – manages the list of goods and interacts with reports.
```
 public class Warehouse
 {
     public int Id { get; }
     public string Name { get; }
     public UnitOfMeasurement Unit { get; }
     public double Cost { get; }
     public DateTime LastSupplyDate { get; }

     public Warehouse(int id, string name, UnitOfMeasurement unit, double cost, DateTime lastSupplyDate)
     {
         Id = id;
         Name = name;
         Unit = unit;
         Cost = cost;
         LastSupplyDate = lastSupplyDate;
     }
 }
```
### Open/Closed Principle
- Classes are closed to modifications, but open to extensions. For [example](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Printers.cs), to add new product operations, you can create a new class without modifying existing ones.
### Liskov Substitution Principle
- Using interfaces ([IReporter](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs)) allows replacing implementations without changing the logic. For [example](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Money.cs), you can create another class that implements IMoney and use that instead of Money.
### Interface Segregation Principle
- Interfaces are divided by functionality: [IMoneyOperation](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Money.cs#L9), [IReporter](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs#L10), [IPrinter](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Printers.cs#L9C21-L9C30), [IWarehouseService](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Warehouse.cs#L17C22-L17C39). This allows you to implement only the  in each class.
### Dependency Inversion Principle
The [RegisterIncome](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs#L27) and [RegisterShipment](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs#L38) classes depend on the [IWarehouseService](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Warehouse.cs#L17C12-L17C39) abstraction, not on a specific warehouse service implementation. This provides better testability, flexibility and extensibility of the system, allowing you to easily replace or modify the implementation without changing the code of high-level modules.

### DRY (Don`t Repeat Yourself)
- Moving the common logic to a separate [BaseRegisterOperation](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs) base class avoids code duplication when implementing operations such as [RegisterIncome](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs#L27) and [RegisterShipment](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Reporting.cs#L38). This is in line with the DRY (Don't Repeat Yourself) principle and improves code support.
### KISS (Keep It Simple, Stupid)
- The structure of the code is simple and clear. Each class and [method]([./lab1_kpz/classes/Product.cs#L24-L32](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Lab1/Product.cs)) has a clear functionality and is not overloaded with unnecessary logic
# UML
!([uml_diagram.png](https://github.com/YaroslavMarchukIPZk241/KPZ/blob/master/Screenshot%202025-04-16%20185525.png))
