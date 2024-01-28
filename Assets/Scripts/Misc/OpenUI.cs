using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{

    [SerializeField] GameObject UI;
    
    void Start()
    {
        
    }

    void EnableUI()
    {
        UI.SetActive(true);
    }

    void DisableUI()
    {
        UI.SetActive(false);
    }
}
