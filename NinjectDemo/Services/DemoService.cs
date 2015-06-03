using System.Collections.Generic;

namespace NinjectDemo.Services
{
    public class DemoService : IDemoService
    {
        public List<string> GetData()
        {
            return new List<string> { "Super important data" };
        }
    }
}