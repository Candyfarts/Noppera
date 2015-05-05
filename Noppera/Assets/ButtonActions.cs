using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

	public static string titleScene = "title";

	public void titleScreen()
	{
		Application.LoadLevel(titleScene);
	}
	public void pause()
	{
		Time.timeScale = 0;
	}
	public void unpause()
	{
		Time.timeScale = 1;
	}
	public void exitGame()
	{
		Application.Quit();
	}
	public void mute()
	{
		FindObjectOfType<AudioListener>().enabled = false;
	}
	public void unmute()
	{
		FindObjectOfType<AudioListener>().enabled = true;
	}
}
