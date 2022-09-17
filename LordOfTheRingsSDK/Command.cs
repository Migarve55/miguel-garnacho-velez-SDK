
using System;
using System.Collections;
using System.Threading.Tasks;

namespace LordOfTheRingsSDK;

public interface Command<T> {

    public Task<ApiResponse<T>> GetResponse();

    // Pagination

    public Command<T> AddLimit(int limit);

    public Command<T> AddPage(int page);

    public Command<T> AddOffset(int offset);

    // Sorting

    public Command<T> SortByAsc(string field);

    public Command<T> SortByDesc(string field);

    // Filtering

    public Command<T> MatchBy(string field, string value);

    public Command<T> DoNotMatchBy(string field, string value);

    public Command<T> Include(string field, params string[] value);

    public Command<T> Exclude(string field, params string[] value);

    public Command<T> Exists(string field);

    public Command<T> DoesNotExist(string field);

    public Command<T> MatchRegex(string field, string value);
    
    public Command<T> DoesNotMatchRegex(string field, string value);

    public Command<T> LessThan(string field, string value);

    public Command<T> GreaterThan(string field, string value);

    public Command<T> EqualTo(string field, string value);

}