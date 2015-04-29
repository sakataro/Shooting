using UnityEngine;
using System.Collections;

public class Enemy2Controller : MonoBehaviour {

	public float fireRate = 1.5f;
	private int point = 100;
	private float nextFire = 0.0f;
	private float center; // center of moving in the direction of x axis
	Controller controller;

	// Use this for initialization
	void Start () {
		center = transform.position.x;
		controller = GetComponent<Controller>();

	}
	
	// Update is called once per frame
	void Update () {
		//move in the direction of y axis negarive and go back center
		Vector3 direction = -Vector3.up + Vector3.right * (center-transform.position.x);
		controller.Move(direction);

		//dodge player's bullet
		GameObject[] bullet = GameObject.FindGameObjectsWithTag("PlaneBullet");
		foreach(GameObject b in bullet){
			DodgeBullet(b);
		}

		if (Mathf.Abs(transform.position.x - center) < 0.5f) { 
			//fire bullets at intervals of fireRate(seconds)
			if (Time.time > nextFire){
				nextFire = fireRate + Time.time;
				Transform barell1 = transform.Find("Barell1");
				Transform barell2 = transform.Find("Barell2");
				controller.FireBullet(barell1);
				controller.FireBullet(barell2);
			}
		}

		if (transform.position.y < -30.0){
			Destroy(gameObject);
		}
	}

	void DodgeBullet(GameObject bullet){
			// r -> direction of dodging
			Vector3 r = transform.position-bullet.transform.position;
			if (r.magnitude < 20 && r.magnitude> 5){ 
				r = r.normalized * 900/r.magnitude/r.magnitude;
				r.x *= 3.0f;
				r.y *= 0.5f;
				controller.Move(r);
		}
	}

	void OnTriggerEnter(){
		controller.Explosion();
		Destroy(gameObject);
		FindObjectOfType<Score>().AddPoint(point);
	}
}
