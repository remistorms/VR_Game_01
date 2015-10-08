using UnityEngine;
using System.Collections;

public class SkeletonTrigger : MonoBehaviour {

	public GameObject Skeleton;
	public static SkeletonTrigger instance;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	public void SkeletonPopUp()
	{
		StartCoroutine("StartSkeleton");
	}

	IEnumerator StartSkeleton()
	{
		yield return new WaitForSeconds(1.0f);
		Skeleton.SetActive(true);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			SkeletonPopUp();
		}
	}
}
