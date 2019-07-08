using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : INeed<Objects.IObject>
{
    private GameTime JobStartTime = new GameTime(0, 0, 10);
    public override string GetAction()
    {
        return "Working";
    }

    public override GameTime GetExecutionTime()
    {
        return new GameTime(0, 0, 8);
    }

    public override float GetPriority()
    {
        int diff = JobStartTime.SecondsSinceMidnight() - GameInfos.gameTime.SecondsSinceMidnight();

        // If it's more than 2 hours after the beginning then dont do it
        if (diff < -2 * 3600) return 0;
        // If we're late then it's top priority
        if (diff < 0 && diff > -7200) return 1;
        // It's too early
        if (diff > 7200) return 0;
        // If we're in time priority is increasing
        if (diff > 0 && diff <= 7200) return diff / 7200;
        return 0;
    }

    public override List<MemberSteps> GetSteps()
    {
        return new List<MemberSteps>() { MemberSteps.GO_TARGET, MemberSteps.ACT };
    }

    public override void OnNeedSatisfy()
    {
        // We ended our work day
    }
}
