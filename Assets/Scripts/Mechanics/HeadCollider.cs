using UnityEngine;

public class CollisionGameObjectExample : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

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
    }
}