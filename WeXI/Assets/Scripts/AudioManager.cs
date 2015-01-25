using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioSource jump;
	public AudioSource smallAttack;
	public AudioSource bigAttack;
	public AudioSource push;
	public AudioSource hit;
	public AudioSource die;
	public AudioSource win;
	public AudioSource addScore;
	private gameManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (manager.getGameState());
	}
}
