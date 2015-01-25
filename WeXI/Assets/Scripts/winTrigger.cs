using UnityEngine;
using System.Collections;

public class winTrigger : MonoBehaviour {
	public GameObject GameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player") {
			GameManager.SendMessage("win");
		}
	}
}
