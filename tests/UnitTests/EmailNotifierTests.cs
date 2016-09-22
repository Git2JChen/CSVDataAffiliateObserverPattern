using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PatternLib;

namespace UnitTests
{
    [TestFixture]
    public class EmailNotifierTests
    {
        [Test]
        public void Will_notify_a_single_Affiliate_with_Id_specified_in_message_returned()
        {
            // Arrange
            var oberversToBeNotified = new List<IAffiliate>
                {
                    new EasyBooking {Id = 123, Name = "EasyBooker A"}
                };
            var expectedMessage = string.Format(
                                    "Email notification sent to: {0} (ID={1})", 
                                    oberversToBeNotified[0].Name, 
                                    oberversToBeNotified[0].Id);

            // Act
            var actualMessage = new EmailNotifier().UpdateObservers(oberversToBeNotified);

            // Assert
            Assert.That(expectedMessage, Is.EqualTo(actualMessage));
        }
    }
}
