using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            int candidate = 0b1111111;
            int maxGap = GetBinaryGap(candidate);
            Console.WriteLine("MaxGap: " + maxGap);

            var jumps = FrogJmp(10, 85, 30);
            Console.WriteLine("Jumps " + jumps);

            List<int> mushrooms = new List<int>(){2,3,7,5,1,3,9};
            var max0 = GetMaxMushrooms(0, 6, mushrooms);
            var max1 = GetMaxMushrooms(6, 6, mushrooms);
            var maxMiddle = GetMaxMushrooms(4, 6, mushrooms);
            if(max0 != 30 && max1 != 30 && maxMiddle != 25) throw new ApplicationException(string.Format("Wrong result for Mushroom tests. {0} {1} {2}", max0, max1, maxMiddle));


            int[][] testMatrixForHourGlass = new int[][]
                {
                    new int[]{-9, -9, -9,  1, 1, 1},
                    new int[]{ 0, -9,  0,  4, 3, 2},
                    new int[]{-9, -9, -9,  1, 2, 3},
                    new int[]{ 0,  0,  8,  6, 6, 0},
                    new int[]{ 0,  0,  -2,  0, 0, 0},
                    new int[]{ 0,  0,  1,  2, 4, 0}
                };

            int[][] testMatrixForHourGlassTest7 = new int[][]
                {
                    new int[]{0, -4, -6, 0, -7, -6},
                    new int[]{-1, -2, -6, -8, -3, -1},
                    new int[]{-8, -4, -2, -8, -8, -6},
                    new int[]{ -3, -1, -2, -5, -7, -4},
                    new int[]{-3, -5, -3, -6, -6, -6},
                    new int[]{ -3, -6, 0, -8, -6, -7}
                };
            var sumHg = hourglassSum(testMatrixForHourGlassTest7);
            if(sumHg != -19 ) throw new ApplicationException(string.Format("Wrong result for HourGlss test: {0}", sumHg));

           
            
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

        private static List<int> GetPrefixSumFor(List<int> input){
            var prefix = new List<int>();
            for(int i = 0; i < input.Count; i++){
                if(i == 0) {
                    prefix.Add(input[0]);
                    continue;
                }
                prefix.Add(prefix[i-1] + input[i]);
            }
            return prefix;
        }

        /// https://codility.com/media/train/3-PrefixSums.pdf
        private static int GetMaxMushrooms(int start, int moves, List<int> mushrooms){
            int max = 0;
            List<int> prefix = GetPrefixSumFor(mushrooms);
            int left = 0;
            int right = 0;
            for(int p = 0; p <= moves -1; p ++ ){                
                right = start + p;
                if(right == mushrooms.Count) break;
                left = Math.Min(start,  Math.Max(right + p - moves, 0));
                var sliceSum = GetSlideSum(left, right, prefix);
                max = Math.Max(max, sliceSum);
            }  
            return max;
        }

        private static int GetSlideSum(int left, int right, List<int> prefix){
            if( left == 0) return prefix[right];
            else return prefix[right] - prefix[left -1];

        }

        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            int SIZE = 3;
            int max = int.MinValue;
            if (arr.Count() != SIZE * 2) return 0;
            for (int xOff = 0; xOff <= SIZE; xOff++)
            {
                for (int yOff = 0; yOff <= SIZE; yOff++)
                {
                    var hgSum = GetHourGlassSum(xOff, yOff, arr, SIZE);
                    max = Math.Max(max, hgSum);
                }
            }
            return max;
        }

        private static int GetHourGlassSum(int xOff, int yOff, int[][] arr, int size)
        {
            var sum = 0;
            for (int x = xOff; x < xOff + size; x++)
            {
                for (int y = yOff; y < yOff + size; y++)
                {
                    if (x == xOff + 1 && (y == yOff || y == yOff + 2)) continue;
                    sum += arr[x][y];
                }
            }
            return sum;
        }
    }
}
