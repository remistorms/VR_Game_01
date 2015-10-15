using UnityEngine;
using System.Collections;

public class WallSwitch : MonoBehaviour {

	public SkinnedMeshRenderer mySwitchMesh;
	public Material myMaterial;
	public bool state;
	public AudioSource myAudioSource;

	// Use this for initialization
	void Start () 
	{
		mySwitchMesh = GetComponent<SkinnedMeshRenderer>();
		myMaterial = mySwitchMesh.material;
		myAudioSource = GetComponent<AudioSource>();

		if (state == true) 
		{
			myMaterial.color = Color.green;
			mySwitchMesh.SetBlendShapeWeight(0, 100);
		}

		if (state == false) 
		{
			myMaterial.color = Color.red;
			mySwitchMesh.SetBlendShapeWeight(0, 0);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(this.gameObject.name + " has been hit by " + other.name);

		if(other.tag == "EnergyBall" && state == false)
		{
			myMaterial.color = Color.green;
			state = true;
		}

	}
}
