using System;
using System.Collections.Generic;

public class NucleotideCount
{
    private readonly IDictionary<char,int> _dict = new Dictionary<char,int>();
    public NucleotideCount(string sequence)
    {
            _dict.Add('A',0);
            _dict.Add('C',0);
            _dict.Add('G',0);
            _dict.Add('T',0);            
            foreach (var c in sequence)
            {
                if(false == _dict.ContainsKey(c)) 
                    throw new InvalidNucleotideException();
                _dict[c]++;
            }
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get
        {
            return _dict;
        }
    }
}

public class InvalidNucleotideException : Exception { }
