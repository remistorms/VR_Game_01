using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public GameObject button_mesh;
	Vector3 original_scale;
	public bool requires_to_stay = false;
	public GameObject temp_door;

	void Start()
	{
		original_scale = button_mesh.transform.localScale;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" || other.tag == "Pushable") 
		{
			SoundManager.instance.PlayChime(0);
			iTween.ScaleTo(button_mesh, new Vector3(button_mesh.transform.localScale.x, button_mesh.transform.localScale.y, 0.2f), 0.2f);
			iTween.MoveBy(temp_door, Vector3.down * 5, 1.0f);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (requires_to_stay) 
		{
			SoundManager.instance.PlayChime(0);
			iTween.ScaleTo(button_mesh, original_scale, 0.2f);
			iTween.MoveBy(temp_door, Vector3.up * 5, 1.0f);
		}
	}

	void OnTriggerStay(Collider other)
	{
		button_mesh.transform.localScale = new Vector3(button_mesh.transform.localScale.x, button_mesh.transform.localScale.y, 0.2f);
	}


}
