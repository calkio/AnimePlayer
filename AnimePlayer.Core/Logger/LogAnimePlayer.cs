using Serilog;

namespace AnimePlayer.Core.Logger
{
    public static class LogAnimePlayer
    {
        public static ILogger Log { get; set; } = new LoggerConfiguration()
                                                     .MinimumLevel.Debug()
                                                     .WriteTo.File(@"D:\Dev\Asp.net\Logger\AnimePlayer", rollingInterval: RollingInterval.Day)
                                                     .CreateLogger();
    }
}
