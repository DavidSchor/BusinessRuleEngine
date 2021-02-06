using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models
{
    public class PhysicalItem : IPurchasable
    {
        private IPackingService _packingService { get; }

        public PhysicalItem(IPackingService packingService)
        {
            _packingService = packingService;
        }

        public PurchaseResult Purchase(string orderId)
        {
            _packingService.GeneratePackingSlip(orderId, DepartmentConstants.Shipping);
            return new PurchaseResult { OrderId = orderId, Success = true };
        }
    }
}