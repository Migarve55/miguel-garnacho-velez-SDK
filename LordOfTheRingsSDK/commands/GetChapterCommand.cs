namespace LordOfTheRingsSDK;

public class GetChapterCommand : BaseCommand<Chapter>
{
    public GetChapterCommand(string url, string key, string id)
        : base(url + "/chapter/" + id, key) 
    {
    }
}