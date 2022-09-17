
namespace LordOfTheRingsSDK;

public class GetChaptersCommand : BaseCommand<Chapter>
{
    public GetChaptersCommand(string url, string key)
        : base(url + "/chapter", key) 
    {
    }
}