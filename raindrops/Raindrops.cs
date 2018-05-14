using System;

public static class Raindrops
{
    public static string Convert(int number)
    {
        string response = "";
        if(number % 3 == 0) response += "Pling";
        if(number % 5 == 0)response +=  "Plang";
        if(number % 7 == 0)response +=  "Plong";
        return response.Length > 0 ? response : number.ToString();
    }
}