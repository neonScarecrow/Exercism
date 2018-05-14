using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var visited = new HashSet<int>();
        int sum = 0; 
        foreach (var i in multiples)
        {
            int addMe = i; 
            while(addMe < max)
            {
               if(false == visited.Contains(addMe))sum += addMe;
               visited.Add(addMe); 
               addMe += i;     
            }    
        }
    
        return sum;
    }
}