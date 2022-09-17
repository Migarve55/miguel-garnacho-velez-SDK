
namespace LordOfTheRingsSDK;

public class GetCharacterCommand : BaseCommand<Character>
{
    public GetCharacterCommand(string url, string key, string id)
        : base(url + "/character/" + id, key) 
    {
    }
}