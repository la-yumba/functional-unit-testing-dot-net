using System;
using Xunit;

namespace MyBnb.Tests
{
    public class ReservationsTests
    {
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

        /*
        [Fact]
        void WhenCheckOutBeforeCheckIn_ThenValidationFails()
        {
            var r = new Reservation 
            {
                CheckIn = new DateTime(2017, 12, 13),
                CheckOut = new DateTime(2017, 12, 12),
            };

            var actual = Reservations.CheckOutIsValid(r);

            Assert.False(actual);
        }

        [Fact]
        void WhenCheckOutSameDayAsCheckIn_ThenValidationFails()
        {
            var r = new Reservation 
            {
                CheckIn = new DateTime(2017, 12, 13),
                CheckOut = new DateTime(2017, 12, 13),
            };

            var actual = Reservations.CheckOutIsValid(r);

            Assert.False(actual);
        }

        [Fact]
        void WhenCheckOutAfterCheckIn_ThenValidationPasses()
        {
            var r = new Reservation 
            {
                CheckIn = new DateTime(2017, 12, 13),
                CheckOut = new DateTime(2017, 12, 14),
            };

            var actual = Reservations.CheckOutIsValid(r);

            Assert.True(actual);
        }
        */
    }
}
