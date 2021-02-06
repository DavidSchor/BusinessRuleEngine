using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public class PhysicalItemOrder : IPurchasable
    {
        private readonly ICommissionService _commissionService;

        private IPackingService _packingService { get; }

        public PhysicalItemOrder(IPackingService packingService, ICommissionService commissionService)
        {
            _packingService = packingService;
            _commissionService = commissionService;
        }

        public virtual PurchaseResult Purchase(string orderId)
        {
            _packingService.AddBundledItems(orderId);
            _packingService.GeneratePackingSlip(orderId, DepartmentConstants.Shipping);
            _commissionService.GrantCommission(orderId);
            return new PurchaseResult { OrderId = orderId, Success = true };
        }
    }
}