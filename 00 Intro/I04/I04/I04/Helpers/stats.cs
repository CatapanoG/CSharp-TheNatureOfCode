using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I04.Helpers
{
    class Stats
    {
        static Random random = new Random();
        static int uniformRange = 100;
        static int randomLength = 15;

        public static void init()
        {
        }

        public static float stdNormal()
        {
            float value = 0.0f;
            
            for (int i = 0; i < randomLength; i++)
            {
                value += random.Next(0, uniformRange);
            }

            value = (value - uniformRange * randomLength * 0.5f) / (uniformRange * randomLength * 0.5f);

            return value;
        }
    }
}
