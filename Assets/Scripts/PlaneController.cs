using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	// Use this for initialization

	public float fireRate = 0.1f;
	private float nextFire = 0.0f;
	Controller controller;

	void Start () {
		controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		//move
		Vector3 directon = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
		controller.Move (directon);
		Clamp();

		//fire at intervals of fireRate(seconds)
		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			//get fire-dirrection and initial position
			Transform barell = transform.Find("Barell");
			controller.FireBullet(barell);
		}
	}

	//limit position in the screen
	void Clamp(){
		//get bottom-left and right-up of the screen 
		Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0,0,48));
		Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1,1,48));

		Vector3 pos = transform.position;

		//change position in the screen
		pos.x = Mathf.Clamp(pos.x,min.x,max.x);
		pos.y = Mathf.Clamp(pos.y,min.y,max.y);

		transform.position = pos;
	}
	
	void OnTriggerEnter(){
		controller.Explosion();
		Destroy(gameObject);
	}



}