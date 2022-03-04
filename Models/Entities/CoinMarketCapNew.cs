using System;

namespace webapi_example_services.Models.Entities
{
    public class CoinMarketCapNew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public string PriceString { get; set; }

        public double Change1h { get; set; }
        public double Change24h { get; set; }
        public double FullDilutedMarketCap { get; set; }
        public string FullDilutedMarketCapString { get; set; }
        public double Volume24h { get; set; }
        public string Volume24hString { get; set; }
        public string BlockChain { get; set; }
        public string Added { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}