using UnityEngine;
using System.Collections;

public class MiddleDoor : MonoBehaviour {

	public AudioInfoScript[] tipSpheres;
	bool isMiddleDoorOpen = false;
	int totalHeard = 0;
	public Animator myAnimator;

	void Start()
	{
		myAnimator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () 
	{
		if (isMiddleDoorOpen == false) 
		{
			if (tipSpheres[0].hasBeenHeard == true &&
			    tipSpheres[1].hasBeenHeard == true &&
			    tipSpheres[2].hasBeenHeard == true &&
			    tipSpheres[3].hasBeenHeard == true ) 
			{
				myAnimator.SetTrigger("OpenMiddleDoor");
				isMiddleDoorOpen = true;
			}
		}
	}
}
