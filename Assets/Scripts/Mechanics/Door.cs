using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 rotAmount;
    [SerializeField] float openDuration;
    Vector3 initialRot;
    bool isOpen = false;

    void Start()
    {
        initialRot = transform.localEulerAngles;
    }

        public void DoorOpen()
    {
        StartCoroutine(SlideOpen());
    }

    public IEnumerator SlideOpen()
    {
        // initialRot = GetComponent<Transform>().localEulerAngles;
        float travelPercent = 0f;

        if(isOpen == false)
        {
            while(travelPercent < 1f)
            {
                travelPercent += openDuration * Time.deltaTime;
                transform.localEulerAngles = Vector3.Lerp(initialRot, rotAmount, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            isOpen = true;
        }
        else
        {
            while(travelPercent < 1f)
            {
                travelPercent += openDuration * Time.deltaTime;
                transform.localEulerAngles = Vector3.Lerp(rotAmount, initialRot, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            isOpen = false;
        }
    }
}
