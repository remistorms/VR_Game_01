using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public static Player_Move instance;
	public NavMeshAgent myAgent;
	public GameObject destination_beacon;
	
	void Start()
	{
		instance = this;
		myAgent = GetComponent<NavMeshAgent>();
		myAgent.updateRotation = false;
		destination_beacon = GameObject.Find ("destination_beacon");
		destination_beacon.SetActive (false);
	}

	void Update()
	{
		//Checks to see if player has already reached the beacon meaning, it has stopped
		//Debug.Log (myAgent.remainingDistance);
		if (Vector3.Distance(destination_beacon.transform.position, this.transform.position) <= 0.5f) 
		{
			destination_beacon.SetActive(false);
		}
	}

	//Handles the cursor icon position and graphic
	public void MoveCharacter(Vector3 point_to_move)
	{
			destination_beacon.SetActive (true);
			destination_beacon.transform.position = point_to_move;
			StartCoroutine(ColorBlink(Color.cyan, 0.1f));
			myAgent.SetDestination (point_to_move);

	}

	IEnumerator ColorBlink(Color myColor, float timeToWait)
	{
		Pointer_Manager.instance.myImage.color = myColor;
		yield return new WaitForSeconds(timeToWait);
		Pointer_Manager.instance.myImage.color = Color.white;
	}
}
