namespace LordOfTheRingsSDK;

public class GetCharactersCommand : BaseCommand<Character>
{
    public GetCharactersCommand(string url, string key)
        : base(url + "/character", key) 
    {
    }
}