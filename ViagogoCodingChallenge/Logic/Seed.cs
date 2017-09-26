using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViagogoCodingChallenge.Models;

namespace ViagogoCodingChallenge.Logic
{
    /// <summary>
    /// Data generation.
    /// Generates events, event info and also validation of checking that there is no more than one event in any one point in the world.
    /// </summary>
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

        /// <summary>
        /// Logic to check coordinate duplication.
        /// </summary>
        /// <param name="evt"> Event the coords are being generated for. </param>
        /// <param name="events"> A list of all current events in the world. </param>
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
