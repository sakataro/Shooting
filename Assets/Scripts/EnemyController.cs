using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public Rigidbody bulletPrefab; // bullet prefab
	public float fireRate = 0.1f;
	private float nextFire = 0.0f;
	private float bulletSpeed = 150.0f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;
			FireBullet();
		}	
	}

	void OnTriggerEnter(){
		Destroy(gameObject);
	}

	void FireBullet(){
		Vector3 shotPosition = transform.GetChild (transform.childCount-1).position;
		Rigidbody bullet = (Rigidbody)Instantiate (bulletPrefab,shotPosition,transform.rotation);
		bullet.velocity = new Vector3(0.0f, -bulletSpeed/2, 0.0f); // forward = Y axe
	}
}
