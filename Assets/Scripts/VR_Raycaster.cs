using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class VR_Raycaster : MonoBehaviour {

	Ray myRay;
	RaycastHit myHit;
	public Camera mainCamera;
	public NavMeshAgent myAgent;
	public float maxInteractionDistance = 100.0f;

	void Awake()
	{
		myAgent.updateRotation = false;
	}

	void LateUpdate()
	{

		ShootRay();
	}

	//Shoots a ray every frame to know where player is looking
	void ShootRay()
	{
		//Creates ray from center of camera to forward relative to the camera
		myRay = mainCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));

		if (Physics.Raycast(myRay, out myHit))
		{
			Debug.Log("Has hit " + myHit.collider.name);
		}

	}
	//Handles the cursor icon position and graphic


}
