using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpable : MonoBehaviour
{
    public float collisionImpulseScale = 1.0f; // Public variable to scale collision impulse.
    
    // Start is called before the first frame update
    void Start()
    {
        return;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If this isn't the player character skip
        if (!collision.gameObject.CompareTag("PlayerCharacter")) {
            return;
        }
        // Calculate the collision direction.
        Vector3 collisionDirection = transform.position - collision.contacts[0].point;
        collisionDirection.Normalize();

        // Calculate the collision impulse based on the collision velocity.
        float collisionVelocity = collision.relativeVelocity.magnitude;
        float impulseMagnitude = collisionVelocity * collisionImpulseScale;

        // Apply the impulse in the opposite direction of the collision.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(collisionDirection * impulseMagnitude, ForceMode.Impulse);
        }
    }

}
