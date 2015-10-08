using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {
	

	public void InteractWithThis()
	{
		GetComponent<OpenDoorButton>().OpenDoor();
	}
}
