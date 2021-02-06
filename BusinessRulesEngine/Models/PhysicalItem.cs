using BusinessRulesEngine.Services;
using System;

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
            throw new NotImplementedException();
        }
    }
}