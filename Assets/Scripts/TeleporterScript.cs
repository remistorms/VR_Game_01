using UnityEngine;
using System.Collections;

public class TeleporterScript : MonoBehaviour {

	public bool changes_scene = false;
	public int scene_to_load;
	public Vector3 position_to_teleport;
	public TeleporterScript instance;
	


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && changes_scene == true) 
		{
			Application.LoadLevel(scene_to_load);
		}
		
		if (other.tag == "Player" && changes_scene == false) 
		{
			Player_Move.instance.gameObject.transform.position = position_to_teleport;
		}
	}
}
