
namespace LordOfTheRingsSDK;

public class GetChaptersByBookCommand : BaseCommand<Chapter>
{
    public GetChaptersByBookCommand(string url, string key, string bookId)
        : base(url + "/book/" + bookId + "/chapter", key) 
    {
    }
}