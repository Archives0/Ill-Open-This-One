using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    FadeScreen fadeScreen;

    void Start()
    {
        fadeScreen = FindObjectOfType<FadeScreen>();
        fadeScreen.FadeIn(3f);
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        Debug.Log("Going to scene index:");
        Debug.Log(nextIndex);

        if(nextIndex > 2) {
            return;
        }
        
        SceneManager.LoadScene(nextIndex);
    }
}
