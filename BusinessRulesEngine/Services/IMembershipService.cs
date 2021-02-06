namespace BusinessRulesEngine.Services
{
    public interface IMembershipService
    {
        void ActivateMembership(string orderId);

        void UpgradeMembership(string orderId);
    }
}