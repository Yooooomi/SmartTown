using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedRefill : INeed<Objects.Shop>
{
    private Objects.IFood container;

    public void SetContainer(Objects.IFood cont)
    {
        container = cont;
    }
    public override GameTime GetExecutionTime()
    {
        return new GameTime(1, 0);
    }

    public override float GetPriority()
    {
        return Mathf.Clamp(1 - container.meals / container.maxMeals, 0.0f, 1.0f);
    }

    public override void OnNeedSatisfy()
    {
        container.Refill();
    }

    public override string GetAction()
    {
        return "Refilling " + container.name;
    }

    public override List<MemberSteps> GetSteps()
    {
        return new List<MemberSteps>() { MemberSteps.GO_TARGET, MemberSteps.ACT, MemberSteps.GO_HOME };
    }
}
