using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pointer_Manager : MonoBehaviour {

	public static Pointer_Manager instance;
	public GameObject pointer;
	public Sprite[] myPointerSprites;
	public Image myImage;
	public Text myText;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
		pointer = this.gameObject;
		myImage = this.transform.FindChild("Image").GetComponent<Image>();
	}

	//Changes the sprite of the ponter at runtime
	public void SwitchPointer(int sprite_id)
	{
		myImage.sprite = myPointerSprites[sprite_id];
	}
}
