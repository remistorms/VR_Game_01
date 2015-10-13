using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour {

	public static Player_Inventory instance;
	public List<GameObject> player_inventory;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}
	
	public void AddItemToInventory(GameObject item)
	{
		player_inventory.Add(item);
	}

	public void RemoveItemToInventory(GameObject item)
	{
		player_inventory.Remove(item);
	}
}
