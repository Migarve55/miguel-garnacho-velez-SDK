namespace LordOfTheRingsSDK;

public class GetBookCommand : BaseCommand<Book>
{
    public GetBookCommand(string url, string key, string id)
        : base(url + "/book/" + id, key) 
    {
    }
}