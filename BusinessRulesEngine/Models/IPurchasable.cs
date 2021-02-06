namespace BusinessRulesEngine.Models
{
    internal interface IPurchasable
    {
        PurchaseResult Purchase(string orderId);
    }
}