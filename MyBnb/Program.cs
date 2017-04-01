using System;
using System.IO;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("MyBnb.Tests")]

namespace MyBnb
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var config = SetupConfig();
            var redis = ConnectionMultiplexer.Connect(config["redisUrl"]);
            SetupReservations(redis, config);
        }

        static IConfiguration SetupConfig() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static void SetupReservations(ConnectionMultiplexer redis, IConfiguration config)
        {
            // interface segregation: only give it what it needs!
            var reservationsConfig = new Reservations.Config();
            config.GetSection("reservations").Bind(reservationsConfig);

            void persist(Reservation r) => redis.ListLeftPush("reservations", r);
            var handler = Reservations.SetupReservationHandler(persist, reservationsConfig);
            redis.Subscribe<Reservation>("reservation-requests", handler);
        }
    }
}
