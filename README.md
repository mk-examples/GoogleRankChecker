# Google Rank Checker

A cli tool for finding out where a given domain ranks for a particular search query.

Usage:
```
dotnet run --project GoogleRankChecker "flying fish"  en.wikipedia.org
```
*Results:*
```
6
```

The "en.wikipedia.org" is ranked 6th for the term `flying fish`

:exclamation: **WARNING Performing more then 10 requets per hour from a sinlge IP address will result in temporary ban of that IP address from google** :exclamation:

## Getting Started

Make sure you have dotnet core 2 installed and simply run 
```
 dotnet restore
 dotnet run --project GoogleRankChecker "flying fish"  en.wikipedia.org
```


### Prerequisites

You'll need the dotnet core 2.1 runtime installed

## Running the tests

```
dotnet test GoogleRankChecker.Test
```

The end to end tests use some sample search results, found in the `samples` directory inside the test project.


### And coding style tests

Standard c# coding styles, no rules are enforced currently..

## Deployment

Doesn't deploy yet.

## Built With

* [dotnet core](https://www.microsoft.com/net) 

## Contributing

Feel free to submit a pull request. 


