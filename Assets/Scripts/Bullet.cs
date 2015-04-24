using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 30 || transform.position.y < -30){
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(){
		Destroy(gameObject);
	}
}
