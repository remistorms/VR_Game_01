using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour {

	public static Player_Inventory instance;
	public List<GameObject> player_inventory;
	public bool hasEnergyRod = false;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}

	void Update()
	{
		if (hasEnergyRod) 
		{
			EnergyRodScript.instance.gameObject.SetActive(true);
		}
	}
	public void AddItemToInventory(GameObject item)
	{
		player_inventory.Add(item);
		if (item.name == "Energy Rod") 
		{
			hasEnergyRod = true;
			EnergyRodScript.instance.gameObject.SetActive(true);
		}
	}

	public void RemoveItemToInventory(GameObject item)
	{
		player_inventory.Remove(item);
		if (item.name == "Energy Rod") 
		{
			hasEnergyRod = false;
			EnergyRodScript.instance.gameObject.SetActive(true);
		}
	}
}
