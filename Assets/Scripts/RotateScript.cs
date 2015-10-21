using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	GameObject thisObject;
	public float rotateSpeed = 5.0f;
	public Vector3 rotation_vector = new Vector3(0,1,0);
	// Use this for initialization
	void Start () 
	{
		thisObject = this.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		thisObject.transform.RotateAround (rotation_vector, rotateSpeed * Time.deltaTime);
	}
}
