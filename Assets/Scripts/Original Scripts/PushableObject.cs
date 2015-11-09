using UnityEngine;
using System.Collections;

public class PushableObject : MonoBehaviour {

	//public Vector3 directionVector;
	public bool canMove = true;
	public float timeToMove = 1.0f;
	public Vector3 original_position;
	public Vector3 original_scale;
	public bool isStuck = false;

	void Start()
	{
		original_position = this.transform.position;
		original_scale = this.transform.localScale;
	}
	
	public void Push(Vector3 directionVector)
	{
		if (canMove) 
		{
			canMove = false;
			iTween.MoveBy(this.gameObject, iTween.Hash("amount", directionVector*2.0f, 
			                                           "time", timeToMove,
			                                           "oncomplete", "ChangeState",
			                                           "oncompletetarget", this.gameObject));
		}

	}

	public void ChangeState()
	{
		canMove = true;
	}

}
