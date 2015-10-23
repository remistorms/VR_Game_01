using UnityEngine;
using System.Collections;

public class StoneScript : MonoBehaviour {

	string stone_type;
	public GameObject equiped_stone;
	Vector3 original_position;

	void Awake()
	{
		original_position = this.transform.position;
		stone_type = this.gameObject.name;
	}
	void OnEnable()
	{
		ResetPosition ();
	}
	// Use this for initialization
	void ResetPosition () 
	{
		this.transform.position = original_position;
	}

	public void UseStoneOfWill()
	{
		if (Player_Inventory.instance.player_backpack.transform.FindChild("Stone_of_Will") != null && Player_Move.instance.myHit.collider.tag == "Teleporter") 
		{
			Debug.Log("Activated Stone of Will, TELEPORT");
			Player_Move.instance.gameObject.transform.position = Pointer_Manager.instance.pointer.transform.position;
		}

	}

	public void UseStoneOfPower()
	{
		
	}

	public void UseStoneOfMight()
	{
		
	}
}
