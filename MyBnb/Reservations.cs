using System;

namespace MyBnb
{
    public static class Reservations
    {
        public static void Make(Reservation r)
        {
            if (CheckOutIsValid(r)
                && CheckInIsValid(r)
                && Countries.CodeIsValid(r.CountryCode))
                Persist(r);
        }

        static void Persist(Reservation r) => throw new NotImplementedException();

        // isolate the side effect of DateTime.Now
        // this function only has side effects
        // HOWEVER note that this is not the final solution
        static bool CheckInIsValid(Reservation r) =>
            CheckInIsValid(DateTime.Now, r);

        // this function only has logic
        internal static bool CheckInIsValid(DateTime now, Reservation r) =>
            now.Date <= r.CheckIn.Date;

        internal static bool CheckOutIsValid(Reservation r) =>
            r.CheckIn.Date < r.CheckOut.Date;
    }
}
