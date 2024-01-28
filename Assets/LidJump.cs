using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidJump : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip pop;

    private Rigidbody m_Rigidbody;
    public float m_ForceMagnitude = .0000000002f; // Adjust the force magnitude as needed
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        m_Rigidbody = GetComponent<Rigidbody>();

        // Assuming your GameObject has a Collider, you can set its material here
        // Adjust "BouncyMaterial" to the actual name of your Physics Material
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.material = new PhysicMaterial("BouncyMaterial");
            collider.material.bounciness = 1.0f; // 1.0 for maximum bounciness
        }
    }

    // Update is called once per frame
    public void Interact()
    {
        m_Rigidbody.isKinematic = false;
        Vector3 forceDirection = new Vector3(1f, 1f, 0f).normalized;
        m_Rigidbody.AddForce(forceDirection * m_ForceMagnitude);
        audioSource.PlayOneShot(pop);
    }
}
