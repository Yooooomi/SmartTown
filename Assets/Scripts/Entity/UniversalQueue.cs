using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NeedStatistics
{
    public int timesDone;
    public float totalTime;
}

public enum BusyType
{
    TRAVELLING,
    ACTING,
}

public class UniversalQueue : TravelerFeedback
{
    public List<UniversalQueueMember> queue { get; private set; } = new List<UniversalQueueMember>();
    public BusyType actualState { get; private set; }
    private Traveler traveler;
    private GameObject currentNeedSatisfier = null;
    private Entity entity;
    private Objects.IObject objToInteract;

    private float currentNeedStartTime;

    private Dictionary<System.Type, NeedStatistics> statistics;

    private int currentStep;

    private void Start()
    {
        traveler = GetComponent<Traveler>();
        entity = GetComponent<Entity>();
        traveler.SetReachedTarget(this);
    }

    public int GetQueueLength()
    {
        return queue.Count;
    }

    public void AddElementToQueue(UniversalQueueMember newItem)
    {
        queue.Add(newItem);
        if (queue.Count == 1)
            processCurrent();
    }

    private IEnumerator delayProcessCurrent()
    {
        yield return new WaitForSeconds(queue[0].need.GetExecutionTime().toSeconds());
        queue[0].need.OnNeedSatisfy();
        processCurrent();
    }

    private void processAct()
    {
        if (!objToInteract)
        {
            Debug.Log(queue[0].need.GetAction());
            Debug.Log("No object to interact with, missing one GO_TARGET in your steps");
        }
        if (objToInteract.canBeUsed())
        {
            actualState = BusyType.ACTING;
            ++currentStep;
            objToInteract.onUse();
            StartCoroutine(delayProcessCurrent());
        }
    }

    private void processGoHere()
    {
        actualState = BusyType.TRAVELLING;
        traveler.SetTarget(queue[0].need.transform);
    }

    private void processGoHome()
    {
        actualState = BusyType.TRAVELLING;
        traveler.SetTarget(entity.house.transform);
    }

    private void processGoTarget()
    {
        INeed currentNeed = queue[0].need;
        var gos = GameObject.FindObjectsOfType(currentNeed.satisfyType) as Objects.IObject[];

        Debug.Log("Found " + gos.Length + " object that can satisfy need");

        var target = gos
            .Where(e => e.canBeUsed())
            .OrderBy(e => Vector3.Distance(e.transform.position, transform.position))
            .FirstOrDefault();
        if (!target)
        {
            Debug.Log("Could not find target to satisfy " + currentNeed.GetAction());
            return;
        }
        objToInteract = target;
        traveler.SetTarget(target);
    }

    private void finishedOne()
    {
        queue.RemoveAt(0);
    }

    public void processCurrent()
    {
        if (currentStep == queue[0].need.GetSteps().Count)
        {
            finishedOne();
            objToInteract = null;
            currentStep = 0;
            if (queue.Count != 0 && !queue[0].need.GetSteps().Any(e => e == MemberSteps.ACT))
                Debug.LogError("No ACT on current need: " + queue[0].need.GetAction() + ", useless action ?");
            Debug.Log("New current target: " + queue[0].need.GetAction());
        }
        if (queue.Count == 0) return;

        List<MemberSteps> steps = queue[0].need.GetSteps();

        switch (steps[currentStep])
        {
            case MemberSteps.ACT:
            processAct();
            break;
            case MemberSteps.GO_HERE:
            processGoHere();
            break;
            case MemberSteps.GO_HOME:
            processGoHome();
            break;
            case MemberSteps.GO_TARGET:
            processGoTarget();
            break;
        }
    }

    public override void OnTargetReached()
    {
        ++currentStep;
        processCurrent();
    }
}
