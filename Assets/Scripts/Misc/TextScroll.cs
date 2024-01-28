using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScroll : MonoBehaviour
{
	[SerializeField] float textSpeed = 0.125f;

    TextMeshProUGUI text;
	FadeScreen fadeScreen;
	LevelManager levelManager;

	string story;

	void Awake () 
	{
		fadeScreen = FindObjectOfType<FadeScreen>();
		levelManager = FindObjectOfType<LevelManager>();
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
			yield return new WaitForSeconds (textSpeed);
		}

		yield return fadeScreen.FadeOutCR(5f);
		levelManager.NextLevel();
	}

}
