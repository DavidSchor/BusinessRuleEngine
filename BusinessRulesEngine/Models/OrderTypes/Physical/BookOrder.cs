using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public class BookOrder : PhysicalItemOrder
    {
        private readonly IPackingService _packingService;

        public BookOrder(IPackingService packingService, ICommissionService commissionService) : base(packingService, commissionService)
        {
            _packingService = packingService;
        }

        public override PurchaseResult Purchase(string orderId)
        {
            base.Purchase(orderId);
            _packingService.GeneratePackingSlip(orderId, DepartmentConstants.Royalty);
            return new PurchaseResult { OrderId = orderId, Success = true };
        }
    }
}