using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
	public int gameState;
	//public int score;
	public Text scoreText;
	private AudioManager audio;
	private bool hasPlayed;
	private bool won;

	private const int STATE_GAME = 0;
	private const int STATE_DIE = 1;
	private const int STATE_WIN = 2;
	private const int STATE_MENU = 3;
	private const int STATE_CREDITS = 4;
	
	// Use this for initialization
	void Start () {
		gameState = STATE_GAME;
		audio = GameObject.Find("Game Manager").GetComponent<AudioManager>();
		hasPlayed = false;
		won = false;
	}
	
	//Can be called from any script to increase the score and update it inside the unity GUI...
	public void increaseScore(int tempScore)
	{
		GlobalStats.score += tempScore;
		scoreText.text = "SCORE : "+ GlobalStats.score;
	}
	
	public void setGameState(int state) {
		gameState = state;
	}
	
	public int getGameState() {
		return gameState;
	}
	
	// Update is called once per frame
	void Update () {
		if (won) {
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 80, Time.deltaTime * 1);
		}

		switch (gameState) { 
		case STATE_GAME:
			renderScore();
			break;
		case STATE_DIE:
			
			break;
		case STATE_WIN:
			
			break;
		case STATE_MENU:
			
			break;
		case STATE_CREDITS:
			
			break;			
		}
		
	}
	
	void renderScore(){
		scoreText.text = "SCORE : "+ GlobalStats.score;
	}

	public void win() {
		Debug.Log("You Win!!!");
		won = true;
		if(!hasPlayed){
			audio.win.Play ();
			hasPlayed = true;
		}

		gameState = STATE_WIN;
		GameObject.Find("PageFlipper").animation.Play("page-flip");

		StartCoroutine("LoadNextLevel");
	}

	IEnumerator LoadNextLevel() {
		yield return new WaitForSeconds(2f);
		GameObject.Find("PageFlipper").animation.Play("page-flip");
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Scene2");
	}
}
