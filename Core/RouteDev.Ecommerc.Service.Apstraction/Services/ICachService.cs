using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Services
{
    public interface ICachService
    {
        public Task SetValueAsync(string key, object value, TimeSpan TTL);
        public Task<string?> GetValueAsync(string key);
    }
}
