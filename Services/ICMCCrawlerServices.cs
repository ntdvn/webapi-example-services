using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_example_services.Models.Entities;

namespace webapi_example_services.Services
{
    public interface ICMCCrawlerServices
    {
        public Task<List<CoinMarketCapNew>> GetNewCoin();
    }
}