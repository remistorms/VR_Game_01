using UnityEngine;
using System.Collections;

public class EnergyBallProjectile : MonoBehaviour {

	GameObject reference;
	public float speed = 1f;
	public float timeToDissapear = 1.5f;

	// Use this for initialization
	void Start () 
	{
		reference = this.gameObject;
		Destroy(this.gameObject, timeToDissapear);
	}
	
	// Update is called once per frame
	void Update () 
	{
		reference.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(this.gameObject.name + " has hit " + other.name);
		Explode();
	}

	public void Explode()
	{
		Destroy(this.gameObject);
	}
}
