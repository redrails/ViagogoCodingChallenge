using System;
using System.Collections.Generic;
using System.Text;
using ViagogoCodingChallenge.Interfaces;

namespace ViagogoCodingChallenge.Implementations
{
    class MeasureDistance : IMeasureDistance
    {
        /// <summary>
        /// Simply measuring the distance between 2 points using Manhattan distance.
        /// </summary>
        /// <param name="x1">X coord of point 1</param>
        /// <param name="y1">Y coord of point 1</param>
        /// <param name="x2">X coord of point 2</param>
        /// <param name="y2">Y coord of point 2</param>
        /// <returns></returns>
        public int CalcDist(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
    }
}
