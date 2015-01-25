using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
	public int gameState;
	public int score;
	public Text scoreText;
	private AudioManager audio;
	private bool hasPlayed;
	private bool won;
	
	// Use this for initialization
	void Start () {
		gameState = 0;
		score = 0;
		scoreText.text = "SCORE : "+score;
		audio = GameObject.Find("Game Manager").GetComponent<AudioManager>();
		hasPlayed = false;
		won = false;
	}
	
	//Can be called from any script to increase the score and update it inside the unity GUI...
	public void increaseScore(int tempScore)
	{
		score += tempScore;
		scoreText.text = "SCORE : "+score;
		
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
	}

	public void win() {
		Debug.Log("You Win!!!");
		won = true;
		if(!hasPlayed){
			audio.win.Play ();
			hasPlayed = true;
		}
		StartCoroutine("LoadNextLevel");
	}

	IEnumerator LoadNextLevel() {
		yield return new WaitForSeconds(2f);
		GameObject.Find("PageFlipper").animation.Play("page-flip");
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Scene2");
	}
}
