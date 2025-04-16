using System;
using System.Collections.Generic;

namespace Lab1
{
    public interface IWarehouseOperation
    {
        void Execute();
    }

    public class AddProductOperation : IWarehouseOperation
    {
        private readonly IWarehouseService _warehouseService;
        private readonly string _name;
        private readonly UnitOfMeasurement _unit;
        private readonly double _cost;

        public AddProductOperation(IWarehouseService warehouseService, string name, UnitOfMeasurement unit, double cost)
        {
            _warehouseService = warehouseService;
            _name = name;
            _unit = unit;
            _cost = cost;
        }

        public void Execute()
        {
            _warehouseService.AddWarehouse(_name, _unit, _cost, DateTime.Now);
        }
    }

    public class RemoveProductOperation : IWarehouseOperation
    {
        private readonly IWarehouseService _warehouseService;
        private readonly string _productName;

        public RemoveProductOperation(IWarehouseService warehouseService, string productName)
        {
            _warehouseService = warehouseService;
            _productName = productName;
        }

        public void Execute()
        {
            _warehouseService.RemoveProduct(_productName);
        }
    }

    public class WarehouseOperationExecutor
    {
        private readonly List<IWarehouseOperation> _operations = new();

        public void AddOperation(IWarehouseOperation operation)
        {
            _operations.Add(operation);
        }
    }
}
