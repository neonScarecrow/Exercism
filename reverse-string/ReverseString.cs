using System;
using System.Linq;
public static class ReverseString
{
    public static string Reverse(string input)
    {
        if(null == input) return null;
        if(input.Length < 2) return input; 
        string result = string.Empty;
        foreach (char c in input.Reverse()) result += c; 
        return result;
    }
}