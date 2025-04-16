using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
namespace Lab1
{
    public interface IPriceChanger
    {
        void ChangePrice(double amount);
    }

    public class Product
    {
        public string Name { get; }
        public double Cost { get; private set; }
        public UnitOfMeasurement Unit { get; }

        public Product(string name, double cost, UnitOfMeasurement unit)
        {
            if (cost < 0) throw new ArgumentException("Cost cannot be negative.");
            Name = name;
            Cost = cost;
            Unit = unit;
        }

        public void UpdateCost(double amount)
        {
            Cost = Math.Max(0, Cost + amount);
        }
    }

    public class PriceChanger : IPriceChanger
    {
        private readonly Product _product;

        public PriceChanger(Product product)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public void ChangePrice(double amount)
        {
            _product.UpdateCost(amount);
        }
    }
}