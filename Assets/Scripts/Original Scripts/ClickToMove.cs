using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public NavMeshAgent myAgent;
	public Camera myCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

			if (Physics.Raycast(ray, out hit)) 
			{
				myAgent.SetDestination(hit.point);
			}
		}
	}
}
