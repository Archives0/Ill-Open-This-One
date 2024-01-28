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

	public bool isEndingScene;

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
		
		yield return fadeScreen.FadeOutCR(4f);

		if (!isEndingScene)
		{
			levelManager.NextLevel();
		}
		else
		{
			yield return EndSceneScroll();
		}
	}

	public IEnumerator EndSceneScroll()
    {
		Debug.Log("EndSceneScroll");
		text.color = Color.black;
		text.text = "Press ENTER to play again.";
		yield return null;
    }

	public void Update()
	{
		if(isEndingScene && Input.GetKeyDown(KeyCode.Return))
		{
			levelManager.NextLevel();
		}
	}
}
