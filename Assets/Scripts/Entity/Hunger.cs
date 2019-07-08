using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : INeed<Objects.IFood>
{
    private float hunger;
    private float hungerMult = 1.0f;

    public override float GetPriority()
    {
        return Mathf.Clamp(hunger / 100.0f, 0, 1.0f);
    }

    public override void OnNeedSatisfy()
    {
        hunger = 0.0f;
    }

    public override GameTime GetExecutionTime()
    {
        return new GameTime(5);
    }

    private void Update()
    {
        hunger += Time.deltaTime * hungerMult;
    }

    public override string GetAction()
    {
        return "Hungry";
    }

    public override List<MemberSteps> GetSteps()
    {
        return new List<MemberSteps>() { MemberSteps.GO_TARGET, MemberSteps.ACT };
    }
}
