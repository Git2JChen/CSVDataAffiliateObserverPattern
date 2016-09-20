using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PatternLib;
using Rhino.Mocks;

namespace UnitTests
{
    [TestFixture]
    public class BaseDataFeedTests
    {
        [Test]
        public void BaseDataFeed_will_store_a_list_of_Affiliates()
        {
            // Act
            var notifier = MockRepository.GenerateMock<INotifier>();
            var expectedAffiliates = new BaseDataFeed(notifier).Affiliates;

            // Assert
            expectedAffiliates.Should().BeOfType<List<IAffiliate>>();
        }

        [TestCase(38, "Easy Booker 38")]
        [TestCase(7, "Easy Booker 7")]
        [TestCase(102, "Easy Booker 102")]
        public void BaseDataFeed_can_attach_a_Affiliate_with_Id_and_Name_specified(int id, string name)
        {
            // Arrange
            var notifier = MockRepository.GenerateMock<INotifier>();
            var affiliateAttached = new EasyBooking { Id = id, Name = name };
            var csvDataFeed = new BaseDataFeed(notifier);

            // Act
            csvDataFeed.Attach(affiliateAttached);
            var affiliatesActual = csvDataFeed.Affiliates;

            // Assert
            affiliatesActual.Should().ContainSingle(a => a.Id == affiliateAttached.Id && a.Name == name);
        }

        [TestCase(38)]
        [TestCase(7)]
        [TestCase(102)]
        public void BaseDataFeed_can_dettach_the_Affiliate_with_Id_specified(int id)
        {
            // Arrange
            var notifier = MockRepository.GenerateMock<INotifier>();
            var csvDataFeed = new BaseDataFeed(notifier);
            var affiliateDetached = new EasyBooking { Id = id };
            var affiliates = new List<IAffiliate>
            {
                new EasyBooking {Id = 7},
                new EasyBooking {Id = 38},
                new EasyBooking {Id = 102}
            };

            csvDataFeed.Affiliates = affiliates;

            // Act
            csvDataFeed.Detach(affiliateDetached);
            var affiliatesActual = csvDataFeed.Affiliates;

            // Assert
            affiliatesActual.Should().OnlyContain(a => a.Id != affiliateDetached.Id);
        }

        [Test]
        public void BaseDataFeed_can_change_its_price()
        {
            // Arrange
            const decimal oldPrice = 10M;
            const decimal newPrice = 20M;
            const decimal expectedPrice = newPrice;
            var notifier = MockRepository.GenerateMock<INotifier>();
            var csvDataFeed = new BaseDataFeed(notifier) { Price = oldPrice };

            // Act
            csvDataFeed.Price = newPrice;

            // Assert
            Assert.AreEqual(expectedPrice, csvDataFeed.Price);
        }

        [Test]
        public void BaseDataFeed_can_make_notification_via_Email()
        {
            // Arrange
            var notifier = MockRepository.GenerateMock<INotifier>();
            var csvDataFeed = new BaseDataFeed(notifier);
            csvDataFeed.Attach(new EasyBooking());
            notifier.Expect(x => x.UpdateObservers(csvDataFeed.Affiliates)).Return("Email notification sent");

            // Act
            csvDataFeed.Notify();
            
            // Assert
            notifier.VerifyAllExpectations();
        }
    }
}
