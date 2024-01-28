using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] Vector3 rotAmount;
    [SerializeField] float openDuration;
    [SerializeField] AudioClip door;

    AudioSource audioSource;
    Vector3 initialRot;
    bool isOpen = false;

    public bool isFinalDoor;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialRot = transform.localEulerAngles;
    }

        public void DoorOpen()
    {
        audioSource.PlayOneShot(door);
        StartCoroutine(SlideOpen());
    }

    public void Interact() {
        Debug.Log("Do DoorOpen:");
        DoorOpen();
    }

    public void PickUp()
    {
        return;
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

            if (isFinalDoor)
            {
                var levelManager = FindObjectOfType<LevelManager>();
                levelManager.NextLevel();
            }
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
