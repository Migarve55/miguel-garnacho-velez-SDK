namespace LordOfTheRingsSDK;

public class GetBooksCommand : BaseCommand<Book>
{
    public GetBooksCommand(string url, string key)
        : base(url + "/book", key) 
    {
    }
}