using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public House house { get; private set; }
    public float needRefreshRate;
    private float lastRefresh;
    private List<INeed> needs;
    private List<Objects.IObject> ownedObjects = new List<Objects.IObject>();

    public void SetHouse(House hs)
    {
        this.house = hs;
    }

    private void Start()
    {
        lastRefresh = Time.time;
        needs = new List<INeed>(GetComponents<INeed>());
    }

    private void Update()
    {
        if (Time.time - lastRefresh > needRefreshRate)
        {
            needs = new List<INeed>(GetComponents<INeed>());
            lastRefresh = Time.time;
        }
    }

    public void UnregisterObject(Objects.IObject oldObj)
    {
        ownedObjects.Remove(oldObj);
    }

    public void RegisterNewObject(Objects.IObject obj)
    {
        ownedObjects.Add(obj);
    }

    public INeed GetNeed(int idx)
    {
        return needs[idx];
    }

    public List<Objects.IObject> GetOwned()
    {
        return ownedObjects;
    }

    public List<INeed> GetNeeds()
    {
        return needs;
    }

}
