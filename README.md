# Google Rank Checker

A cli tool for finding out where a given domain ranks for a particular search query.

Usage:

```bash
dotnet run --project GoogleRankChecker "flying fish"  en.wikipedia.org
```

_Results:_

```bash
6
```

The "en.wikipedia.org" is ranked 6th for the term `flying fish`

:exclamation: **WARNING Performing more then 10 requests per hour from a single IP address will result in temporary ban of that IP address from google** :exclamation:

## Getting Started

Make sure you have dotnet core 2 installed and simply run

```bash
 dotnet restore
 dotnet run --project GoogleRankChecker "flying fish"  en.wikipedia.org
```

### Prerequisites

You'll need the dotnet core 2.1 runtime installed

## Running the tests

```bash
dotnet test GoogleRankChecker.Test
```

The end to end tests use some sample search results, found in the `samples` directory inside the test project.

### And coding style tests

Follow defaults provided by: [C# FixFormat](https://marketplace.visualstudio.com/items?itemName=Leopotam.csharpfixformat)

## Deployment

Doesn't deploy yet.

## Built With

- [dotnet core](https://www.microsoft.com/net)

## Contributing

Feel free to submit a pull request.
