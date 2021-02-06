using System;

namespace BusinessRulesEngine.Models
{
    public class PurchaseResult
    {
        public Guid OrderId { get; set; }
        public bool Success { get; set; }
    }
}