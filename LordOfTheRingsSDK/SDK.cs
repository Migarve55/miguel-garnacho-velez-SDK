using System;
using System.Collections;
namespace LordOfTheRingsSDK;

public class SDK
{

    private readonly static string API_URL = "https://the-one-api.dev/v2";

    private string ApiURL;
    private string ApiKey;

    public SDK() : this(API_URL, string.Empty)
    {
    }

    public SDK(string key) : this(API_URL, key)
    {
    }

    public SDK(string url, string key)
    {
        ApiURL = url;
        ApiKey = key;
    }

    // Books

    public GetBooksCommand GetBooks() 
    {
        return new GetBooksCommand(ApiURL, ApiKey);
    }
    
    public GetBookCommand GetBook(string id) 
    {
        return new GetBookCommand(ApiURL, ApiKey, id);
    }
    
    public GetChaptersByBookCommand GetChaptersByBook(string bookId) 
    {
        return new GetChaptersByBookCommand(ApiURL, ApiKey, bookId);
    }

    // Movie

    public GetMoviesCommand GetMovies() 
    {
        return new GetMoviesCommand(ApiURL, ApiKey);
    }
    public GetMovieCommand GetMovie(string id) 
    {
        return new GetMovieCommand(ApiURL, ApiKey, id);
    }

    public GetQuotesByMovieCommand GetQuotesByMovie(string movieId) 
    {
        return new GetQuotesByMovieCommand(ApiURL, ApiKey, movieId);
    }

    // Characters

    public GetCharactersCommand GetCharacters() 
    {
        return new GetCharactersCommand(ApiURL, ApiKey);
    }

    public GetCharacterCommand GetCharacter(string id) 
    {
        return new GetCharacterCommand(ApiURL, ApiKey, id);
    }

    public GetQuotesByCharacterCommand GetQuotesByCharacter(string characterId) 
    {
        return new GetQuotesByCharacterCommand(ApiURL, ApiKey, characterId);
    }

    // Quotes

    public GetQuotesCommand GetQuotes() 
    {
        return new GetQuotesCommand(ApiURL, ApiKey);
    }

    public GetQuoteCommand GetQuote(string id) 
    {
        return new GetQuoteCommand(ApiURL, ApiKey, id);
    }

    // Chapters

    public GetChaptersCommand GetChapters() 
    {
        return new GetChaptersCommand(ApiURL, ApiKey);
    }

    public GetChapterCommand GetChapter(string id) 
    {
        return new GetChapterCommand(ApiURL, ApiKey, id);
    }

}