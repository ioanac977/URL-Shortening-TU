namespace Web_API.Models
{
    public class UrlCollectionDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ShortUrlsCollectionName { get; set; } = null!;
    }
}
