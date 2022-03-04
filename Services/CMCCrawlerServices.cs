using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using webapi_example_services.Models.Entities;

namespace webapi_example_services.Services
{
    public class CMCCrawlerServices : ICMCCrawlerServices
    {
        public async Task<List<CoinMarketCapNew>> GetNewCoin()
        {
           var config = Configuration.Default.WithDefaultLoader();
            var address = "https://coinmarketcap.com/new/";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);


            var tableRowSelector = "table tbody tr";
            var tableRow = document.QuerySelectorAll(tableRowSelector);
            var coins = new List<CoinMarketCapNew>();

            foreach (var row in tableRow)
            {
                var nameCell = row.QuerySelector("td:nth-child(3) p:nth-child(1)");
                var codeCell = row.QuerySelector("td:nth-child(3) p:nth-child(2)");
                var priceCell = row.QuerySelector("td:nth-child(4) span:nth-child(1)");
                var change1hCell = row.QuerySelector("td:nth-child(5) span:nth-child(1)");
                var change1hCellIcon = change1hCell.QuerySelector("span span").ClassName;
                double change1hPositive = 1;
                if (change1hCellIcon == "icon-Caret-up")
                {
                    change1hPositive = 1;
                }
                else
                {
                    change1hPositive = -1;
                }
                var change24hCell = row.QuerySelector("td:nth-child(6) span:nth-child(1)");
                var change24hCellIcon = change24hCell.QuerySelector("span span").ClassName;
                double change24hPositive = 1;
                if (change24hCellIcon == "icon-Caret-up")
                {
                    change24hPositive = 1;
                }
                else
                {
                    change24hPositive = -1;
                }
                var fullDilutedMarketCapCell = row.QuerySelector("td:nth-child(7)");
                var volume24Cell = row.QuerySelector("td:nth-child(8)");
                var blockChainCell = row.QuerySelector("td:nth-child(9) div");
                var AddedCell =  row.QuerySelector("td:nth-child(10)");
                coins.Add(
                    new CoinMarketCapNew
                    {
                        Name = nameCell.TextContent,
                        Code =
                          priceCell.TextContent,
                        PriceString = priceCell.TextContent,
                        Change1h = Double.Parse(change1hCell.TextContent.Replace("%", "")) * change1hPositive,
                        Change24h = Double.Parse(change24hCell.TextContent.Replace("%", "")) * change24hPositive,
                        FullDilutedMarketCapString = fullDilutedMarketCapCell.TextContent,
                        Volume24hString = volume24Cell.TextContent,
                        BlockChain = blockChainCell.TextContent,
                        Added = AddedCell.TextContent,
                        UpdatedAt = DateTime.Now.ToLocalTime()
                    });
            }
            return coins;
        }
    }
}