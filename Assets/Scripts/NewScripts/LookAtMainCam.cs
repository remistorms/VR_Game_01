using UnityEngine;
using System.Collections;

public class LookAtMainCam : MonoBehaviour {

	public bool lookAtCam = true;
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (lookAtCam) 
		{
			this.transform.LookAt (Camera.main.transform);
		}

	}
}
