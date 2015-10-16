using UnityEngine;
using System.Collections;

public class Player_Settings : MonoBehaviour {

	public float player_height = 1.6f;
	public GameObject main_camera;
	public NavMeshAgent myAgent;

	// Use this for initialization
	void Start () 
	{
		myAgent = GetComponent<NavMeshAgent> ();
		SetPlayerHeight ();
		this.transform.position = GameObject.Find ("Player Start Point").transform.position;
	}
	
	public void SetPlayerHeight()
	{
		main_camera.transform.localPosition = new Vector3 (main_camera.transform.localPosition.x,
		                                                  player_height - 0.1f,
		                                                  main_camera.transform.localPosition.z);
		myAgent.height = player_height;
	}
}
