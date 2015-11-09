using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour {
	
	public static HUD_Script instance;

	public Image HUD_Image;
	public Sprite[] mySprites;


	void Awake()
	{
		instance = this;
	}

	public void SwitchSprite(int spriteID)
	{
		HUD_Image.sprite = mySprites[spriteID];
	}
}
