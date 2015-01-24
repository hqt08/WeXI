using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioSource jump;
	public AudioSource smallAttack;
	public AudioSource bigAttack;
	public AudioSource hit;
	public AudioSource die;
	private gameManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			if (!jump.isPlaying)
				jump.Play();
		}
		Debug.Log (manager.getGameState());
	}
}
