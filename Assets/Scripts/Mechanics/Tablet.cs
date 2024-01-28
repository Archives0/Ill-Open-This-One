using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour, IInteractable
{
    FadeScreen fadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        fadeScreen = FindObjectOfType<FadeScreen>();
        return;
    }

    // Update is called once per frame
    public void Interact()
    {
        Debug.Log("Do Tablet NextLevel");
        fadeScreen.FadeOut(1f,false);
        Invoke("NextScene", 1);
    }

    public void PickUp()
    {
        return;
    }

    private void NextScene()
    {
        var levelManager = FindObjectOfType<LevelManager>();
        levelManager.NextLevel();
    }
}
