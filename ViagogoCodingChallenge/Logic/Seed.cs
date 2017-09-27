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
            int numberOfEvents = r.Next(1, 50);
            int eventId = 0;
            List<Event> events = new List<Event>();
            for (int i = 0; i < numberOfEvents; i++)
            {
                var evt = new Event
                {
                    Id = eventId,
                    TicketQuantity = r.Next(1, 1000),
                    TicketPrice = Math.Round(r.NextDouble() * r.Next(1, 100), 2)
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
            int PosX, PosY;

            while (true)
            {
                PosX = r.Next(-10, 10);
                PosY = r.Next(-10, 10);
                if (CheckCoords(PosX, PosY, events))
                {
                    continue;
                }
                else
                {
                    evt.PosX = PosX;
                    evt.PosY = PosY;
                    break;
                }
            }
        }

        private bool CheckCoords(int x, int y, List<Event> events)
        {
            return events.Any(e => e.PosX == x && e.PosY == y);
        }

    }
}
