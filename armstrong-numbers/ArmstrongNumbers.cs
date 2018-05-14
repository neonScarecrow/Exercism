using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
       if(number < 100) return number < 10; 
    
        int places = 3; 
        int factorToBeat = 1000; 
        while(number > factorToBeat)
        {
            places++;
            factorToBeat *= 10;
        }
        factorToBeat/= 10;
        int sum = 0;

        while(true)
        {
            var digit = GetNDigit(number,factorToBeat);
            sum += (int)Math.Pow(digit,places);
            if(factorToBeat == 1) break;
            factorToBeat /= 10;
        }
        return sum == number; 
    }

    private static int GetNDigit(int x, int place)
    {
        return (x % (place * 10) - x % place) / place;
    }
}