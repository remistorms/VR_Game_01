using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class VR_Raycaster : MonoBehaviour {

	public GameObject pointer;
	public float scaleOffset = 0.05f;
	public float rayDistance = 20f;
	Ray myRay;
	RaycastHit myHit;
	Vector3 cameraForward;
	//public CharacterController myController;
	//public Transform target;
	public Camera mainCamera;
	public NavMeshAgent myAgent;
	public Canvas myPointerCanvas;
	public Text myTextBox;
	public float maxInteractionDistance = 1.5f;

	void Awake()
	{
		myTextBox.gameObject.SetActive(false);
		//This prevents the agent to rotate since the characvter turns with players head movement
		myAgent.updateRotation = false;
	}

	void Update()
	{

		ShootRay();
		Debug.Log(myHit.distance);
		/*
		if (Cardboard.SDK.Triggered) 
		{
			//Shoots a ray from the main camera
			ShootRay();
		}
		*/


	}

	void ShootRay()
	{
		myRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
		Debug.DrawRay(myRay.origin, myRay.direction * 100, Color.red);
		if (Physics.Raycast(myRay, out myHit))
			if (myHit.distance > maxInteractionDistance) 
				{
				HUD_Script.instance.SwitchSprite(0);
				}
		{
			//Debug.Log("CHeck what has been hit");
			
			switch (myHit.collider.tag) 
			{
			case "Floor":
				//Changes the icon depending on the point hit
				if (myHit.distance <= maxInteractionDistance * 3) 
				{
					HUD_Script.instance.SwitchSprite(0);
				}

				if (myHit.distance > maxInteractionDistance * 3) 
				{
					HUD_Script.instance.SwitchSprite(0);
				}


				//If cardboard triggered is pressed, move the character to the point touched
				if (Cardboard.SDK.Triggered && myHit.distance <= maxInteractionDistance * 3) 
				{

					myAgent.SetDestination(myHit.point);
					PointerScript.instance.SetPointerPosition(myHit.point);

				}

				break;

			case "Wall":

				//Changes the icon depending on the point hit
				if (myHit.distance <= maxInteractionDistance * 3) 
				{
					HUD_Script.instance.SwitchSprite(0);
				}

				if (Cardboard.SDK.Triggered && myHit.distance <= maxInteractionDistance * 3) 
				{
					myAgent.SetDestination(myHit.point);
					myPointerCanvas.GetComponent<RectTransform>().transform.position = myHit.point;

				}
				
				break;
				
			case "Pickup":
				//Debug.Log("Pickup !!!");
				//Changes the icon depending on the point hit
				if (myHit.distance <= maxInteractionDistance) 
				{
					HUD_Script.instance.SwitchSprite(2);
				}
				break;

			case "UI_Button":
				//Debug.Log("Button has been hit with ray");
				if (myHit.distance <= maxInteractionDistance) 
				{
					HUD_Script.instance.SwitchSprite(2);
				}
				break;

			case "Interactable":
				//Debug.Log("Button has been hit with ray");
				if (myHit.distance <= maxInteractionDistance) 
				{
					HUD_Script.instance.SwitchSprite(2);
				}

				if (Cardboard.SDK.Triggered && myHit.distance <= maxInteractionDistance) 
				{
					myHit.collider.GetComponent<InteractScript>().InteractWithThis();
				}
				break;

			case "Observable":
				if (myHit.distance <= maxInteractionDistance) 
				{
					HUD_Script.instance.SwitchSprite(1);
				}

				if (Cardboard.SDK.Triggered && myHit.distance<= maxInteractionDistance) 
				{
					myTextBox.gameObject.SetActive(true);
					myTextBox.text = myHit.collider.GetComponent<ObservableScript>().ReadInfo();
					StartCoroutine(TextTimer(3));

				}
				break;

			case "InfoClip":
				if (myHit.distance <= maxInteractionDistance) 
				{
					HUD_Script.instance.SwitchSprite(3);
				}

				if (Cardboard.SDK.Triggered && myHit.distance <= maxInteractionDistance) 
				{
					myHit.collider.GetComponent<AudioInfoScript>().PlayRecording();
				}
				break;
				
			default:
				break;
			}
		}

	}

	IEnumerator GrowPointer()
	{
		//Debug.Log("BIG POINTER");	
		pointer.transform.localScale = new Vector3(pointer.transform.localScale.x + scaleOffset,
		                                           pointer.transform.localScale.y + scaleOffset,
		                                           pointer.transform.localScale.z + scaleOffset);
		yield return new WaitForSeconds (0.05f);

		//Debug.Log("SMALL POINTER");
		pointer.transform.localScale = new Vector3(pointer.transform.localScale.x - scaleOffset,
			                                           pointer.transform.localScale.y - scaleOffset,
			                                           pointer.transform.localScale.z - scaleOffset);

	}

	IEnumerator TextTimer(float time)
	{
		Debug.Log("Do something");
		yield return new WaitForSeconds(time);
		myTextBox.gameObject.SetActive(false);
	}

}
