# Viagogo Coding Challenge - Ihtasham

## Requirements
1. Windows or Mac (or anything that has a C# compiler)
2. I would recommend using Visual Studio

Note: No additional libraries or packages are required. This application is a console application solely relying on .NET Core 2.0.

## How to run
Simply load the solution in Visual Studio and run it (F5).

## Inputs
With the included guideline sent to me for this challenge, I also created an option for "show".
By typing "show" when being asked for an input you'll be presented with a list of all events that have been generated and their ticket prices.

In addition to this the normal inputs like: 4,2 will be validated and distance measuring would take place.

## Assumptions
1. There are a quantity of tickets available for each event.
2. There are no lower limits for pricing of tickets.
3. Maximum number of events in this world can be up to 10, however this is variable and randomly generated within the range 1 and 10.
4. There is never less than one event in the world i.e. number of events are a non-zero value.

## Working with a larger world
If I was to expand this world and the number of events, I would face a lot of optimisation issues. This is because I am linearly searching through all the events, sorting them and then listing them.
With a bigger world, this would take a much longer time to process as there would be more events. 