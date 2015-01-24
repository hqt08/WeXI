using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public float speed = 12;
	public float jumpForce = 50.0f;
	private bool isAllowedToJump;
	public float blinkingTime;
	private gameManager manager;

	// Use this for initialization
	void Start () {

		isAllowedToJump = true;
		manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		// Moves player left, right, up, down. No collision.
		float x = Input.GetAxis("Horizontal") * Time.smoothDeltaTime * speed;
		//float y = Input.GetAxis("Vertical") * Time.smoothDeltaTime * speed;
		transform.Translate(x,0,0,Space.Self);

		if(Input.GetButtonDown("Jump") && isAllowedToJump == true)
		{
			isAllowedToJump = false;
			jumpFunction();
		}

		if(rigidbody2D.velocity.y < -15.0f)
		{
			dieFunction();
		}

	}

	void jumpFunction()
	{
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(new Vector2(0,1) * jumpForce);
	}

	void dieFunction()
	{
		Application.LoadLevel(Application.loadedLevelName);

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		isAllowedToJump = true;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		isAllowedToJump = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "killTag")
		{
			dieFunction();
		}
		if(other.gameObject.tag == "jumpEnemyTag")
		{
			other.gameObject.transform.parent.GetComponent<iEnemyScriptC>().dieFunction();
			jumpFunction();
		}
		if(other.gameObject.tag == "coin")
		{
			Destroy(other.gameObject);
			manager.increaseScore(1);
		}
	}
}
