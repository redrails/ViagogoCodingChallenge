using System;
using System.Collections.Generic;
using System.Text;
using ViagogoCodingChallenge.Interfaces;

namespace ViagogoCodingChallenge.Implementations
{
    class MeasureDistance : IMeasureDistance
    {
        public int CalcDist(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
    }
}
