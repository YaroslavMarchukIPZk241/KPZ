using Lab1;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Lab1;

class Program
{
    static void Main(string[] args)
    {
        Product product = new Product("Laptop", 1000, UnitOfMeasurement.Pieces);
        Console.WriteLine($"Product created: {product.Name}, Cost: {product.Cost}, Unit: {product.Unit}");

      
        IPriceChanger priceChanger = new PriceChanger(product);
        priceChanger.ChangePrice(200);
        Console.WriteLine($"New cost after price change: {product.Cost}");

   
        Money money = new Money(10, 50, "USD");
        IMoneyOperation addMoney = new MoneyOperationAdd(money);
        addMoney.Execute(5, 75);
        Console.WriteLine($"Money after addition: {money.Cash} dollars, {money.Coin} cents");

        IMoneyOperation subtractMoney = new MoneyOperationSubtract(money);
        subtractMoney.Execute(3, 60);
        Console.WriteLine($"Money after subtraction: {money.Cash} dollars, {money.Coin} cents");

    
        IWarehouseService warehouseService = new WarehouseService();

 
        RegisterIncome registerIncome = new RegisterIncome(warehouseService);
        registerIncome.RegisterOperation(product);


        IPrinter<IEnumerable<Warehouse>> printer = new PrinterWarehouse();
        printer.Print(warehouseService.GetAllWarehouses());

        RegisterShipment registerShipment = new RegisterShipment(warehouseService);
        registerShipment.RegisterOperation(product);

        WarehouseOperationExecutor executor = new WarehouseOperationExecutor();
        executor.AddOperation(new AddProductOperation(warehouseService, "Phone", UnitOfMeasurement.Pieces, 800));
        executor.AddOperation(new RemoveProductOperation(warehouseService, "Laptop"));


    }
}