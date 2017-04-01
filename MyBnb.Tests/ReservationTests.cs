using System;
using Xunit;

namespace MyBnb.Tests
{
    public class ReservationsTests
    {
        [Fact]
        void WhenCheckOutSameDayAsCheckIn_ThenValidationFails()
        {
            // arrange
            var r = new Reservation 
            {
                CheckIn = new DateTime(2017, 12, 13),
                CheckOut = new DateTime(2017, 12, 13),
            };

            // act
            var actual = Reservations.CheckOutIsValid(r);

            // assert
            Assert.False(actual);
        }
    }
}
