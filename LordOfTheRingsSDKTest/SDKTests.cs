using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using LordOfTheRingsSDK;

namespace LordOfTheRingsSDKTest;

[TestClass]
public class SDKTests 
{

    [TestMethod]
    public async Task TestGetBooks()
    {
        var response = await GetSDK()
            .GetBooks()
            .GetResponse();
        var books = response.Docs;
        Assert.AreEqual(3, books.Count());
    }
    
    [TestMethod]
    public async Task TestGetBook()
    {
        var response = await GetSDK()
            .GetBook("5cf5805fb53e011a64671582")
            .GetResponse();
        var book = response.Docs.First();
        Assert.AreEqual("The Fellowship Of The Ring", book.Name);
    }    
    
    [TestMethod]
    public async Task TestGetBookChapters()
    {
        var response = await GetSDK()
            .GetChaptersByBook("5cf5805fb53e011a64671582")
            .GetResponse();
        var chapters = response.Docs;
        Assert.AreEqual(22, chapters.Count());
    }

    [TestMethod]
    public async Task TestGetMovies()
    {
        var response = await GetSDK()
            .GetMovies()
            .GetResponse();
        var movies = response.Docs;
        Assert.AreEqual(8, movies.Count());
    } 
    
    [TestMethod]
    public async Task TestGetMovie()
    {
        var response = await GetSDK()
            .GetMovie("5cd95395de30eff6ebccde5c")
            .GetResponse();
        var movie = response.Docs.First();
        Assert.AreEqual("The Fellowship of the Ring", movie.Name);
    }  

    [TestMethod]
    public async Task TestGetMovieQuotes()
    {
        var response = await GetSDK()
            .GetQuotesByMovie("5cd95395de30eff6ebccde5c")
            .GetResponse();
        var quotes = response.Docs;
        Assert.AreEqual(507, quotes.Count());
    }  
    
    [TestMethod]
    public async Task TestGetCharacters()
    {
        var response = await GetSDK()
            .GetCharacters()
            .GetResponse();
        var characters = response.Docs;
        Assert.AreEqual(933, characters.Count());
    }  

    [TestMethod]
    public async Task TestGetCharacter()
    {
        var response = await GetSDK()
            .GetCharacter("5cd99d4bde30eff6ebccfe9e")
            .GetResponse();
        var character = response.Docs.First();
        Assert.AreEqual("Gollum", character.Name);
    }  
    
    [TestMethod]
    public async Task TestGetCharacterQuotes()
    {
        var response = await GetSDK()
            .GetQuotesByCharacter("5cd99d4bde30eff6ebccfe9e")
            .GetResponse();
        var quotes = response.Docs;
        Assert.AreEqual(183, quotes.Count());
    }  
    
    [TestMethod]
    public async Task TestGetQuotes()
    {
        var response = await GetSDK()
            .GetQuotes()
            .GetResponse();
        var quotes = response.Docs;
        Assert.AreEqual(1000, quotes.Count());
    }  
    
    [TestMethod]
    public async Task TestGetQuote()
    {
        var response = await GetSDK()
            .GetQuote("5cd96e05de30eff6ebccebd0")
            .GetResponse();
        var quote = response.Docs.First();
        Assert.AreEqual("Get the wounded on horses.The wolves of lsengard will return.Leave the dead.", quote.Dialog);
    }  
    
    [TestMethod]
    public async Task TestGetChapters()
    {
        var response = await GetSDK()
            .GetChapters()
            .GetResponse();
        var chapters = response.Docs;
        Assert.AreEqual(62, chapters.Count());
    }  
    
    [TestMethod]
    public async Task TestGetChapter()
    {   
        var response = await GetSDK()
            .GetChapter("6091b6d6d58360f988133bc8")
            .GetResponse();
        var chapter = response.Docs.First();
        Assert.AreEqual("The Grey Havens", chapter.ChapterName);
    }  

    [TestMethod]
    public async Task TestGetQuotesWithPagination()
    {
        var response = await GetSDK()
            .GetQuotes()
            .AddPage(3)
            .AddLimit(10)
            .GetResponse();
        var quotes = response.Docs;
        Assert.AreEqual(10, quotes.Count());
        Assert.AreEqual(10, response.Limit);
        Assert.AreEqual(3, response.Page);
    }  

    private SDK GetSDK() 
    {
        var key = Environment.GetEnvironmentVariable("API_KEY");
        if (key == null) {
            throw new Exception("You must set the env var API_KEY for the tests");
        }
        return new SDK(key);
    }

}