using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void CSVDataFeed_can_attach_a_Affiliate_with_Id_of_5()
        {
            // Arrange
            var affiliate = new Affiliate();
            var csvDataFeed = new CSVDataFeed();

            // Act
            csvDataFeed.Attach(affiliate);
            var affiliatesActual = csvDataFeed.Affiliates.ToList();

            // Assert
            affiliatesActual.Count.Should().Be(1);
        }

        [Test]
        public void CSVDataFeed_can_dettach_a_Affiliate()
        {
            // Arrange
            var affiliate = new Affiliate();
            var csvDataFeed = new CSVDataFeed();

            // Act
            csvDataFeed.Detach(affiliate);
            var affiliatesActual = csvDataFeed.Affiliates;

            // Assert
            affiliatesActual.Count.Should().Be(1);
        }
    }
}
