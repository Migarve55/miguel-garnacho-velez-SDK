
namespace LordOfTheRingsSDK;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

public abstract class BaseCommand<T> : Command<T> {

    private string ApiURL;
    private string ApiKey;

    private List<string> parameters = new List<string>();

    public BaseCommand(string url, string key)
    {
        ApiURL = url;
        ApiKey = key;
    }

    public Command<T> AddLimit(int limit) 
    {
        AddQueryParam("limit=", limit.ToString());
        return this;
    }

    public Command<T> AddPage(int page) 
    {
        AddQueryParam("page=", page.ToString());
        return this;
    }

    public Command<T> AddOffset(int offset) 
    {
        AddQueryParam("offset=", offset.ToString());
        return this;
    }

    public Command<T> SortByAsc(string field) 
    {
        AddQueryParam("sort=", field + ":asc");
        return this;
    }

    public Command<T> SortByDesc(string field) 
    {
        AddQueryParam("sort=", field + ":desc");
        return this;
    }
    
    public Command<T> MatchBy(string field, string value)
    {
        AddQueryParam(field + "=", value);
        return this;
    }

    public Command<T> DoNotMatchBy(string field, string value)
    {
        AddQueryParam(field + "!=", value);
        return this;
    }

    public Command<T> Include(string field, params string[] value)
    {
        AddQueryParam(field + "=", string.Join(',', value));
        return this;
    }

    public Command<T> Exclude(string field, params string[] value)
    {
        AddQueryParam(field + "!=", string.Join(',', value));
        return this;
    }

    public Command<T> Exists(string field)
    {
        AddQueryParam(field);
        return this;
    }

    public Command<T> DoesNotExist(string field)
    {
        AddQueryParam("!" + field);
        return this;
    }

    public Command<T> MatchRegex(string field, string value)
    {
        AddQueryParam(field, $"/{value}/i");
        return this;
    }    
    
    public Command<T> DoesNotMatchRegex(string field, string value)
    {
        AddQueryParam(field + "!", $"/{value}/i");
        return this;
    }

    public Command<T> LessThan(string field, string value)
    {
        AddQueryParam(field + "<", value);
        return this;
    }

    public Command<T> GreaterThan(string field, string value)
    {
        AddQueryParam(field + ">", value);
        return this;
    }

    public Command<T> EqualTo(string field, string value)
    {
        AddQueryParam(field + ">=", value);
        return this;
    }

    public async Task<ApiResponse<T>> GetResponse() 
    {
        using (var httpClient = new HttpClient())
        {
            if (!string.IsNullOrWhiteSpace(ApiKey)) 
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiKey);
            }
            using (var response = await httpClient.GetAsync(GetUri()))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<T>>(json);
            }
        }
    }

    private void AddQueryParam(string param) 
    {
        parameters.Add(param);
    }

    private void AddQueryParam(string name, string value) 
    {
        AddQueryParam(name + HttpUtility.UrlEncode(value));
    }

    private string GetUri() 
    {
        if (parameters.Count <= 0) {
            return ApiURL;
        }
        return ApiURL + "?" + string.Join('&', parameters.ToArray());
    }

}