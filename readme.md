
# Lord of the Rings SDK

## How to use this SDK

### Basic usage 

Here are some examples to show how to fetch, filter, paginate and sort data.

In order to use the SDK you first need to create a SDK object with the API token.
The token is optional, since there are some api calls do not require the token.

```C#
    var sdk = new SDK(); // Without token
    var sdk = new SDK("{Your personal token}"); // By default, it uses the 'https://the-one-api.dev/v2' url.
    var sdk = new SDK("{Custom api url}", "{Your personal token}");
```

This a basic example for fetching all the books in the database.

```C#
    var response = await sdk
        .GetBooks()
        .GetResponse();
    Console.WriteLine("There are {} books", response.Docs.Count());
```

The response always contains the list of entities fetched and the pagination info.

### Sorting

Gets all the characters by ascending or descending alphabetical name order:

```C#
    var response = await sdk
        .GetCharacters()
        .SortByAsc("name")
        .GetResponse();
```

```C#
    var response = await sdk
        .GetCharacters()
        .SortByDesc("name")
        .GetResponse();
```

### Filtering

Get Frodo:

```C#
    var response = await sdk
        .GetCharacters()
        .MatchBy("name", "Frodo")
        .GetResponse();
```

Get all the characters except Gollum and Sauron:

```C#
    var response = await sdk
        .GetCharacters()
        .Exclude("name", "Gollum", "Sauron")
        .GetResponse();
```

Get all characters with a name that ends with 'ain':

```C#
    var response = await sdk
        .GetCharacters()
        .MatchRegex("name", ".*ain")
        .GetResponse();
```

Movies with a runtime lower than 2 hours:

```C#
    var response = await sdk
        .GetMovies()
        .LessThan("runtimeInMinues", "120")
        .GetResponse();
```

### Pagination

```C#
    var response = await sdk
        .GetQuotes()
        .AddLimit(30) // 30 quotes per page (max by default to 1000)
        .AddPage(7)   // Sets the page  
        .AddOffset(3) // Moves the page by an offset of 3
        .GetResponse();
    Console.WriteLine("There are {} quotes", response.Docs.Count());
```

## Install

Use this command to install the NuGet package in your project:
```
dotnet add package LordOfTheRingsSDK-miguel-garnacho-velez
```

## Build

This projects uses the .Net Core 6 SDK. 
After downloading and installing it, you should be able to build the SDK using this command:
```
dotnet build
```

## Test

In order for the tests to be run, the environment variable 'API_KEY' must be set with your personal API key.

Run this command:
```
dotnet test LordOfTheRingsSDKTest/LordOfTheRingsSDKTest.csproj -e API_KEY={your API key}
```
