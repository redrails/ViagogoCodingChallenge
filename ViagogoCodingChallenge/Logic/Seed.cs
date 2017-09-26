using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViagogoCodingChallenge.Models;

namespace ViagogoCodingChallenge.Logic
{
    class Seed
    {
        public List<Event> Generate()
        {
            Random r = new Random();
            int numberOfEvents = r.Next(1, 10);
            int eventId = 0;
            List<Event> events = new List<Event>();
            for (int i = 0; i < numberOfEvents; i++)
            {
                var evt = new Event
                {
                    Id = eventId,
                    TicketQuantity = r.Next(1, 1000),
                    TicketPrice = Math.Round(r.NextDouble() * r.Next(0, 100), 2)
                };
                GenerateCoord(evt, events);
                events.Add(evt);
                eventId++;
            }
            return events;
        }

        private void GenerateCoord(Event evt, List<Event> events)
        {
            Random r = new Random();
            int PosX = r.Next(0, 10);
            int PosY = r.Next(0, 10);
            if (events.Any(e => e.PosX == PosX && e.PosY == PosY))
            {
                GenerateCoord(evt, events);
            }
            else
            {
                evt.PosX = PosX;
                evt.PosY = PosY;
            }
        }

    }
}
