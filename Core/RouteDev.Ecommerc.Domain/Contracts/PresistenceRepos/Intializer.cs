using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos
{
    public interface Intializer
    {
        Task InitializeAsync();
        Task SeedDataAsync();
    }
}
