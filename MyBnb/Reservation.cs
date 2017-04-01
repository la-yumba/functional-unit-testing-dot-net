using System;

namespace MyBnb
{
    public class Reservation
    {
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
    	public string CountryCode { get; set; }
    }
}
