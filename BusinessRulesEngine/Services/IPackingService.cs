namespace BusinessRulesEngine.Services
{
    public interface IPackingService
    {
        bool GeneratePackingSlip(string orderId, string destination);

        bool AddBundledItems(string orderId);
    }
}