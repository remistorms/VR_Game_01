using UnityEngine;
using System.Collections;

public class OpenDoorButton : MonoBehaviour {

	public Animator myAnimator;
	// Use this for initialization
	void Start () 
	{
		myAnimator = GetComponent<Animator>();
	}
	
	public void OpenDoor()
	{
		myAnimator.SetBool("DoorOpen", true);
	}
}
