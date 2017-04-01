using System;

namespace MyBnb
{
    public static class Reservations
    {
        public static void Make(Reservation r)
        {
            if (CheckOutIsValid(r))
            	throw new NotImplementedException();
        }

        internal static bool CheckInIsValid(Reservation r) =>
            DateTime.Now.Date <= r.CheckIn.Date;       

        internal static bool CheckOutIsValid(Reservation r) =>
            r.CheckIn.Date < r.CheckOut.Date;       
    }
}
