
namespace LordOfTheRingsSDK;

public class GetQuotesByCharacterCommand : BaseCommand<Quote>
{
    public GetQuotesByCharacterCommand(string url, string key, string characterId)
        : base(url + "/character/" + characterId + "/quote", key) 
    {
    }
}