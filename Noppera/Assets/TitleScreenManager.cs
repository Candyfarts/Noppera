using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour {
	
	public Image credits;
	public Button creditsBack;

	public void startGame(){
		Application.LoadLevel("intro");
	}
	
	public void exitGame(){
		Application.Quit();
	}
	
	public void showCredits(){
		credits.gameObject.SetActive(true);
		creditsBack.gameObject.SetActive(true);
	}
	
	public void hideCredits(){
		credits.gameObject.SetActive(false);
		creditsBack.gameObject.SetActive(false);
	}
	
	public void testButton(){
		Debug.Log("i got hella clicked doe");
	}
}
