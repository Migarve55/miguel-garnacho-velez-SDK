
namespace LordOfTheRingsSDK;

public class GetMovieCommand : BaseCommand<Movie>
{
    public GetMovieCommand(string url, string key, string id)
        : base(url + "/movie/" + id, key) 
    {
    }
}