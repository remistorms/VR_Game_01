using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	 AudioSource mySource;
	public AudioClip[] myClips;
	// Use this for initialization
	void Awake () 
	{
		instance = this;
		mySource = GetComponent<AudioSource>();
	}
	
	public void PlayChime(int chimeID)
	{
		mySource.clip = myClips[chimeID];
		mySource.Play();
	}
}
