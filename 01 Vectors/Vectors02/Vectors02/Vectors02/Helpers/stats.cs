using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vectors02.Helpers
{
    class Stats
    {
        static Random random = new Random();
        static int uniformRange = 100;
        static int randomLength = 15;

        public static float stdNormal() // support [-0.5,0.5]
        {
            float value = 0.0f;
            
            for (int i = 0; i < randomLength; i++)
            {
                value += random.Next(0, uniformRange);
            }

            value = (value - uniformRange * randomLength * 0.5f) / (uniformRange * randomLength * 0.5f);

            return value;
        }

        public static int discreteUniform()
        {
            return random.Next(0, 100);
        }

        // support [0,100]
        // P[X=x]=x;
        public static int custom1() 
        {
            int candidate;
            int candProb;
            int r2;

            while (true)
            { 
                candidate = random.Next(0, 100);
                r2 = random.Next(0, 100);
                candProb = candidate;

                if (candProb > r2)
                {
                    return candidate;
                }
            }
        }
        // support [0,100]
        // P[X=x]=x*x;
        // (compute with a support [0,1])
        public static int custom2()
        {
            float candidate;
            float candProb;
            float r2;

            while (true)
            {
                candidate = random.Next(0, 100) / 100f;
                r2 = random.Next(0, 100) / 100f;
                candProb = candidate;

                if (candProb * candProb > r2)
                {
                    break;
                }
            }

            return (int)(candidate * 100);
        }
    }
}
