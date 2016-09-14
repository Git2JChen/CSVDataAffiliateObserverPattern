using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PatternLib;

namespace UnitTests
{
    [TestFixture]
    public class CSVDataFeedTests
    {
        [Test]
        public void CSVDataFeed_will_store_a_list_of_Affiliates()
        {
            // Act
            var expectedAffiliates = new CSVDataFeed().Affiliates;

            // Assert
            expectedAffiliates.Should().BeOfType<List<Affiliate>>();
        }

        [TestCase(38)]
        [TestCase(7)]
        [TestCase(102)]
        public void CSVDataFeed_can_attach_a_Affiliate_with_Id_specified(int id)
        {
            // Arrange
            var affiliateAttached = new Affiliate { Id = id };
            var csvDataFeed = new CSVDataFeed();

            // Act
            csvDataFeed.Attach(affiliateAttached);
            var affiliatesActual = csvDataFeed.Affiliates;

            // Assert
            affiliatesActual.Should().ContainSingle(a => a.Id == affiliateAttached.Id);
        }

        [TestCase(38)]
        [TestCase(7)]
        [TestCase(102)]
        public void CSVDataFeed_can_dettach_the_Affiliate_with_Id_specified(int id)
        {
            // Arrange
            var csvDataFeed = new CSVDataFeed();
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
        public void CSVDataFeed_can_change_its_price()
        {
            // Arrange
            const decimal oldPrice = 10M;
            const decimal newPrice = 20M;
            const decimal expectedPrice = newPrice;
            var csvDataFeed = new CSVDataFeed { Price = oldPrice };

            // Act
            csvDataFeed.Price = newPrice;

            // Assert
            Assert.AreEqual(expectedPrice, csvDataFeed.Price);
        }
    }
}
