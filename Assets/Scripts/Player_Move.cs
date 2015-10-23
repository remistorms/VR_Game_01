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
	//public Transform player_backback;
	public float min_pushable_distance = 2.5f;
	RectTransform myPointerRect;
	
	void Awake()
	{
		instance = this;
		myAgent = GetComponent<NavMeshAgent>();
		myAgent.updateRotation = false;
		myPointerRect = Pointer_Manager.instance.GetComponent<RectTransform>();
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
			//myPointerRect.sizeDelta = new Vector2(0.7f, 0.7f);
			break;
			
		case "Pushable":
			//Hand
			if (myHit.distance > min_pushable_distance) 
			{
				Pointer_Manager.instance.myImage.color = Color.white;
				Pointer_Manager.instance.myText.text = "Push";
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
			Pointer_Manager.instance.SwitchPointer(0);
			
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
			// Not Hitting anything 
			Pointer_Manager.instance.transform.rotation = Quaternion.FromToRotation(Vector3.forward, myRay.direction);
			Pointer_Manager.instance.SwitchPointer(0);
			break;
		
		}
		
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

			GameObject itemGrabbed = myHit.collider.gameObject;
			Player_Inventory.instance.AddItemToInventory(itemGrabbed);

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

		//Use Stone of Will

		if (Cardboard.SDK.Triggered && surfaceHit == "Teleporter" && Player_Inventory.instance.player_backpack.transform.FindChild("Stone_of_Will") != null) 
		{
				Debug.Log("Activated Stone of Will, TELEPORT");
				Player_Move.instance.gameObject.transform.position = Pointer_Manager.instance.pointer.transform.position;
				Player_Move.instance.GetComponent<NavMeshAgent>().SetDestination(Player_Move.instance.transform.position);
		}

	}



	IEnumerator ColorBlink(Color myColor, float timeToWait)
	{
		Pointer_Manager.instance.myImage.color = myColor;
		yield return new WaitForSeconds(timeToWait);
		Pointer_Manager.instance.myImage.color = Color.white;
	}
}
