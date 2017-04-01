using System;
using Xunit;

namespace MyBnb.Tests
{
    public class ReservationsTests
    {
        [Fact]
        void WhenCheckInIsPast_ThenValidationFails()
        {
            var r = new Reservation 
            {
                CheckIn = new DateTime(2017, 12, 13),
            };

            var actual = Reservations.CheckInIsValid(r);

            Assert.Equal(true, actual);
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData( 0, false)]
        [InlineData( 1, true)]
        void OnlyWhenCheckOutAfterCheckIn_ThenValidationPasses(int diff, bool expected)
        {
            var checkIn = new DateTime(2017, 12, 13);
            var r = new Reservation 
            {
                CheckIn = checkIn,
                CheckOut = checkIn.AddDays(diff),
            };

            var actual = Reservations.CheckOutIsValid(r);

            Assert.Equal(expected, actual);
        }
    }
}
