using AutoFixture;
using AutoFixture.AutoMoq;
using BusinessRulesEngine.Models.OrderTypes;
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
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var packingServiceMock = fixture.Freeze<Mock<IPackingService>>();
            var sut = fixture.Create<PhysicalItemOrder>();

            var result = sut.Purchase(orderId);

            packingServiceMock.Verify(ps => ps.GeneratePackingSlip(orderId, DepartmentConstants.Shipping));
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_BookPurchaseOrder_WHEN_Purchase_THEN_PackingSlipSentToShippingAndRoyaltyToRoyalty()
        {
            var orderId = "SomeId";
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var packingServiceMock = fixture.Freeze<Mock<IPackingService>>();

            var sut = fixture.Create<BookOrder>();

            var result = sut.Purchase(orderId);

            packingServiceMock.Verify(ps => ps.GeneratePackingSlip(orderId, DepartmentConstants.Shipping));
            packingServiceMock.Verify(ps => ps.GeneratePackingSlip(orderId, DepartmentConstants.Royalty));
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_PhysicalPurchaseOrder_WHEN_Purchase_THEN_CommissionIsRegistered()
        {
            var orderId = "SomeId";
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var commisionServiceMock = fixture.Freeze<Mock<ICommissionService>>();
            var sut = fixture.Create<PhysicalItemOrder>();

            var result = sut.Purchase(orderId);

            commisionServiceMock.Verify(cs => cs.GrantCommission(orderId));
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_BookPurchaseOrder_WHEN_Purchase_THEN_CommissionIsRegistered()
        {
            var orderId = "SomeId";
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var commisionServiceMock = fixture.Freeze<Mock<ICommissionService>>();
            var sut = fixture.Create<BookOrder>();

            var result = sut.Purchase(orderId);

            commisionServiceMock.Verify(cs => cs.GrantCommission(orderId));
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_NewMembershipOrder_WHEN_Purchase_THEN_MembershipIsActivated()
        {
            var orderId = "SomeId";
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var membershipServiceMock = fixture.Freeze<Mock<IMembershipService>>();
            membershipServiceMock.Setup(ms => ms.ActivateMembership(orderId)).Returns(true);
            var sut = fixture.Create<NewMembershipOrder>();

            var result = sut.Purchase(orderId);

            membershipServiceMock.Verify(ms => ms.ActivateMembership(orderId));
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void GIVEN_NewMembershipOrder_WHEN_MembershipActivationNotSuccessfull_THEN_SuccessIsFalse()
        {
            var orderId = "SomeId";
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var membershipServiceMock = fixture.Freeze<Mock<IMembershipService>>();
            membershipServiceMock.Setup(ms => ms.ActivateMembership(orderId)).Returns(false);
            var sut = fixture.Create<NewMembershipOrder>();

            var result = sut.Purchase(orderId);

            membershipServiceMock.Verify(ms => ms.ActivateMembership(orderId));
            result.Success.Should().BeFalse();
        }
    }
}