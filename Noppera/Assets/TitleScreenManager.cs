using UnityEngine;
using System.Collections;

public class TitleScreenManager : MonoBehaviour {

	public void startGame(){
		Application.LoadLevel("intro");
	}
	
	public void exitGame(){
		Application.Quit();
	}
	
	public void testButton(){
		Debug.Log("i got hella clicked doe");
	}
}
