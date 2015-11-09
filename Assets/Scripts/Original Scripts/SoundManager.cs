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
		if (mySource == null)
		{
			this.gameObject.AddComponent<AudioSource>();
		}
		mySource = GetComponent<AudioSource>();
	}
	
	public void PlayChime(int chimeID)
	{
		mySource.clip = myClips[chimeID];
		mySource.Play();
	}
}
