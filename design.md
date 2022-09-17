
# Design

## Explanation

The design of this SDK follows the Builder Design Pattern.
The reason why I chose this approach is because of the way the requests are built.

If an user wants to build a request for the API, there are two kinds of parameters:
    - The universal ones: url, token, pagination, filtering and sorting.
    - The specific ones for the requests: for example the 'bookId' to fetch a book.

So each API Action has some required parameters, or none at all, and all of them share a lot of optional parameters.

So I decided to define all the API Actions in a class that encapsulates the required parameters inside.
The parameters are passed in the constructor to make sure it is created properly. 
Each class implements the Command interface, which defines 'GetResponse', the method that is called when the user wants to build
and launch the request to the API, and all the common methods to setup all the common parameters shared by all the actions.

Example:

```C#

    // Inject all the mandatory parameters
    var getBookCommand = new GetBookCommand("{url}", "{token}", "{bookId}");
    // Add the optional ones
    getBookCommand.MatchBy("name", "{some name}");
    var response = await getBookCommand.GetResponse();
    // Process response...

```

I have created a super class called 'BaseCommmand' to reuse code between all commands and store
the universal parameters.

When GetResponse is called the final HTTP request is build and launched, and the JSON response deserialized.

In order facilitate command instantiation to the SDK class is created, which is just a Factory for all the commands.
Each configuration method return the command instance so it helps build the request in a readable and verbose way.

```C#

    var sdk = new SDK("{token}");
    var response = sdk
        .GetBook("{bookId}")
        .MatchBy("name", "{some name}")
        .GetResponse();

```

## Summary

To sum up, the design can be divided in three parts:

    - The SDK class: acts as the access point to the user and helps instantiate the commmands.
    - The Command interace: defines the configuration and execution behaviour for all commands.
    - The BaseCommand super class: contains the logic and data universal for the configuration of all API actions.
    - The Command implementations: each of them define an API action and helps build the specific request for that action.