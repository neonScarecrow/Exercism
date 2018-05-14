using System;

public struct Clock : IEquatable<Clock>
{
    private TimeSpan ts;  
    public Clock(int hours, int minutes)
    {
        this.ts = new TimeSpan(hours,minutes,0);
    }

    public Clock(TimeSpan ts)
    {
       this.ts = ts;
    }
    public int Hours
    {
        get
        {
            int hour = ts.Hours < 0 ? 24 + ts.Hours : ts.Hours;
            if(ts.Minutes < 0) hour--;

            hour = hour < 0 ? 24 + hour : hour ;
            hour = hour % 24; 
            return hour;  
        }
    }

    public int Minutes
    {
        get
        {
            return ts.Minutes < 0 ? 60 + ts.Minutes : ts.Minutes; 
        }
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(ts.Add(new TimeSpan(0,minutesToAdd,0)));
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        return string.Format("{0}:{1}",Hours.ToString("00"),Minutes.ToString("00"));
    }

    public bool Equals(Clock other)
    {
        return ToString().Equals(other.ToString());
    }
}