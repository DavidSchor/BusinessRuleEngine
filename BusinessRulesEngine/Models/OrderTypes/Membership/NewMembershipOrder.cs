using BusinessRulesEngine.Services;
using System;

namespace BusinessRulesEngine.Models.OrderTypes
{
    public class NewMembershipOrder : MembershipOrder
    {
        public NewMembershipOrder(IMembershipService membershipService) : base(membershipService)
        {
        }

        public override PurchaseResult Purchase(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}