using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{    
    private readonly Dictionary<int,List<Plant>> _garden = new Dictionary<int,List<Plant>>();
    public KindergartenGarden(string diagram)
    {
        int letter = 65;
        int index = 0; 
        foreach(char c in diagram) 
        {
            if(c == '\n')
            {
                letter = 65;
                continue;
            }
            var plant = GetPlant(c);
            if(false == _garden.ContainsKey(letter)) _garden.Add(letter,new List<Plant>());
            _garden[letter].Add(plant);
            index++; 
            if(index == 2)
            {
                index = 0; 
                letter++;
            }
        }
    }

    private Plant GetPlant(char c)
    {
        switch (c)
        {
            case 'V': return Plant.Violets;
            case 'R': return Plant.Radishes; 
            case 'C': return Plant.Clover;  
            case 'G': return Plant.Grass;         
            default: throw new Exception();
        }
    }

    public KindergartenGarden(string diagram, IEnumerable<string> students)
    {
    }

    public IEnumerable<Plant> Plants(string student)
    {
       int i = student[0];
       return _garden[i];
    }
}