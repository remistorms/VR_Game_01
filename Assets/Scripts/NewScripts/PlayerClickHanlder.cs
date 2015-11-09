using UnityEngine;
using System.Collections;

public class PlayerClickHanlder : MonoBehaviour {

	public VR_Raycaster raycaster_reference;

	void Start()
	{
		raycaster_reference = GetComponent<VR_Raycaster> ();
	}
	// Update is called once per frame
	void Update () 
	{
		//MOVE 
		if (Cardboard.SDK.Triggered) 
		{
			switch (raycaster_reference.myHit.collider.tag) 
			
			{
				//MOVE
				case "Walkable":
				Player_Move.instance.MoveCharacter(raycaster_reference.myHit.point);
				break;

				case "Observable":
				PlayerHUD.instance.ShowInfoText(raycaster_reference.myHit.collider.GetComponent<ObservableScript>().message);
				break;

			default:
			break;
			}
		}
	}
}
