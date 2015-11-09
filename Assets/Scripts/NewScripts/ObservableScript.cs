using UnityEngine;
using System.Collections;

public class ObservableScript : MonoBehaviour {

	public string message = "";

	// Use this for initialization
	void Start () 
	{
		this.gameObject.tag = "Observable";
	}

}
