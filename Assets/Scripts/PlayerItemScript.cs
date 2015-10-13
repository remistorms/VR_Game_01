using UnityEngine;
using System.Collections;

public class PlayerItemScript : MonoBehaviour {

	//This will be the item held 
	public GameObject itemHeld;
	public static PlayerItemScript instance;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}
	
	public void UseItem()
	{

	}
}
