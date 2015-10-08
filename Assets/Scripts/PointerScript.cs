using UnityEngine;
using System.Collections;

public class PointerScript : MonoBehaviour {

	public Transform mainCamera;
	GameObject reference;
	public static PointerScript instance;

	// Use this for initialization
	void Start () 
	{
		reference = this.gameObject;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		reference.transform.LookAt(mainCamera);
	}

	public void SetPointerPosition(Vector3 myVector)
	{
		reference.transform.position = myVector;
	}
}
