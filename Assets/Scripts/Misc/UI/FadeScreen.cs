using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

    CanvasGroup canvasGroup;
    
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeOut(float time, bool isBlack=true)
    {
        var image = GetComponent<Image>();
        if (!isBlack)
        {
            image.color = Color.white;
        }
        StartCoroutine(FadeOutCR(time));
    }

    public void FadeIn(float time)
    {
        StartCoroutine(FadeInCR(time));
    }


    public IEnumerator FadeOutCR(float time)
    {
        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadeInCR(float time)
    {
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }
}
