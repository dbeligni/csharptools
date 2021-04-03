using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            // int candidate = 0b1111111;
            // int maxGap = GetBinaryGap(candidate);
            // Console.WriteLine("MaxGap: " + maxGap);

            // var jumps = FrogJmp(10, 85, 30);
            // Console.WriteLine("Jumps " + jumps);
        }

        /// https://app.codility.com/programmers/lessons/1-iterations/binary_gap/
        private static int GetBinaryGap(int candidate)
        {
            var stringBin = Convert.ToString(candidate, 2);
            var tokens = new List<string>(stringBin.Split('1'));
            var maxGap = tokens.Select(t => t.Length).Max();
            return maxGap;
        }

        private static int FrogJmp(int x, int y, int d){
            if(x >= y) return 0;
            var jumps = (y - x)/d;
            if((y - x) % d > 0) jumps++;
            return jumps;
        }
    }
}
