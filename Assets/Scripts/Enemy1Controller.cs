using UnityEngine;
using System.Collections;

public class Enemy1Controller : MonoBehaviour {

	private int point = 10;
	Controller controller;
	GameObject target; //this enemy fly to the target(plyer)

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller>();
		target = GameObject.Find("Plane"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null){
			// calculate direction of the target
			Vector3 direction = target.transform.position-transform.position;
			direction = direction.normalized;

			//move in the direction of the target
			controller.Move (direction);
		}
	}

	void OnTriggerEnter(){
		controller.Explosion();
		Destroy(gameObject);
		FindObjectOfType<Score>().AddPoint(point);
	}
}
