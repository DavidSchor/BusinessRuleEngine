namespace BusinessRulesEngine.Services
{
    public interface IPackingService
    {
        void GeneratePackingSlip(string orderId, string destination);
    }
}