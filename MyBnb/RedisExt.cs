using System;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace MyBnb
{
    public static class RedisExt
    {
        public static void Subscribe<T>(this ConnectionMultiplexer redis, string channel, Action<T> act) => 
            redis.GetSubscriber()
                .Subscribe(channel, 
                    (_, val) => act(JsonConvert.DeserializeObject<T>(val)));

        public static void Send(this ConnectionMultiplexer redis, string channel, object message) => 
            redis.GetDatabase(0).PublishAsync(channel, JsonConvert.SerializeObject(message));

        public static void ListLeftPush<T>(this ConnectionMultiplexer redis, string key, T value) => 
            redis.GetDatabase(0).ListLeftPush(key, JsonConvert.SerializeObject(value));
    }
}