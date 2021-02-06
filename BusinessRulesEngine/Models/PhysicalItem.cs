using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models
{
    public class PhysicalItem : IPurchasable
    {
        private readonly ICommissionService _commissionService;

        private IPackingService _packingService { get; }

        public PhysicalItem(IPackingService packingService, ICommissionService commissionService)
        {
            _packingService = packingService;
            _commissionService = commissionService;
        }

        public virtual PurchaseResult Purchase(string orderId)
        {
            _packingService.GeneratePackingSlip(orderId, DepartmentConstants.Shipping);
            return new PurchaseResult { OrderId = orderId, Success = true };
        }
    }
}