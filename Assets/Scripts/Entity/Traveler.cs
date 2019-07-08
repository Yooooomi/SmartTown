using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TravelerFeedback : MonoBehaviour
{
    public abstract void OnTargetReached();
}
public class Traveler : MonoBehaviour
{
    public float moveSpeed;
    public float rangeToInteract;
    private TravelerFeedback feedback;
    private Transform currentTarget;

    public void SetTarget(Objects.IObject obj)
    {
        Debug.Log("Travelling to " + obj.name);
        currentTarget = obj.transform;
    }

    public void SetTarget(Transform target)
    {
        this.currentTarget = target;
    }

    public void SetReachedTarget(TravelerFeedback feedback)
    {
        this.feedback = feedback;
    }

    private void Update()
    {
        if (!currentTarget) return;
        transform.position += moveSpeed * Time.deltaTime * (currentTarget.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, currentTarget.transform.position) < rangeToInteract)
        {
            Debug.Log("Traveled to " + currentTarget.name);
            currentTarget = null;
            if (feedback)
                feedback.OnTargetReached();
        }
    }
}
