
namespace LordOfTheRingsSDK;

public class GetMoviesCommand : BaseCommand<Movie>
{
    public GetMoviesCommand(string url, string key)
        : base(url + "/movie", key) 
    {
    }
}