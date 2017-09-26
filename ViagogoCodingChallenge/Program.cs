using System;
using System.Collections.Generic;
using ViagogoCodingChallenge.Models;
using ViagogoCodingChallenge.Implementations;
using System.Linq;

namespace ViagogoCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Event> events = Seed();
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
                    foreach(var e in sorting)
                    {
                        Console.WriteLine("Event " + e.Evt.Id + " - " + e.Evt.TicketPrice + ", Distance: " + e.Distance);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid input e.g. 4,2");
                }
            }

        }
        static List<Event> Seed()
        {
            Random r = new Random();
            int numberOfEvents = r.Next(1, 10);
            int eventId = 0;
            List<Event> events = new List<Event>();
            for (int i = 0; i < numberOfEvents; i++)
            {
                events.Add(new Event
                {
                    Id = eventId,
                    PosX = r.Next(0,10),
                    PosY = r.Next(0, 10),
                    TicketPrice = (Double)r.Next(0,100)/1.0
                });
                eventId++;
            }
            return events;
        }

    }
}
