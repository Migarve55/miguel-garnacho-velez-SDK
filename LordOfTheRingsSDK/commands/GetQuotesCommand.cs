
namespace LordOfTheRingsSDK;

public class GetQuotesCommand : BaseCommand<Quote>
{
    public GetQuotesCommand(string url, string key)
        : base(url + "/quote", key) 
    {
    }
}