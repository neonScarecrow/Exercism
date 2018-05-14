using System;
using System.Collections.Generic;
using System.Linq;
public class School
{
    private readonly Dictionary<int,List<string>> dict = new Dictionary<int,List<string>>();

    public void Add(string student, int grade)
    {
        if(false == dict.ContainsKey(grade)) dict.Add(grade,new List<string>());
        dict[grade].Add(student);
    }

    public IEnumerable<string> Roster()
    {
       foreach(var grade in dict.Keys.OrderBy(_ => _))
       {
           foreach(var student in dict[grade].OrderBy(_ => _))
           {
               yield return student;
           }
       }
    }

    public IEnumerable<string> Grade(int grade)
    {
        if(dict.ContainsKey(grade))return dict[grade].OrderBy(_ => _);
        return Enumerable.Empty<string>();
    }
}