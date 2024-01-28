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
    //Detect collisions between the GameObjects with Colliders attached
    /*
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

        Debug.Log("collision!");
        var x = collision.gameObject.GetComponent<IInteractable>();

        if (x != null)
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            Debug.Log(collision.gameObject);
        }
        else                                                                                                                                                                                 
        {
            Debug.Log("Hitting non-interactable object");
        }
    } */

    void Update()
    {
        if(Input.GetButtonDown("e"))
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
            closestInteractable.Interact();
        }
    }

    void OnTriggerEnter(Collider test) {
        Debug.Log("Trigger!, trying to get interactible, from: " + test.name + " type: " + test.GetType());
        var x = test.gameObject.GetComponent<IInteractable>();

        if (x != null)
        {
            if (!interactableItems.ContainsKey(x))
            {
                interactableItems.Add(x, test.gameObject);
            }

            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Found interactable:");
            Debug.Log(test.gameObject);
        }
        else
        {
            Debug.Log("Trigger!, trying to get interactible, from: " + test.name + " type: " + test.GetType());
        }
    }

    void OnTriggerExit(Collider test) {

        Debug.Log("Trigger!, exiting interactable, from: " + test.name + " type: " + test.GetType());

        var x = test.gameObject.GetComponent<IInteractable>();

        if (x != null)
        {
            if (interactableItems.ContainsKey(x))
            {
                Debug.Log("Removing interactable:");
                interactableItems.Remove(x);
                Debug.Log(test.gameObject);
            }
            else
            {
                Debug.Log("Interactable not in list (???):");
                Debug.Log(test.gameObject);
            }
        }
    }
}
