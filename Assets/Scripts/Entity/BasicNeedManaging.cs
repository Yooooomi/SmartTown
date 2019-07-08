using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Objects;

public class BasicNeedManaging : NeedManager
{
    private Entity entity;
    private UniversalQueue queuer;

    private void Start()
    {
        queuer = GetComponent<UniversalQueue>();
        entity = GetComponent<Entity>();
    }

    private void Update()
    {
        if (queuer.GetQueueLength() >= 2) return;
        List<INeed> needs = entity.GetNeeds();

        foreach (Objects.IObject obj in entity.GetOwned())
        {
            needs.AddRange(obj.GetComponents<INeed>());
        }
        INeed first = needs.OrderByDescending(e => e.GetPriority()).FirstOrDefault();

        queuer.AddElementToQueue(new UniversalQueueMember(first));
    }
}
