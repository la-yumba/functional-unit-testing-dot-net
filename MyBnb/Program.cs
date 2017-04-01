using System;
using StackExchange.Redis;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("MyBnb.Tests")]

namespace MyBnb
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            SetupReservations(redis);
        }

        static void SetupReservations(ConnectionMultiplexer redis)
        {
            void persist(Reservation r) => redis.ListLeftPush("reservations", r);
            var handler = Reservations.SetupReservationHandler(persist);
            redis.Subscribe<Reservation>("reservation-requests", handler);
        }
    }
}
