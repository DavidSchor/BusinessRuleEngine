namespace BusinessRulesEngine.Services
{
    public interface IMembershipService
    {
        bool ActivateMembership(string orderId);

        bool UpgradeMembership(string orderId);
    }
}