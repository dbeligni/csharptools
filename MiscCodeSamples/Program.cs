using System;
using System.Collections.Generic;

namespace MiscCodeSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class BoatLoadOptimizer
    {
        private readonly int _availableBoats;
        private readonly int[] _peopleWeights;

        public BoatLoadOptimizer(int availableBoats, int[] peopleWeights)
        {
            this._availableBoats = availableBoats;
            _peopleWeights = peopleWeights;
        }

        public int[] GetBoatWeights()
        {
            var peopleWeight = new List<int>(_peopleWeights);
            peopleWeight.Sort();
            peopleWeight.Reverse();
            var boatWeight = new int[_availableBoats];

            foreach ( var weight in peopleWeight)
            {
                int lessLoadedBoatIdex = GetMinimumWeightIndex(boatWeight);
                boatWeight[lessLoadedBoatIdex] += weight;
            }
            
            return boatWeight;

        }

        public static int GetMinimumWeightIndex(int[] list)
        {
            var minIndex = 0;
            for(int i =0; i < list.Length; i++)
            {
                if(list[minIndex] > list[i])
                {
                    minIndex = i;
                }
            }
            return minIndex;
{}
        }
    }
}
