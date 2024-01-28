using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScroll : MonoBehaviour
{
    TextMeshProUGUI text;
	FadeScreen fadeScreen;

	string story;

	void Awake () 
	{
		fadeScreen = FindObjectOfType<FadeScreen>();
		text = text = GetComponent<TextMeshProUGUI> ();

		story = text.text;
		text.text = "";

		// TODO: add optional delay when to start
		StartCoroutine ("PlayText");
	}

	IEnumerator PlayText()
	{
        string[] words = story.Split(' ');
		foreach (var word in words) 
		{
			text.text += word + " ";
			yield return new WaitForSeconds (0.125f);
		}

		fadeScreen.FadeOut(5f);
	}

}
