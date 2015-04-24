using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	Controller controller;
	GameObject target; //this enemy fly to the target(plyer)

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller>();
		target = GameObject.Find("Plane"); 
	}
	
	// Update is called once per frame
	void Update () {
		// calculate direction of the target
		if (target != null){
			Vector3 direction = target.transform.position-transform.position;
			direction = direction.normalized;
			//move in the direction of the target
			controller.Move (direction);
		}
	}

	void OnTriggerEnter(){
		controller.Explosion();
		Destroy(gameObject);
	}


}
