using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour 
{
	public GUIText score;
	public int currentScore = 0;
	public GameObject titleScreen;

	public void AddScore(int amountToAdd)
	{
		currentScore += amountToAdd;
		score.text = currentScore.ToString ();
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width-150, Screen.height-60, 120, 30), "Main Menu"))
		{
			GameObject g = Instantiate (titleScreen) as GameObject;
			g.name = "titleScreen";
			Destroy(gameObject);
		}
	}
}
