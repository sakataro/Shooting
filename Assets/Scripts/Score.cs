using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public TextMesh scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "SCORE : " + score.ToString();
	}

	private void Initialize(){
		score = 0;
	}

	public void AddPoint(int point){
		score += point;
	}
}
