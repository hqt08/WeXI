using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
	public int gameState;
	public int score;
	public Text scoreText;
	
	// Use this for initialization
	void Start () {
		gameState = 0;
		score = 0;
		scoreText.text = "SCORE : "+score;
		
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
		
	}

	public void win() {
		Debug.Log("You Win!!!");
	}
}
