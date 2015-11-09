using UnityEngine;
using System.Collections;

public class HookshotScript : MonoBehaviour {

	public GameObject grapple_point;

	// Use this for initialization
	void Start () 
	{
		this.gameObject.tag = "Hookshot";
		if (grapple_point == null) 
		{
			grapple_point = this.gameObject;
		}
	}

}
