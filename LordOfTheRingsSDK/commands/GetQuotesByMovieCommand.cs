
namespace LordOfTheRingsSDK;

public class GetQuotesByMovieCommand : BaseCommand<Quote>
{
    public GetQuotesByMovieCommand(string url, string key, string movieId)
        : base(url + "/movie/" + movieId + "/quote", key) 
    {
    }
}