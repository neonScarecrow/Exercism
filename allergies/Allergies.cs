using System;
using System.Collections.Generic;

public class Allergies
{
    private readonly List<string> allergies = new List<string>();

    public Allergies(int mask)
    {
        if (SatisfiesFlag(mask, 1 << 0)) allergies.Add("eggs");
        if (SatisfiesFlag(mask, 1 << 1)) allergies.Add("peanuts");
        if (SatisfiesFlag(mask, 1 << 2)) allergies.Add("shellfish");
        if (SatisfiesFlag(mask, 1 << 3)) allergies.Add("strawberries");
        if (SatisfiesFlag(mask, 1 << 4)) allergies.Add("tomatoes");
        if (SatisfiesFlag(mask, 1 << 5)) allergies.Add("chocolate");
        if (SatisfiesFlag(mask, 1 << 6)) allergies.Add("pollen");
        if (SatisfiesFlag(mask, 1 << 7)) allergies.Add("cats");
    }

    private static bool SatisfiesFlag(int mask, int val)
    {
        return (mask & val) != 0; 
    }

    public bool IsAllergicTo(string allergy)
    {
        return allergies.Contains(allergy);
    }

    public IList<string> List()
    {
        return allergies;
    }
}