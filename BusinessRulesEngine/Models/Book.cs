using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.Models
{
    public class Book : PhysicalItem
    {
        public Book(IPackingService packingService) : base(packingService)
        {
        }
    }
}