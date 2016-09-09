using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PatternLib;

namespace UnitTests
{
    [TestFixture]
    public class PatternLibTests
    {
        [Test]
        public void CSVData_will_store_a_list_of_Affiliates()
        {
            // Act
            var expectedAffiliates = new CSVData().Affiliates;

            // Assert
            expectedAffiliates.Should().BeOfType<List<Affiliate>>();
        }
    }
}
