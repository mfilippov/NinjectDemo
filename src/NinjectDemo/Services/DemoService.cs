using System;
using System.Collections.Generic;

namespace NinjectDemo.Services
{
    public class DemoService : IDemoService
    {
        private readonly int _rnd;
        public DemoService()
        {
            _rnd = new Random().Next(1, 1000);
        }
        public List<string> GetData()
        {
            return new List<string> { $"Super important data {_rnd}" };
        }
    }
}