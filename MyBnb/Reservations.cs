using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MyBnb
{
    public static class Reservations
    {
        public class Config
        {
            public int MinimumStay { get; set; }
        }

        public static Action<Reservation> SetupReservationHandler(Action<Reservation> persist, Config config)
        {
            DateTime clock() => DateTime.Now;

            var predicates = new []
            {
                CheckOutIsValid(config.MinimumStay),
                CheckInIsValid(clock),
                r => Countries.CodeIsValid(r.CountryCode)
            };

            return HandleReservation(predicates, persist);
        }

        [Pure]
        internal static Action<Reservation> HandleReservation(IEnumerable<Predicate<Reservation>> predicates
            , Action<Reservation> persist)
            => r =>
        {
            if (predicates.All(p => p(r))) 
                persist(r);
        };

        [Pure]
        internal static Predicate<Reservation> CheckInIsValid(Func<DateTime> clock)
            => r =>
            clock().Date <= r.CheckIn.Date;

        [Pure]
        internal static Predicate<Reservation> CheckOutIsValid(int minStay)
            => r =>
            r.CheckIn.Date.AddDays(minStay) <= r.CheckOut.Date;
    }
}
