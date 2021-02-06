using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public abstract class MembershipOrder : IPurchasable
    {
        private readonly IMembershipService _membershipService;

        public MembershipOrder(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public virtual PurchaseResult Purchase(string orderId)
        {
            return new PurchaseResult { OrderId = orderId, Success = true };
        }
    }
}