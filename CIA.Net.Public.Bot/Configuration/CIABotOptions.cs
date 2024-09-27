namespace CIA.Net.Public.Bot.Configuration
{
    internal class CIABotOptions
    {
        public string Secret { get; set; } = string.Empty;
        public string AdminId { get; set; } = string.Empty;
        public string CIABotId { get; set; } = string.Empty;
        public string ErrorChannelId { get; set; } = string.Empty;
    }
}
