using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public static Player_Move instance;
	public Ray myRay;
	public RaycastHit myHit;
	public Camera mainCamera;
	public NavMeshAgent myAgent;
	public Vector3 myHitPoint;
	public string surfaceHit;
	public Transform player_backback;
	public float min_pushable_distance = 2.5f;
	
	void Awake()
	{
		instance = this;
		myAgent = GetComponent<NavMeshAgent>();
		myAgent.updateRotation = false;
	}
	
	void LateUpdate()
	{
		if (Physics.Raycast(myRay, out myHit)) 
		{
			myHitPoint = myHit.point;
			surfaceHit = myHit.collider.tag;
		}

		ShootRay();
		HandleCursor();
		HandleAction();
	}
	
	//Shoots a ray every frame to know where player is looking
	void ShootRay()
	{
		//Creates ray from center of camera to forward relative to the camera
		myRay = mainCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
	}

	public void HandleAction()
	{
		//WALK
		//Moves character if trigger is pressed while looking at the floor
		if (Cardboard.SDK.Triggered && surfaceHit == "Floor") 
		{
			Debug.Log("Walk");
			StartCoroutine(ColorBlink(Color.cyan, 0.1f));
			myAgent.SetDestination(myHit.point);
			PointerScript.instance.transform.position = myHit.point;
			PointerScript.instance.myCanvasGroup.alpha = 0.5f;
		}

		//Pick Up Item
		if (Cardboard.SDK.Triggered && surfaceHit == "Pickup") 
		{
			Debug.Log("Grabbed Item");
			StartCoroutine(ColorBlink(Color.cyan, 0.1f));
			GameObject itemGrabbed = myHit.collider.gameObject;
			Player_Inventory.instance.AddItemToInventory(itemGrabbed);
			itemGrabbed.transform.SetParent(player_backback);
			itemGrabbed.transform.localPosition = new Vector3(0,0,0);
			itemGrabbed.SetActive(false);
		}

		if (Cardboard.SDK.Triggered && surfaceHit == "Pushable" && myHit.distance < min_pushable_distance) 
		{
			Debug.Log("Push Object");
			myHit.collider.GetComponent<PushableObject>().Push((-1)* myHit.normal);
		}

		if (Cardboard.SDK.Triggered && surfaceHit == "Observable" && myHit.distance < 2.0f) 
		{
			myHit.collider.GetComponent<ObservableScript>().ReadInfo();
		}

		//Shoot Energy Ball
		if (Cardboard.SDK.Triggered && Player_Inventory.instance.hasEnergyRod && myHit.collider.tag != "Floor") 
		{
			EnergyRodScript.instance.ShootEnergyBall();
		}
	}


	//Handles the cursor icon position and graphic
	void HandleCursor()
	{
		//Handles Position and Rotation of the cursor
		myHitPoint = myHit.point;
		Pointer_Manager.instance.transform.position = myHitPoint;
		//Pointer_Manager.instance.transform.rotation = Quaternion.LookRotation(myHit.normal, (myHit.point - mainCamera.transform.position));
		//Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myHit.normal);
		switch (surfaceHit) 
		
		{

		case "Floor":
			//Footprints
			Pointer_Manager.instance.transform.rotation = Quaternion.LookRotation(myHit.normal, (myHit.point - mainCamera.transform.position));
			Pointer_Manager.instance.SwitchPointer(1);
			break;

		case "Pushable":
			//Hand
			if (myHit.distance > min_pushable_distance) 
			{
				Pointer_Manager.instance.myImage.color = Color.white;
			}

			if (myHit.distance <= min_pushable_distance) 
			{
				Pointer_Manager.instance.myImage.color = Color.cyan;
			}

			Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myHit.normal);
			Pointer_Manager.instance.SwitchPointer(2);
			break;

		case "Observable":
			//Eye
			Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myHit.normal);
			Pointer_Manager.instance.SwitchPointer(3);
			break;

		case "Pickup":
			//ItemBox
			Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myHit.normal);
			Pointer_Manager.instance.SwitchPointer(4);
			break;

		case "Hittable":
			//Crosshair
			Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myHit.normal);
			Pointer_Manager.instance.SwitchPointer(5);
			break;

		default:
			Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myHit.normal);
			if (Player_Inventory.instance.hasEnergyRod == false) 
			{
				Pointer_Manager.instance.SwitchPointer(0);
			}

			if (Player_Inventory.instance.hasEnergyRod == true) 
			{
				Pointer_Manager.instance.SwitchPointer(5);
			}

			break;
		}
	
	}

	IEnumerator ColorBlink(Color myColor, float timeToWait)
	{
		Pointer_Manager.instance.myImage.color = myColor;
		yield return new WaitForSeconds(timeToWait);
		Pointer_Manager.instance.myImage.color = Color.white;
	}
}
