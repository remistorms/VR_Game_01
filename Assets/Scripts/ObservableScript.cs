using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObservableScript : MonoBehaviour {

	public string messageToDisplay;
	public AudioSource myAudio;
	public Text myText;

	void Start()
	{
		myText.text = messageToDisplay;
	}
	public string ReadInfo()
	{
		return messageToDisplay;
	}

	public void PlayRecording()
	{
		myAudio.Play();
	}
}
