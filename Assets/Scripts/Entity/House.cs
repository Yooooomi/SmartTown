using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject human;
    public Objects.Fridge fridge;

    private void Start()
    {
        GameObject humanIntantiated = Instantiate(human, transform.position, Quaternion.identity) as GameObject;

        fridge.SetOwner(humanIntantiated.GetComponent<Entity>());
        humanIntantiated.GetComponent<Entity>().SetHouse(this);
    }

}
