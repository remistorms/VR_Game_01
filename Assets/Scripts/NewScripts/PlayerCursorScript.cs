using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCursorScript : MonoBehaviour {

	public static PlayerCursorScript instance;

	public GameObject player_cursor;
	public Image sprite_image;
	public Sprite[] cursor_sprites;
	int currentCursor = 0;

	void Start()
	{
		instance = this;
		player_cursor = this.gameObject;
	}

	public void SetCursor(int spriteID)
	{
		sprite_image.sprite = cursor_sprites [spriteID];
	}

	void Update()
	{
	
	}
}
