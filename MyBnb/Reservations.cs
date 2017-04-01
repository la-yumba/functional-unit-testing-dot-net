using System;
using System.Diagnostics.Contracts;

namespace MyBnb
{
    public static class Reservations
    {
        public static Action<Reservation> SetupReservationHandler(Action<Reservation> persist)
            => reservation => 
        {
            DateTime clock() => DateTime.Now;

            bool isValid(Reservation r) =>
                CheckOutIsValid(r)
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
        internal static bool CheckOutIsValid(Reservation r) =>
            r.CheckIn.Date < r.CheckOut.Date;
    }
}
