using System;

namespace Util
{
    //Util multi purpose to generate randon number
    public class RandomUtils
    {
        
        protected static Random random = new Random(DateTime.Now.Millisecond);
        

        //Generate number in range inclusive
        public static int GenRandom(int min, int max)
        {
            return random.Next(min, max+1);
        }
    }
}
