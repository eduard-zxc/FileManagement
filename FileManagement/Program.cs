using System.Text;

namespace FileManagement
{
    public static class Program
    {
        private static string LogDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        public static async Task LogAsync(string methodName, bool isSuccess)
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string logFilePath = Path.Combine(LogDirectory, $"Logs_{date}.txt");

            string outcome = isSuccess ? "success" : "failure";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {methodName} | {outcome}";

            await File.AppendAllTextAsync(logFilePath, logMessage + Environment.NewLine, Encoding.UTF8);

        }
        static async Task Main()
        {
            AuctionService auctionService = new();
            Auction auction = new();
            await auctionService.CreateAuctionAsync(auction);
            await auctionService.GetAuctionsAsync();
        }
    }

    public class AuctionService
    {
        public async Task CreateAuctionAsync(Auction auction)
        {
            const string methodName = nameof(CreateAuctionAsync);
            try
            {
                await Program.LogAsync(methodName, true);
            }
            catch (Exception)
            {
                await Program.LogAsync(methodName, false);
                throw;
            }
        }

        public async Task<List<Auction>> GetAuctionsAsync()
        {
            const string methodName = nameof(GetAuctionsAsync);
            try
            {
                await Program.LogAsync(methodName, true);
                return [];
            }
            catch (Exception)
            {
                await Program.LogAsync(methodName, false);
                throw;
            }
        }
    }

    public class Auction
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}

