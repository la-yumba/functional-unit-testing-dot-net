using System;
using Xunit;

namespace MyBnb.Tests
{
    public class ReservationsTests
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData( 0, true)]
        [InlineData( 1, true)]
        void OnlyWhenCheckInIsPast_ThenValidationFails(int diff, bool expected)
        {
            var now = new DateTime(2017, 12, 13);
            var r = new Reservation 
            {
                CheckIn = now.AddDays(diff),
            };

            var actual = Reservations.CheckInIsValid(now, r);

            Assert.Equal(expected, actual);
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
