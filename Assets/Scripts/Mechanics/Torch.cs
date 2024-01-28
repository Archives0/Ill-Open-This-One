using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    public GameObject pointLight;
    public GameObject fire; 
    bool isOn = false;

    void Start()
    {
        pointLight.SetActive(false);
        fire.SetActive(false);
    }

    public void Interact() {
        Debug.Log("Do Torch:");
        isOn = !isOn;
        pointLight.SetActive(isOn);
        fire.SetActive(isOn);
    }

    public void PickUp()
    {
        return;
    }
}
