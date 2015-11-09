using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour {

	public static Player_Inventory instance;
	public List<GameObject> player_inventory;
	public GameObject player_backpack;
	public int max_capacity = 1;
	GameObject last_picked_up_item;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}

	void Update()
	{

	}
	public void AddItemToInventory(GameObject item)
	{
		last_picked_up_item = item;
		if (player_inventory.Count < max_capacity) 
		{
			player_inventory.Add(item);
			item.transform.SetParent(player_backpack.transform);
			item.transform.localPosition = new Vector3(0,0,0);
			item.SetActive(false);

		}

		if (player_inventory.Count <= max_capacity) 
		{
			RemoveItemToInventory(player_inventory[0]);
			player_inventory.Add(item);
			item.transform.SetParent(player_backpack.transform);
			item.transform.localPosition = new Vector3(0,0,0);
			item.SetActive(false);
		}

	}

	public void RemoveItemToInventory(GameObject item)
	{
		item.SetActive (true);
		player_inventory.Remove(item);
		player_backpack.transform.FindChild (item.name).SetParent(GameObject.Find("_Main_GO").transform);
	}
}
