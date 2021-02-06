using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public class MembershipOrder : IPurchasable
    {
        private readonly IMembershipService _membershipService;

        public MembershipOrder(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public PurchaseResult Purchase(string orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}