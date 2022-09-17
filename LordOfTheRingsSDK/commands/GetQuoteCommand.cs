
namespace LordOfTheRingsSDK;

public class GetQuoteCommand : BaseCommand<Quote>
{
    public GetQuoteCommand(string url, string key, string id)
        : base(url + "/quote/" + id, key) 
    {
    }
}