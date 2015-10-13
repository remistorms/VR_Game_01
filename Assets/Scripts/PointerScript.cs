using UnityEngine;
using System.Collections;

public class PointerScript : MonoBehaviour {

	public Transform mainCamera;
	GameObject reference;
	public static PointerScript instance;
	public CanvasGroup myCanvasGroup;

	// Use this for initialization
	void Start () 
	{
		reference = this.gameObject;
		instance = this;
		mainCamera = GameObject.Find("Main Camera").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		reference.transform.LookAt(mainCamera);
	}

	public void SetPointerPosition(Vector3 myVector)
	{
		reference.transform.position = myVector;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			myCanvasGroup.alpha = 0.0f;
		}
	}
}
