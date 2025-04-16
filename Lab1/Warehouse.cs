using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Lab1
{
    public enum UnitOfMeasurement
    {
        Pieces,
        Kilograms,
        Liters
    }

    public interface IWarehouseService
    {
        Warehouse AddWarehouse(string name, UnitOfMeasurement unit, double cost, DateTime lastSupplyDate);
        void RemoveProduct(string productName);
        List<Warehouse> GetAllWarehouses();
    }
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


    public class WarehouseService : IWarehouseService
    {
        private int _lastId = 0;
        private readonly List<Warehouse> _warehouses = new();

        public Warehouse AddWarehouse(string name, UnitOfMeasurement unit, double cost, DateTime lastSupplyDate)
        {
            var warehouse = new Warehouse(++_lastId, name, unit, cost, lastSupplyDate);
            _warehouses.Add(warehouse);
            return warehouse;
        }

        public void RemoveProduct(string productName)
        {
            _warehouses.RemoveAll(w => w.Name == productName);
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return new List<Warehouse>(_warehouses);
        }
    }
}