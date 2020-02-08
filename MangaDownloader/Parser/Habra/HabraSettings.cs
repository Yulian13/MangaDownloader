namespace MangaDownloader.Parser.Habra
{
    class HabraSettings : IParserSettings
    {
        public HabraSettings(string baseUrl, string Prefix)
        {
            BaseUrl = $"{baseUrl}/{Prefix}";
        }

        public string BaseUrl { get; set; }
    }
}
