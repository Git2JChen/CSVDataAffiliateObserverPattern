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
    public class TwitterNotifierTests
    {
        [Test]
        public void Will_contain_multiple_Affiliates_with_Id_and_Name_specified_in_message_returned()
        {
            // Arrange
            var oberversToBeNotified = new List<IAffiliate>
                {
                    new SmartTravel {Id = 111, Name = "SmartTravel A"},
                    new SmartTravel {Id = 22, Name = "SmartTravel B"},
                    new SmartTravel {Id = 333, Name = "SmartTravel C"},
                };
            var expectedMessage = string.Format(
                                    "Twitter notification sent to: {0} (ID={1}), {2} (ID={3}), {4} (ID={5})",
                                    oberversToBeNotified[0].Name,
                                    oberversToBeNotified[0].Id,
                                    oberversToBeNotified[1].Name,
                                    oberversToBeNotified[1].Id,
                                    oberversToBeNotified[2].Name,
                                    oberversToBeNotified[2].Id);

            // Act
            var actualMessage = new TwitterNotifier().UpdateObservers(oberversToBeNotified);

            // Assert
            Assert.That(expectedMessage, Is.EqualTo(actualMessage));
        }

        [Test]
        public void Will_notify_multiple_Affiliates()
        {
            // Arrange
            var notifier = new TwitterNotifier();

            var affiliate1 = MockRepository.GenerateMock<IAffiliate>();
            var affiliate2 = MockRepository.GenerateMock<IAffiliate>();
            var affiliate3 = MockRepository.GenerateMock<IAffiliate>();
            affiliate1.Expect(a => a.Update()).Return(true);
            affiliate2.Expect(a => a.Update()).Return(true);
            affiliate3.Expect(a => a.Update()).Return(true);

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
