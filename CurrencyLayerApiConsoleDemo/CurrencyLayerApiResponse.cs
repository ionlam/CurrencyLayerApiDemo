namespace CurrencyLayerApiConsoleDemo
{
    public class CurrencyLayerApiResponse
    {
        public bool Success { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public int Timestamp { get; set; }
        public string Source { get; set; }
        public CurrencyLayerApiQuotes Quotes { get; set; }
    }
}
