using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PatternLib;
using Rhino.Mocks;

namespace UnitTests
{
    [TestFixture]
    public class EmailNotifierTests
    {
        [Test]
        public void Will_contain_multiple_Affiliates_with_Id_and_Name_specified_in_message_returned()
        {
            // Arrange
            var oberversToBeNotified = new List<IAffiliate>
                {
                    new EasyBooking {Id = 111, Name = "EasyBooker A"},
                    new EasyBooking {Id = 22, Name = "EasyBooker B"},
                    new EasyBooking {Id = 333, Name = "EasyBooker C"},
                };
            var expectedMessage = string.Format(
                                    "Email notification sent to: {0} (ID={1}), {2} (ID={3}), {4} (ID={5})",
                                    oberversToBeNotified[0].Name,
                                    oberversToBeNotified[0].Id,
                                    oberversToBeNotified[1].Name,
                                    oberversToBeNotified[1].Id,
                                    oberversToBeNotified[2].Name,
                                    oberversToBeNotified[2].Id);

            // Act
            var actualMessage = new EmailNotifier().UpdateObservers(oberversToBeNotified);

            // Assert
            Assert.That(expectedMessage, Is.EqualTo(actualMessage));
        }

        [Test]
        public void Will_notify_all_Affiliates_each_once()
        {
            // Arrange
            var notifier = new EmailNotifier();

            var affiliate1 = MockRepository.GenerateMock<IAffiliate>();
            var affiliate2 = MockRepository.GenerateMock<IAffiliate>();
            var affiliate3 = MockRepository.GenerateMock<IAffiliate>();
            affiliate1.Expect(a => a.Update()).Return(true).Repeat.Once();
            affiliate2.Expect(a => a.Update()).Return(true).Repeat.Once();
            affiliate3.Expect(a => a.Update()).Return(true).Repeat.Once();

            var oberversToBeNotified = new List<IAffiliate>
                    {
                        affiliate1,
                        affiliate2,
                        affiliate3
                    };

            // Act
            notifier.UpdateObservers(oberversToBeNotified);

            // Assert
            affiliate1.VerifyAllExpectations();
        }
    }
}
