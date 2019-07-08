using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public GameTime(int seconds, int minutes)
    {
        this.seconds = seconds;
        this.minutes = minutes;
    }

    public GameTime(int seconds, int minutes, int hours)
    {
        this.seconds = seconds;
        this.minutes = minutes;
        this.hours = hours;
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
