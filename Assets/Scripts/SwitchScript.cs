using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public GameObject button_mesh;
	Vector3 original_scale;
	public bool requires_to_stay = false;
	public GameObject[] temp_door;

	void Start()
	{
		original_scale = button_mesh.transform.localScale;
	}

	void OnTriggerEnter(Collider other)
	{
		SoundManager.instance.PlayChime(0);
	}

	void OnTriggerExit(Collider other)
	{
		if (requires_to_stay == true) 
		{
			SoundManager.instance.PlayChime(0);
			iTween.ScaleTo(button_mesh, original_scale, 0.2f);

			foreach (var item in temp_door) 
			{
				item.SetActive(true);
			}

		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" || other.tag == "Pushable") 
		{
			iTween.ScaleTo(button_mesh, new Vector3(button_mesh.transform.localScale.x, button_mesh.transform.localScale.y, 0.2f), 0.2f);

			foreach (var item in temp_door) 
			{
				item.SetActive(false);
			}
		}
	}


}
