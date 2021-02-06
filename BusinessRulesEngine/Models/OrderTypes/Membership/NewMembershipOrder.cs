using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public class NewMembershipOrder : MembershipOrder
    {
        private readonly IMembershipService _membershipService;

        public NewMembershipOrder(IMembershipService membershipService) : base(membershipService)
        {
            _membershipService = membershipService;
        }

        public override PurchaseResult Purchase(string orderId)
        {
            var baseResult = base.Purchase(orderId);
            var activationSuccessfull = _membershipService.ActivateMembership(orderId);
            return new PurchaseResult { OrderId = orderId, Success = baseResult.Success && activationSuccessfull };
        }
    }
}