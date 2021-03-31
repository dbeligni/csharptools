using System;
using System.Collections.Generic;

namespace MiscCodeSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello BoatLoadOptimizer!");
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
            List<int> descOrderWeights = GetWeightInDescendingOrder();
            int[] boatWeight = DistributeLoadOnAvailableBoats(descOrderWeights);

            return boatWeight;

        }

        private int[] DistributeLoadOnAvailableBoats(List<int> descSortedWeights)
        {
            var boatWeight = new int[_availableBoats];
            DistributeWeightOnLessLoadedBoats(descSortedWeights, boatWeight);
            return boatWeight;
        }

        private static void DistributeWeightOnLessLoadedBoats(List<int> descSortedWeights, int[] boatWeight)
        {
            foreach (var weight in descSortedWeights)
            {
                int lessLoadedBoatIdex = GetMinimumWeightIndex(boatWeight);
                boatWeight[lessLoadedBoatIdex] += weight;
            }
        }

        private List<int> GetWeightInDescendingOrder()
        {
            var peopleWeight = new List<int>(_peopleWeights);
            peopleWeight.Sort();
            peopleWeight.Reverse();
            return peopleWeight;
        }

        public static int GetMinimumWeightIndex(int[] list)
        {
            var minValueIndex = 0;
            for(int i =0; i < list.Length; i++)
            {
                if(list[minValueIndex] > list[i])
                {
                    minValueIndex = i;
                }
            }
            return minValueIndex;
{}
        }
    }
}
