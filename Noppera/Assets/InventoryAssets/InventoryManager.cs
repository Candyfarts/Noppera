using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public enum Item {Null, Egg, Book, Paintbrush};
	public Item currentSelectedItem = Item.Null;
	public static InventoryManager _singleton;
	public bool storyObjectTargeted = false;
	public GameObject bookIcon;
	public GameObject eggIcon;
	public GameObject brushIcon;
	
	private Texture2D book;
	private Texture2D egg;
	private Texture2D pbrush;
	private Texture2D dcursor;
	
	void Start(){
		book = (Texture2D)Resources.Load("Book01");
		egg = (Texture2D)Resources.Load("Egg");
		pbrush = (Texture2D)Resources.Load("paintbrush_and_ink");
		dcursor = (Texture2D)Resources.Load("Arrow");
	}
	
	public static InventoryManager singleton {
		get {
			if(_singleton == null){
				_singleton = GameObject.FindObjectOfType<InventoryManager>();
			}
			return _singleton;
		}
	}
	
	// used to deselect cursor when clicking on an unimportant item
	void Update(){
		if(!storyObjectTargeted){
			if(Input.GetKey(KeyCode.Mouse0)){
				cancelItem();
			}
		}
	}
	
	public void selectEgg(){
		currentSelectedItem = Item.Egg;
		Cursor.SetCursor(egg, Vector2.zero, CursorMode.Auto);
	}
	
	public void selectBook(){
		currentSelectedItem = Item.Book;
		Cursor.SetCursor(book, Vector2.zero, CursorMode.Auto);
	}
	
	public void selectBrush(){
		currentSelectedItem = Item.Paintbrush;
		Cursor.SetCursor(pbrush, Vector2.zero, CursorMode.Auto);
	}
	
	public void cancelItem(){
		currentSelectedItem = Item.Null;
		Cursor.SetCursor(dcursor, Vector2.zero, CursorMode.Auto);
	}
	
	public Item getCurrentItem(){
		return currentSelectedItem;
	}
	
	public void deactivateItem(GameObject item){
		item.SetActive(false);
	}
	
	public void activateItem(GameObject item){
		item.SetActive(true);
	}
	
}
