using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab1
{
    public interface IReporter
    {
        void RegisterOperation(Product product);
    }

    public abstract class BaseRegisterOperation : IReporter
    {
        protected readonly IWarehouseService WarehouseService;

        protected BaseRegisterOperation(IWarehouseService warehouseService)
        {
            WarehouseService = warehouseService ?? throw new ArgumentNullException(nameof(warehouseService));
        }

        public abstract void RegisterOperation(Product product);
    }

    public class RegisterIncome : BaseRegisterOperation
    {
        public RegisterIncome(IWarehouseService warehouseService) : base(warehouseService) { }

        public override void RegisterOperation(Product product)
        {
            WarehouseService.AddWarehouse(product.Name, product.Unit, product.Cost, DateTime.Now);
            Console.WriteLine($"Received product: {product.Name}, Price: {product.Cost}");
        }
    }

    public class RegisterShipment : BaseRegisterOperation
    {
        public RegisterShipment(IWarehouseService warehouseService) : base(warehouseService) { }

        public override void RegisterOperation(Product product)
        {
            WarehouseService.RemoveProduct(product.Name);
            Console.WriteLine($"Shipped product: {product.Name}");
        }
    }
}


