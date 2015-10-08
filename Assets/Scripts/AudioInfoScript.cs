using UnityEngine;
using System.Collections;

public class AudioInfoScript : MonoBehaviour {

	AudioSource myAudioSource;
	public AudioClip myClip;
	GameObject thisObj;
	public Material usedMaterial;
	public bool hasBeenHeard = false;

	void Awake()
	{
		myAudioSource = GetComponent<AudioSource>();
		thisObj = this.gameObject;
	}

	void Update()
	{
		thisObj.transform.RotateAround(Vector3.up, 1*Time.deltaTime);
	}

	void Start()
	{
		//PlayRecording();
	}
	public void PlayRecording()

	{
		myAudioSource.Stop();
		myAudioSource.clip = myClip;
		myAudioSource.Play();
		thisObj.GetComponent<MeshRenderer>().material = usedMaterial;
		hasBeenHeard = true;
	}
}
