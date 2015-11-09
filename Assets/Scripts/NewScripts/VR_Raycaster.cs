using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class VR_Raycaster : MonoBehaviour {

	//public static VR_Raycaster instance;
	public bool debug_ray = true;
	public string object_hit_name;
	public string object_hit_tag;
	public Ray myRay;
	public RaycastHit myHit;
	public float maxInteractionDistance = 100.0f;

	void start()
	{
		//instance = this;
	}

	void FixedUpdate()
	{
		myRay = new Ray (Camera.main.transform.position, Camera.main.transform.forward);

		if (Physics.Raycast(myRay, out myHit, maxInteractionDistance))
		
		{
		
		}

		else 
		{
			PlayerCursorScript.instance.SetCursor(0);	
		}

		HandleCursorIcon ();

	}

	void HandleCursorIcon()
	{
			switch (myHit.collider.tag) 
				
			{
			default:
				PlayerCursorScript.instance.SetCursor(0);
				break;
				
			case "Observable":
				PlayerCursorScript.instance.SetCursor(1);
				break;
				
			case "Interactable":
				PlayerCursorScript.instance.SetCursor(2);
				break;
				
			case "Walkable":
				PlayerCursorScript.instance.SetCursor(3);
				break;
				
			case "Item":
				PlayerCursorScript.instance.SetCursor(4);
				break;
			}

	}
}
