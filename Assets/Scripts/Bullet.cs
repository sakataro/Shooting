﻿using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 0.4f);	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(){
		Destroy(gameObject);
	}
}
