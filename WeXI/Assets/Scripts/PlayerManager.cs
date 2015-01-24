using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public float speed = 12;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Moves player left, right, up, down. No collision.
		float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
		float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;
		transform.Translate(x,y,0,Space.Self);
	}
}
