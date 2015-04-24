using UnityEngine;
using System.Collections;

public class Enemy2Controller : MonoBehaviour {

	public float fireRate = 1.5f;
	private float nextFire = 0.0f;
	Controller controller;
	// Use this for initialization
	void Start () {
		controller =GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire){
			nextFire = fireRate + Time.time;
			Transform barell1 = transform.Find("Barell1");
			Transform barell2 = transform.Find("Barell2");
			controller.FireBullet(barell1);
			controller.FireBullet(barell2);
		}
	}

	void OnTriggerEnter(){
		controller.Explosion();
		Destroy(gameObject);
	}
}
