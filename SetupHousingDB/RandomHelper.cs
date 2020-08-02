using System;
using System.Collections.Generic;
using System.Text;

namespace SetupHousingDB
{
    public static class RandomHelper
    {
        private static Random _rand = new Random();
        public static bool GenerateAOneInXChance(int x)
        {
            var i = _rand.Next(1, x);
            return i % x == 0;
        }
    }
}
