using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour{

	public Rigidbody bulletPrefab; // bullet prefab
	public GameObject explosionPrefab; // explosion(gameobject whith particle system)
	public float speed = 1.0f;
	public float bulletSpeed = 100.0f;
	private static bool isQuitting = false; // whether aplication quits or not
	
	// Use this for initialization
	void Start (){
	
	}
	
	// Update is called once per frame
	void Update (){
	
	}

	//move gameObject
	public void Move (Vector3 direction){
		transform.Translate (direction * speed, Space.World);

		//rolling 
		float roll = -direction.x * 30;
		transform.eulerAngles = new Vector3 (0.0f, roll, 0.0f);
	}

	//fire bullet in the direction of barell's y axe
	public void FireBullet (Transform barell){
		Rigidbody bullet = (Rigidbody)Instantiate (bulletPrefab,
		                                           barell.position,
		                                           barell.rotation);
		bullet.velocity = barell.up * bulletSpeed;
	}

	//create explosion at position of gameofject
	public void Explosion (){
		if (!isQuitting) {
			GameObject explosion = (GameObject)Instantiate (explosionPrefab, transform.position, transform.rotation);
			explosion.GetComponent<ParticleSystem> ().Play ();
		}
	}

	void OnApplicationQuit (){
		isQuitting = true;
	}
}
