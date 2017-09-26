using System;
using System.Collections.Generic;
using ViagogoCodingChallenge.Models;
using ViagogoCodingChallenge.Implementations;
using System.Linq;
using ViagogoCodingChallenge.Logic;

namespace ViagogoCodingChallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Event> events = new Seed().Generate();
            MeasureDistance m = new MeasureDistance();
            while (true)
            {
                List<SortHelper> sorting = new List<SortHelper>();

                Console.Write("> ");
                string i = Console.ReadLine();

                if(i == "show")
                {
                    foreach(var e in events)
                    {
                        Console.WriteLine(e);
                    }
                }

                string[] input = i.Split(",");
                if (input.Length != 2)
                {
                    Console.WriteLine("Please enter a valid input e.g. 4,2");
                }
                else if (int.TryParse(input[0], out int a) && int.TryParse(input[1], out int b))
                {
                    foreach (var e in events)
                    {
                        sorting.Add(new SortHelper {
                            Evt = e,
                            Distance = m.CalcDist(a, b, e.PosX, e.PosY)
                        });
                    }
                    sorting = sorting.OrderBy(x => x.Distance).ToList();
                    foreach(var e in sorting.Take(5))
                    {
                        Console.WriteLine($"Event {e.Evt.Id} - ${e.Evt.TicketPrice}, Distance: {e.Distance}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid input e.g. 4,2");
                }
            }

        }
    }
}
