using HtmlAgilityPack;
using HuelMonitor.Data;
using System.Text.Json;

namespace HuelMonitor
{
    internal static class AvailabilityChecker
    {
        public static bool IsChocolateHuelAvailable()
        {
            Console.WriteLine("Checking availability of chocolate Huel...");

            HtmlWeb web = new();
            var doc = web.Load("https://uk.huel.com/products/huel-ready-to-drink");
            var dataProductJsonNode = doc.DocumentNode.SelectSingleNode("//script[@data-product-json]");
            string dataProductJson = dataProductJsonNode.InnerText;
            var dataProducts = JsonSerializer.Deserialize<DataProducts>(dataProductJson);

            if (dataProducts == null)
            {
                throw new ApplicationException("Unable to read Huel flavour data.");
            }

            var variants = dataProducts.variants;

            var chocolate = variants.FirstOrDefault(x => x.title.Contains("Chocolate"));
            if (chocolate == null)
            {
                throw new ApplicationException("Unable to find chocolate flavour.");
            }

            return IsAvailable(chocolate);
        }

        static bool IsAvailable(Variant variant)
        {
            switch (variant.available)
            {
                case "yes":
                    return true;
                case "subscription_only":
                    return false;
                default:
                    throw new ApplicationException($"Unable to parse availability status '{variant.available}'.");
            }
        }
    }
}
