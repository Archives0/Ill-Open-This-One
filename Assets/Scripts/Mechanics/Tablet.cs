using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        return;
    }

    // Update is called once per frame
    public void Interact()
    {
        Debug.Log("Do Tablet NextLevel:");
        var levelManager = FindObjectOfType<LevelManager>();
        Debug.Log(levelManager);
        levelManager.NextLevel();
    }

    public void PickUp()
    {
        return;
    }
}
