using UnityEngine;
using System.Collections;

public class EnergyRodScript : MonoBehaviour {

	public static EnergyRodScript instance;
	public GameObject projectile_prefab;
	public bool can_shoot = true;
	public Transform projectile_origin;
	public float cool_down_time = 0.5f;


	// Use this for initialization
	void Start () 
	{
		instance = this;
		this.gameObject.SetActive(false);
	}

	public void ShootEnergyBall()
	{
		GameObject projectileClone = Instantiate( projectile_prefab, projectile_origin.position, projectile_origin.transform.rotation) as GameObject;
		StartCoroutine(CoolDown());
	}

	IEnumerator CoolDown()
	{
		can_shoot = false;
		yield return new WaitForSeconds(cool_down_time);
		can_shoot = true;
	}
}
