using System.Collections.Generic;
using System;
using System.Linq;

class Result
{

    /*
     * Complete the 'getMinCost' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY crew_id
     *  2. INTEGER_ARRAY job_id
     */

    public static long getMinCost(List<int> crew_id, List<int> job_id)
    {
        long totalTravelCost = 0;
        var allocatedCrews = new List<int>();        
        crew_id.Sort();
        foreach( var job in job_id){
            var prev = PrevCrewAvailableFor(job, crew_id, allocatedCrews);
            var next = NextCrewAvailableFor(job, crew_id);
            var prevCost = TravelCost(job, prev );
            var nextCost = TravelCost(job, next );
            if((prevCost < nextCost) && !allocatedCrews.Contains(prev)){
                totalTravelCost += prevCost;
                allocatedCrews.Add(prev);
            }
            else{
                totalTravelCost += nextCost;
                allocatedCrews.Add(next);
            }                                     
        }
        return totalTravelCost;
    }
    
    public static long TravelCost(int job_id, int crew_id){
        if(crew_id < 0) return long.MaxValue;
        return Math.Abs(job_id - crew_id);
    }
    
    public static int NextCrewAvailableFor(int job_id, List<int> sortedCrews){
        
        foreach(var crew in sortedCrews){
            if(crew >= job_id) return crew;
        }
        return -1;        
    }
    
    public static int PrevCrewAvailableFor(int job_id, List<int> sortedCrews, List<int> allocatedCrews){
        var foundCrew = -1;
        var query =  sortedCrews.Where(c => c < job_id && !allocatedCrews.Contains(c));
        if(query.Count() > 0){
            foundCrew = query.Max();
        }
        return foundCrew;         
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // List<int> crew_id = new List<int>(){2,3,6};        
        // List<int> job_id = new List<int>(){1,3,5};
        // var expectedMin = 2;

        List<int> crew_id = new List<int>(){2, 3, 6, 9, 21, 10};        
        List<int> job_id = new List<int>(){1, 3, 7, 11, 12, 23};
        var expectedMin = 8;

        long result = Result.getMinCost(crew_id, job_id);

        if(expectedMin != result) throw new Exception(string.Format("Expected min cost is: {0}, found {1}  ", expectedMin, result ));        
    }
}
