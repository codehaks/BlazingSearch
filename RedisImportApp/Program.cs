﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisImportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var db = redis.GetDatabase();
            var names = System.IO.File.ReadAllLines(@"E:\Projects\Data\Firstnames.txt");
            var list = new List<HashEntry>();
            var counter = 1;
            foreach (var item in names.Take(10000))
            {
                list.Add(new HashEntry(new RedisValue(counter.ToString()), new RedisValue(item)));
                counter++;
            }

            db.HashSet(new RedisKey("tags"),list.ToArray());

        }
    }
}
