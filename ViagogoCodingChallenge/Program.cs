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
        /// <summary>
        /// Main program that takes input repeatedly until the application is closed.
        /// Accepts commands like "show" to list all events generated and "clear" to clear console.
        /// </summary>
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
                    continue;
                }
                if(i == "clear")
                {
                    Console.Clear();
                    continue;
                }

                string[] input = i.Split(',');
                if (input.Length != 2)
                {
                    Console.WriteLine("Please enter a valid input e.g. 4,2");
                }
                else if (int.TryParse(input[0], out int a) && int.TryParse(input[1], out int b))
                {

                    if(a < -10 || a > 10 || b < -10 || b > 10)
                    {
                        Console.WriteLine("Please enter a valid input in the range -10 or 10 on both axis");
                        continue;
                    }

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
                        Console.WriteLine($"Event {String.Format("{0:000}", e.Evt.Id)} - ${e.Evt.TicketPrice}, Distance: {e.Distance}");
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
