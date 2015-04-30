using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public GameObject Enemy1Prefab;
	public GameObject Enemy2Prefab;
	public float enemy1Rate = 1.0f; //the frequency of enemy1's appearance 
	public float enemy2Rate = 10.0f;//the frequency of enemy2's appearance
	private float enemy1Time = 0.0f;
	private float enemy1Speed;
	private float enemy2Time = 10.0f;
	private GameManager manager;
	private Score score;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager>();
		score = FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.isPlaying ){

			SetLevel();

			//enemy1 generater 
			if (Time.time > enemy1Time){
				Vector3 initial = GetInitial(); 
				enemy1Time = Time.time + enemy1Rate;
				GameObject enemy1 = Instantiate(Enemy1Prefab,initial,transform.rotation) as GameObject;
				Controller cont = enemy1.GetComponent<Controller>();
				cont.speed = enemy1Speed;
			}

			//enemy2 generater
			if (Time.time > enemy2Time){
				Vector3 initial = GetInitial();
				enemy2Time = Time.time + enemy2Rate;
				GameObject enemy2 = Instantiate(Enemy2Prefab,initial,transform.rotation) as GameObject;
			}
		}else if (!manager.isPlaying && !manager.isGameOver){
			Time.timeScale = 0;
		}


		 
	}

	Vector3 GetInitial(){
		float iniX = Random.Range(-35.0f,35.0f);
		return new Vector3(iniX,35.0f,0.0f); 
	}

	 void SetLevel(){
		if(score.GetScore() < 100){
			enemy1Speed = 0.1f;
			enemy2Rate = 10.0f; 
		}else if(score.GetScore() < 200){
			enemy1Speed = 0.2f;
			enemy2Rate = 8.0f; 
		}else if(score.GetScore() < 300){
			enemy1Speed = 0.3f;
			enemy2Rate = 6.0f;
		}else if(score.GetScore() < 400){
			enemy1Speed = 0.4f;
			enemy2Rate = 4.0f;
		}else{ 
			enemy1Speed = 0.5f;
			enemy2Rate = 2.0f;
		}
	}

}
