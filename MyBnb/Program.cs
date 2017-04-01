using System;
using StackExchange.Redis;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("MyBnb.Tests")]

namespace MyBnb
{
    public static class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(Countries.CodeIsValid("it"));
            Console.WriteLine(Countries.CodeIsValid("i"));
            // var redis = ConnectionMultiplexer.Connect("localhost");
            // redis.Subscribe<Reservation>("reservation-requests", Reservations.Make);
        }
    }
}
