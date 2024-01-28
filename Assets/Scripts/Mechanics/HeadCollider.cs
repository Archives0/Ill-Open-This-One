using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CollisionGameObjectExample : MonoBehaviour
{
    Dictionary<IInteractable, GameObject> interactableItems = new Dictionary<IInteractable, GameObject>();

    void Awake() {
        Debug.Log("Testing 123");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            IInteractable closestInteractable = null;
            float closestDistance = Mathf.Infinity;

            foreach (IInteractable interactable in interactableItems.Keys)
            {
                float distance = Vector3.Distance(this.transform.position, interactableItems[interactable].transform.position);

                if (distance < closestDistance)
                {
                    closestInteractable = interactable;
                    closestDistance = distance;
                }
            }
            
            if (closestInteractable != null)
            {
                Debug.Log("Found closest interactable:");
                Debug.Log(closestInteractable);
                closestInteractable.Interact();
            }
            else
            {
                Debug.Log("No interactable found");
            }
        }
    }

    void OnTriggerEnter(Collider test) {
        // Debug.Log("Trigger!, trying to get interactible, from: " + test.name + " type: " + test.GetType());
        var x = test.gameObject.GetComponent<IInteractable>();

        if (x != null)
        {
            if (!interactableItems.ContainsKey(x))
            {
                interactableItems.Add(x, test.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider test) {

        // Debug.Log("Trigger!, exiting interactable, from: " + test.name + " type: " + test.GetType());

        var x = test.gameObject.GetComponent<IInteractable>();

        if (x != null)
        {
            if (interactableItems.ContainsKey(x))
            {
                interactableItems.Remove(x);
            }
        }
    }
}
