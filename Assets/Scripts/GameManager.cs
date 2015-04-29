using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject title;
	private GameObject gameOver;
	public bool isPlaying = false;
	public bool isGameOver = false;

	// Use this for initialization
	void Start () {
		title = GameObject.Find("Title");
		gameOver = GameObject.Find("GameOver");
		gameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlaying == false && Input.GetButton("Submit")) {
			GameStart();
		}

		if (isGameOver && Input.GetButton("Submit")){

			Application.LoadLevel("Shooting");
		}
	}

	//game start -> erase title and move time
	void GameStart(){
		Time.timeScale = 1.0f;
		title.SetActive(false);
		isPlaying = true;
	}

	//appear "game over"
	public void GameOver(){
		gameOver.SetActive(true);
		isGameOver = true;
		isPlaying  = false;
	}

}
