using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class INeed : MonoBehaviour
{
    public abstract string GetAction();
    public abstract void OnNeedSatisfy();
    public abstract float GetPriority();
    public abstract GameTime GetExecutionTime();
    public abstract List<MemberSteps> GetSteps();
    public System.Type satisfyType;
}
public abstract class INeed<T> : INeed where T : Objects.IObject
{
    protected Entity entity;

    protected void Awake()
    {
        satisfyType = typeof(T);
        entity = GetComponent<Entity>();
    }

}
