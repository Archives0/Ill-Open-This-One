using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public GameObject target; // The GameObject to orbit around
    public float orbitDuration = 20f; // Time in seconds for one complete orbit

    private float orbitSpeed;
    private Vector3 orbitAxis;
    private float orbitRadius;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Orbit target is not set!");
            return;
        }

        // Calculate the initial orbit radius and axis
        orbitRadius = Vector3.Distance(transform.position, target.transform.position);
        orbitAxis = Vector3.up; // This can be adjusted as needed

        // Calculate the orbit speed based on the duration of one orbit
        orbitSpeed = (360f / orbitDuration) * Time.deltaTime;
    }

    void Update()
    {
        if (target != null)
        {
            // Orbit around the target
            transform.RotateAround(target.transform.position, orbitAxis, orbitSpeed);
        }
    }
}
