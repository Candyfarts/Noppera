using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public static TextManager singleton;

	public float textSpeed;

	public RectTransform dialogueBox;
	public Text dialogueText;

	public List<string> textBuffer;

	// Use this for initialization
	void Start () {
		singleton = this;
		dialogueBox.gameObject.SetActive(false);
		dialogueText.text = "";
		StartCoroutine(addText());
	}

	public void write(string s)
	{
		if(textBuffer.Count == 0)
			textBuffer.Add(s);
	}

	public void writeImportant(string s)
	{
		textBuffer.Add(s);
	}

	public IEnumerator addText()
	{
		string s;
		while (true)
		{
			while (textBuffer.Count == 0)
			{
				dialogueBox.gameObject.SetActive(false);
				yield return new WaitForSeconds(textSpeed * 10);
			}
			s = textBuffer[0];
			dialogueBox.gameObject.SetActive(true);
			dialogueText.text = "";
			while (s.Length > 0)
			{
				dialogueText.text += s[0];
				s = s.Substring(1);
				yield return new WaitForSeconds(textSpeed);
			}
			yield return new WaitForSeconds(textSpeed * 10);
			textBuffer.RemoveAt(0);
		}
	}
}
