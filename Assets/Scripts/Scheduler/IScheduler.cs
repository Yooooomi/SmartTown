using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameInfos
{
    static public GameTime gameTime;
}

public class GameTime
{
    public int seconds;
    public int minutes;
    public int hours;
    public int days;
    public int months;
    public int years;

    public GameTime()
    {

    }
    public GameTime(int seconds)
    {
        this.seconds = seconds;
        this.NormalizeTime();
    }

    public GameTime(int seconds, int minutes)
    {
        this.seconds = seconds;
        this.minutes = minutes;
        this.NormalizeTime();
    }

    public GameTime(int seconds, int minutes, int hours)
    {
        this.seconds = seconds;
        this.minutes = minutes;
        this.hours = hours;
        this.NormalizeTime();
    }

    public int SecondsSinceMidnight()
    {
        return seconds + minutes * 60 + hours * 3600;
    }

    private void NormalizeTime()
    {
        while (seconds < 0)
        {
            seconds += 60;
            minutes--;
        }
        while (seconds > 60)
        {
            seconds -= 60;
            minutes++;
        }
        while (minutes < 0)
        {
            minutes += 60;
            hours--;
        }
        while (minutes > 60)
        {
            minutes -= 60;
            hours++;
        }
        while (hours < 0)
        {
            hours += 24;
            days--;
        }
        while (hours > 60)
        {
            hours -= 24;
            days++;
        }
        while (days < 0)
        {
            days += 30;
            months--;
        }
        while (days > 30)
        {
            days -= 30;
            months++;
        }
        while (months < 0)
        {
            months += 12;
            years--;
        }
        while (months > 12)
        {
            months -= 12;
            years++;
        }
    }

    public float toSeconds()
    {
        return seconds + minutes * 60 + hours * 3600 + days * 3600 * 24 + months * 3600 * 24 * 30 + years * 3600 * 24 * 30 * 12;
    }

    public static GameTime operator-(GameTime a, GameTime b)
    {
        GameTime res = new GameTime();

        res.seconds = a.seconds - b.seconds;
        res.minutes = a.minutes - b.minutes;
        res.hours = a.hours - b.hours;
        res.minutes = a.days - b.days;
        res.minutes = a.months - b.months;
        res.minutes = a.years - b.years;
        res.NormalizeTime();
        return res;
    }

    public static GameTime operator+(GameTime a, GameTime b)
    {
        GameTime res = new GameTime();

        res.seconds = a.seconds + b.seconds;
        res.minutes = a.minutes + b.minutes;
        res.hours = a.hours + b.hours;
        res.minutes = a.days + b.days;
        res.minutes = a.months + b.months;
        res.minutes = a.years + b.years;
        res.NormalizeTime();
        return res;
    }

    public override string ToString()
    {
        bool begun = false;
        string basic = "";

        if (years > 0)
        {
            basic += years + "y ";
            begun = true;
        }
        if (months > 0 || begun)
        {
            basic += months + "m ";
            begun = true;
        }
        if (days > 0 || begun)
        {
            basic += days + "d ";
            begun = true;
        }
        if (hours > 0 || begun)
        {
            basic += hours + "h ";
            begun = true;
        }
        if (minutes > 0 || begun)
        {
            basic += minutes + "m ";
            begun = true;
        }
        if (seconds > 0 || begun)
        {
            basic += seconds + "s";
            begun = true;
        }
        return basic;
    }

    public static GameTime operator*(GameTime a, float b)
    {
        return new GameTime((int) (a.toSeconds() * b));
    }
}

public class IScheduler
{
    public virtual void OnHour(GameTime current)
    {

    }

    public virtual void OnDay(GameTime current)
    {

    }
}
