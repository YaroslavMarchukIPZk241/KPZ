using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
namespace Lab1
{
    public interface IPrinter<T>
    {
        void Print(T data);
    }

    public class PrinterMoney : IPrinter<Money>
    {
        public void Print(Money money)
        {
            Console.WriteLine($"{money.Cash} {money.Coin} {money.Currency}");
        }
    }

    public class PrinterWarehouse : IPrinter<IEnumerable<Warehouse>>
    {
        public void Print(IEnumerable<Warehouse> warehouses)
        {
            Console.WriteLine("ID | Name | Unit of Measurement | Cost | Last Supply Date");

            foreach (var warehouse in warehouses)
            {
                PrintWarehouse(warehouse);
            }
        }

        private void PrintWarehouse(Warehouse warehouse)
        {
            Console.WriteLine($"{warehouse.Id} | {warehouse.Name} | {warehouse.Unit} | {warehouse.Cost} | {warehouse.LastSupplyDate}");
        }
    }
}