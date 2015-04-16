using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");
		transform.Translate (dx, dy, 0.0f);
	}
}
