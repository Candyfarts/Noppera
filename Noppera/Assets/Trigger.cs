using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Event e;

	public string[] text;
	public bool important = true;
	public bool alltext = false;
	int sindex = 0;
	public int useCount = 1;

	public void trigger () {
		if(e != null)
			e.activate();
		if(text.Length != 0){ 
			if (useCount > 0 && TextManager.singleton != null)
			{
				if (alltext){
					if(important || TextManager.singleton.textBuffer.Count == 0){
						foreach(string s in text){
							TextManager.singleton.writeImportant(s);
						}
					}
				}
				else
				{
					if (important)
						TextManager.singleton.writeImportant(text[sindex]);
					else
						TextManager.singleton.write(text[sindex]);

					sindex++;
					if (sindex >= text.Length)
					{
						sindex = 0;
					}
				}
				useCount--;
			}
		}
		if (useCount == 0)
		{
			this.gameObject.SetActive(false);
		}
	}
}
