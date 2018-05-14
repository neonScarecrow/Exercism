using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber,(double)r.numerator / (double)r.denominator);
    }
}

public struct RationalNumber
{
    public int numerator {get;}
    public int denominator {get;} 
    
    public RationalNumber(int numerator, int denominator)
    {
        this.numerator = numerator; 
        this.denominator = numerator != 0 ? denominator : 1;

        if(this.denominator < 0)
        {
            this.numerator *= -1; 
            this.denominator *= -1; 
        }
    }

    private int GetCommonDenominator(int otherDenominator)
    {
        int aa = denominator; 
        int bb = otherDenominator; 
        while(aa != bb)
        {
            if(aa < bb)
            {
                aa += denominator; 
            }else
            {
                bb += otherDenominator;
            }
        }
        return aa; 
    }

    public RationalNumber Add(RationalNumber r)
    {
        int cd = GetCommonDenominator(r.denominator);
        int a = this.numerator * (cd / denominator);
        int b = r.numerator * (cd / r.denominator);
        return new RationalNumber(a + b, cd).Reduce();
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return r1.Add(r2);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        int cd = GetCommonDenominator(r.denominator);
        int a = this.numerator * (cd / denominator);
        int b = r.numerator * (cd / r.denominator);
        return new RationalNumber(a - b, cd).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1.Sub(r2);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        int n = this.numerator * r.numerator;
        int d = this.denominator * r.denominator;
        return new RationalNumber(n,d).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return r1.Mul(r2);
    }

    public RationalNumber Div(RationalNumber r)
    {
        int rn = r.numerator; 
        int rd = r.denominator;
        if(rn < 0)
        {
            rn *= -1; 
            rd *= -1; 
        }

        int n = this.numerator * rd;
        int d = this.denominator * rn;
        return new RationalNumber(n,d).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1.Div(r2);
    }

    public RationalNumber Abs()
    {
        return numerator < 0 ? new RationalNumber(numerator * -1, denominator) : this; 
    }

    public RationalNumber Reduce()
    {
        int n = Math.Abs(numerator); 
        int d = Math.Abs(denominator); 
        while(true)
        {
            var nFactors = FindPrimeFactors(n);
            var dFactors = FindPrimeFactors(d);
            var firstSharedFactor = nFactors.Intersect(dFactors).FirstOrDefault();
            if(firstSharedFactor == 0) break;
            n /= firstSharedFactor; 
            d /= firstSharedFactor; 
        }
        if(numerator < 0) n *= -1; 
        if(denominator < 0) d *= -1; 
        return new RationalNumber(n,d);
    }

    public IEnumerable<int> FindPrimeFactors(int num)
    {
        if(num % 2 == 0) yield return 2; 
        while(num % 2 == 0) num /= 2; 

        int factor = 3; 
        while(factor * factor <= num)
        {
            if(num % factor == 0)
            {
                yield return factor;
                num /= factor; 
            }else
            {
                factor += 2; 
            }
        }
        if(num > 1) yield return num; 
    }

    public RationalNumber Exprational(int power)
    {
        if(power == 0) return new RationalNumber(1,1);
        return new RationalNumber(numerator, (int)Math.Pow(denominator,power));
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}