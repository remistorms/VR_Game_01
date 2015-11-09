using UnityEngine;
using System.Collections;

public class DirectionVectorTrigger : MonoBehaviour {

	public PushableObject myCubeToPush;

	void Start()
	{
		//makes the cube invisible on awake
		GetComponent<MeshRenderer>().enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(this.gameObject.name + " has touched " + other.name);

		if (other.tag == "Wall") 
		{
			StartCoroutine(ResetCubePosition());
		}
	}

	IEnumerator ResetCubePosition()
	{
		myCubeToPush.canMove = false;
		yield return new WaitForSeconds(0.5f);
		iTween.ScaleTo(myCubeToPush.gameObject, Vector3.zero, 0.5f);
		yield return new WaitForSeconds(1.5f);
		myCubeToPush.transform.position = myCubeToPush.original_position;
		myCubeToPush.transform.localScale = myCubeToPush.original_scale;
	}
}
