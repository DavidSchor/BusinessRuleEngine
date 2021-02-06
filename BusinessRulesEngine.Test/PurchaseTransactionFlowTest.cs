using BusinessRulesEngine.Models;
using BusinessRulesEngine.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace BusinessRulesEngine.Test
{
    public class PurchaseTransactionFlowTest
    {
        [Fact]
        public void GIVEN_PhysicalPurchaseOrder_WHEN_Purchase_THEN_PackingSlipSentToShipping()
        {
            var orderId = "SomeId";
            var packingServiceMock = new Mock<IPackingService>();

            var sut = new PhysicalItem(packingServiceMock.Object);

            var result = sut.Purchase(orderId);

            packingServiceMock.Verify(ps => ps.GeneratePackingSlip(orderId, DepartmentConstants.Shipping));
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_BookPurchaseOrder_WHEN_Purchase_THEN_PackingSlipSentToShippingAndRoyaltyToRoyalty()
        {
            var orderId = "SomeId";
            var packingServiceMock = new Mock<IPackingService>();

            var sut = new Book(packingServiceMock.Object);

            var result = sut.Purchase(orderId);

            packingServiceMock.Verify(ps => ps.GeneratePackingSlip(orderId, DepartmentConstants.Shipping));
            packingServiceMock.Verify(ps => ps.GeneratePackingSlip(orderId, DepartmentConstants.Royalty));
            result.Success.Should().BeTrue();
        }
    }
}