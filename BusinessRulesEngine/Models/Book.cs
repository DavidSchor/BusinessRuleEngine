using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models
{
    public class Book : PhysicalItem
    {
        private readonly IPackingService _packingService;

        public Book(IPackingService packingService) : base(packingService)
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