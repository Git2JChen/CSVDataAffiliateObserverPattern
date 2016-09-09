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
    }
}
