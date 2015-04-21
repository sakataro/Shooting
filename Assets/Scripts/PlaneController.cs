using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	// Use this for initialization

	public Rigidbody bulletPrefab; // bullet prefab
	public float fireRate = 0.1f;
	private float nextFire = 0.0f;
	private float BULLETSPEED = 150.0f;   // bullet's speed
	private Vector3 FORWARD = new Vector3(0.0f,1.0f,0.0f); //forward -> y axe


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//move
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");
		transform.Translate (dx, dy, 0.0f,Space.World);

		//roll
		float yRoll = -Input.GetAxis ("Horizontal") * 30;
		transform.eulerAngles = new Vector3(0.0f,yRoll,0.0f);

		//fire at intervals of fireRate(seconds)
		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			FireBullet();
		}
	} 

	void FireBullet(){
		Vector3 shotPosition = transform.GetChild (transform.childCount-1).position; //get initial position of bullets
		Rigidbody bullet = (Rigidbody)Instantiate (bulletPrefab,shotPosition,transform.rotation);
		bullet.velocity = FORWARD * BULLETSPEED;
	}

	void OnTriggerEnter(){
		Destroy(gameObject);
	}
}