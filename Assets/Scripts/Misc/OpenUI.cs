using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{

    [SerializeField] GameObject UI;
    
    void Start()
    {
        
    }

    public void EnableUI()
    {
        UI.SetActive(true);
    }

    public void DisableUI()
    {
        UI.SetActive(false);
    }
}
