using System.Text;

namespace CurrencyLayerApiConsoleDemo
{
    public class CurrencyLayerUrlBuilder
    {
        string BaseUrl { get; }
        string AccessKey { get; set; }

        public CurrencyLayerUrlBuilder(string baseUrl = null)
        {
            BaseUrl = baseUrl ?? "http://api.currencylayer.com/live";
        }

        public CurrencyLayerUrlBuilder AddAccessKey(string value)
        {
            AccessKey = value;
            return this;
        }

        public string Build()
        {
            var result = new StringBuilder();

            result.Append(BaseUrl);

            if (!BaseUrl.EndsWith("?"))
            {
                result.Append("?");
            }

            if (AccessKey != null)
            {
                result.Append($"access_key={AccessKey}&");
            }

            return result.ToString();
        }
    }
}
