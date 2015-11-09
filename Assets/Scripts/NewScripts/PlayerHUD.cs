using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

	public static PlayerHUD instance;
	public CanvasGroup text_canvas_group;
	public Image text_container_image;
	public Text text_label;
	public float myFloat = 0;

	// Use this for initialization
	void Start () 
	{
		instance = this;
		//text_container_image.enabled = false;
		text_canvas_group.alpha = 0f;
	}

	public void ShowInfoText(string my_text)
	{
		StartCoroutine (InfoCoRoutine (my_text));

	}

	IEnumerator InfoCoRoutine(string text_to_display)
	{
		text_label.text = text_to_display;
		
		iTween.ValueTo( this.gameObject, iTween.Hash(
			"from", 0f,
			"to", 1f,
			"time", 0.5f,
			"onupdatetarget", this.gameObject,
			"onupdate", "tweenOnUpdateCallBack",
			"easetype", iTween.EaseType.linear
			)
		               );

		yield return new WaitForSeconds (5f);

		iTween.ValueTo( this.gameObject, iTween.Hash(
			"from", 1f,
			"to", 0f,
			"time", 0.5f,
			"onupdatetarget", this.gameObject,
			"onupdate", "tweenOnUpdateCallBack",
			"easetype", iTween.EaseType.linear
			)
		               );

	}

	void tweenOnUpdateCallBack( float newValue )
	{
		text_canvas_group.alpha = newValue;
	} 
}
