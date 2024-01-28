using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip strike;
    AudioSource audioSource;

    public GameObject pointLight;
    public GameObject fire; 
    bool isOn = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pointLight.SetActive(false);
        fire.SetActive(false);
    }

    public void Interact() {
        Debug.Log("Do Torch:");
        isOn = !isOn;
        pointLight.SetActive(isOn);
        fire.SetActive(isOn);
        audioSource.PlayOneShot(strike);
    }

    public void PickUp()
    {
        return;
    }
}
