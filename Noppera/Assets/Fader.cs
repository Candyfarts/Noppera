using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	
	public float fadeTime;

	private float timer;

	private bool done = true;
	private Vector3 target;
	public GUITexture guitexture;

	void Awake (){
		guitexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guitexture.color = Color.clear;
		guitexture.enabled = true;
	}

	public void fadeTo(Vector3 fadeTo, float fadeTime){
		if (done) {
			target = fadeTo;
			timer = 0;
			this.fadeTime = fadeTime;
			done = false;
			Player.instance.stuck = true;
		}
	}

	void Update () {
		if (!done) {
			timer += Time.deltaTime;
			float time = timer / fadeTime;
			if (time > 1){
				time = 2 - time;
				Player.instance.transform.position = target;
				Player.instance.useTrigger = null;
			}
			guitexture.color = Color.Lerp (Color.clear, Color.black, time);
			if (time < 0){
				Player.instance.stuck = false;
				done = true;
			}
		}
	}
}
