﻿using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PatternLib;
using Rhino.Mocks;

namespace UnitTests
{
    [TestFixture]
    public class HotelCSVDataFeedTests
    {
        [Test]
        public void HotelCSVDataFeed_will_store_a_list_of_Affiliates()
        {
            // Act
            var notifier = MockRepository.GenerateMock<TwitterNotifier>();
            var expectedAffiliates = new HotelCSVDataFeed(notifier).Affiliates;

            // Assert
            expectedAffiliates.Should().BeOfType<List<Affiliate>>();
        }

        [TestCase(38)]
        [TestCase(7)]
        [TestCase(102)]
        public void HotelCSVDataFeed_can_attach_a_Affiliate_with_Id_specified(int id)
        {
            // Arrange
            var notifier = MockRepository.GenerateMock<INotifier>();
            var affiliateAttached = new Affiliate { Id = id };
            var csvDataFeed = new HotelCSVDataFeed(notifier);

            // Act
            csvDataFeed.Attach(affiliateAttached);
            var affiliatesActual = csvDataFeed.Affiliates;

            // Assert
            affiliatesActual.Should().ContainSingle(a => a.Id == affiliateAttached.Id);
        }

        [TestCase(38)]
        [TestCase(7)]
        [TestCase(102)]
        public void HotelCSVDataFeed_can_dettach_the_Affiliate_with_Id_specified(int id)
        {
            // Arrange
            var notifier = MockRepository.GenerateMock<INotifier>();
            var csvDataFeed = new HotelCSVDataFeed(notifier);
            var affiliateDetached = new Affiliate { Id = id };
            var affiliates = new List<Affiliate>
            {
                new Affiliate {Id = 7},
                new Affiliate {Id = 38},
                new Affiliate {Id = 102}
            };

            csvDataFeed.Affiliates = affiliates;

            // Act
            csvDataFeed.Detach(affiliateDetached);
            var affiliatesActual = csvDataFeed.Affiliates;

            // Assert
            affiliatesActual.Should().OnlyContain(a => a.Id != affiliateDetached.Id);
        }

        [Test]
        public void HotelCSVDataFeed_can_change_its_price()
        {
            // Arrange
            const decimal oldPrice = 10M;
            const decimal newPrice = 20M;
            const decimal expectedPrice = newPrice;
            var notifier = MockRepository.GenerateMock<INotifier>();
            var csvDataFeed = new HotelCSVDataFeed(notifier) { Price = oldPrice };

            // Act
            csvDataFeed.Price = newPrice;

            // Assert
            Assert.AreEqual(expectedPrice, csvDataFeed.Price);
        }

        [Test]
        public void HotelCSVDataFeed_can_make_notification_via_Twitter()
        {
            // Arrange
            var notifier = MockRepository.GenerateMock<INotifier>();
            var csvDataFeed = new HotelCSVDataFeed(notifier);
            csvDataFeed.Attach(new Affiliate());
            notifier.Expect(x => x.UpdateObservers(csvDataFeed.Affiliates)).Return("Twitter notification sent");

            // Act
            csvDataFeed.Notify();
            
            // Assert
            notifier.VerifyAllExpectations();
        }
    }
}