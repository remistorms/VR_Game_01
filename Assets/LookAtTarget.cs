using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	public GameObject object_to_look_at;

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		this.transform.LookAt(object_to_look_at.transform);
	}
}
