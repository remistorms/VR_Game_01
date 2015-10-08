using UnityEngine;
using System.Collections;

public class ObservableScript : MonoBehaviour {

	public string messageToDisplay;
	public AudioSource myAudio;

	public string ReadInfo()
	{
		return messageToDisplay;
	}

	public void PlayRecording()
	{
		myAudio.Play();
	}
}
