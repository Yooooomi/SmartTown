using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MemberSteps
{
    ACT,
    GO_HOME,
    GO_HERE,
    GO_TARGET,
}

public class UniversalQueueMember
{
    public INeed need;

    public UniversalQueueMember(INeed need)
    {
        this.need = need;
    }

}
