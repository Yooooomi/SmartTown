using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPicker : MonoBehaviour
{
    private Camera cam;
    private Entity target;
    private UniversalQueue queue;

    public Text ActionText;
    public Text ActionType;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        UpdateUI();

        bool mouseClicked = Input.GetMouseButtonDown(0);

        if (!mouseClicked) return;

        Debug.Log("Clicked");

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f) && hit.collider.gameObject.CompareTag("Entity"))
        {
            Debug.Log("Found!");
            Entity ent = hit.collider.gameObject.GetComponent<Entity>();

            target = ent;
            queue = ent.GetComponent<UniversalQueue>();
        }
    }

    private void UpdateUI()
    {
        if (queue)
        {
            if (queue.GetQueueLength() > 0)
                ActionText.text = queue.queue[0].need.GetAction();
            else
                ActionText.text = "Nothing in queue";
            if (queue.actualState == BusyType.ACTING)
            {
                ActionType.text = "Interacting " + queue.queue[0].need.GetExecutionTime().ToString();
            }
            else
            {
                ActionType.text = "Travelling";
            }
        }
        else
        {
            ActionText.text = "Click on someone";
            ActionType.text = "";
        }
    }

}
