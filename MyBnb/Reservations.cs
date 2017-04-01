using System;
using System.Diagnostics.Contracts;

namespace MyBnb
{
    public static class Reservations
    {
        public class Config
        {
            public int MinimumStay { get; set; }
        }

        public static Action<Reservation> SetupReservationHandler(Action<Reservation> persist, Config config)
            => reservation => 
        {
            DateTime clock() => DateTime.Now;

            bool isValid(Reservation r) =>
                CheckOutIsValid(config.MinimumStay, r)
                    && CheckInIsValid(clock, r)
                    && Countries.CodeIsValid(r.CountryCode);

            HandleReservation(isValid, persist, reservation);
        };

        [Pure]
        internal static void HandleReservation(Func<Reservation, bool> isValid
            , Action<Reservation> persist, Reservation r)
        {
            if (isValid(r)) persist(r);
        }

        [Pure]
        internal static bool CheckInIsValid(Func<DateTime> clock, Reservation r) =>
            clock().Date <= r.CheckIn.Date;

        [Pure]
        internal static bool CheckOutIsValid(int minStay, Reservation r) =>
            r.CheckIn.Date.AddDays(minStay) <= r.CheckOut.Date;
    }
}
