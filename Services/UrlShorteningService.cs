using Microsoft.EntityFrameworkCore;
namespace UrlShortener.Services
{
    public class UrlShorteningService
    {
        public const int NumberOfCharactersInUrl = 7;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";


        private readonly Random _random = new();
        private readonly ApplicationDbContext _dbContext;
        public  UrlShorteningService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> GetUniqueCode()
        {
            var codeChars = new char[NumberOfCharactersInUrl];

            while (true)
            {
                for (var i = 0; i < NumberOfCharactersInUrl; i++)
                {
                    var randomIndex = _random.Next(Alphabet.Length);

                    codeChars[i] = Alphabet[randomIndex];
                }
                var code = new string(codeChars);

                if (! await _dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }

            }
        }
    }
}
