using BusinessRulesEngine.Services;
using System;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public class UpgradeMembershipOrder : MembershipOrder
    {
        public UpgradeMembershipOrder(IMembershipService membershipService) : base(membershipService)
        {
        }

        public override PurchaseResult Purchase(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}