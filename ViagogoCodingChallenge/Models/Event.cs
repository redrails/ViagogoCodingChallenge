﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViagogoCodingChallenge.Models
{
    /// <summary>
    /// Event Model - Denoting event objects.
    /// </summary>
    class Event
    {
        public int Id { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int TicketQuantity { get; set; }
        public double TicketPrice { get; set; }

        public override string ToString()
        {
            return $"Id: {String.Format("{0:000}", Id)}, Position: ({PosX},{PosY})";
        }
    }
}
