using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Event e;

	public string[] text;
	int sindex = 0;

	public void trigger () {
		if(e != null)
			e.activate();
		if(text.Length > 0){
			TextManager.singleton.write(text[sindex]);
			sindex ++;
			if(sindex >= text.Length){
				sindex = 0;
			}
		}
	}
}
