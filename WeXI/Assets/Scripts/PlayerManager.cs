using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public float speed = 12;
	public float jumpForce = 50.0f;
	private bool isAllowedToJump;
	public float blinkingTime;
	private gameManager manager;
	private bool hasControl;
	private AudioManager audio;


	public bool isTest;
	// Use this for initialization
	void Start () {

		hasControl = false;
		isAllowedToJump = true;
		manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
		audio = GameObject.Find("Game Manager").GetComponent<AudioManager>();

		//Have to keep gravity scale at 0 so the body does not start counting velocity.. which is a condition for dying(falling off)
		rigidbody2D.gravityScale = 0.0f;

		//The "istest" boolean allows us to test the player from anywhere on the screen.. without the "start" animation of the character..
		if(isTest == false)
		{
			//Starting animation of the player which moves the player at start position
			if(Application.loadedLevelName == "Scene1")
				iTween.MoveTo(gameObject,iTween.Hash("delay",0.5f,"x",transform.position.x - 2.0f,"y",transform.position.y + 3.0f,"time",1.0f,"easetype",iTween.EaseType.linear,"oncomplete","giveControl"));
			else if(Application.loadedLevelName == "Scene2")
				iTween.MoveTo(gameObject,iTween.Hash("delay",0.5f,"x",transform.position.x - 2.0f,"y",transform.position.y + 3.0f,"time",1.0f,"easetype",iTween.EaseType.easeOutSine,"oncomplete","giveControl"));
		}
		else
		{
			giveControl();
		}

	}

	void giveControl()
	{
		rigidbody2D.gravityScale = 1.0f;
		hasControl = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(hasControl == true)
		{
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
				Debug.Log("DIE Reason : Fall off");
				StartCoroutine( dieFunction());
			}


		}

	}

	void jumpFunction()
	{
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(new Vector2(0,1) * jumpForce);
	}

	IEnumerator dieFunction()
	{
		Debug.Log("Player DIE function called");
		manager.setGameState (1);
		if (!audio.die.isPlaying)
			audio.die.Play ();
		yield return new WaitForSeconds(.5f);
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
		if(other.gameObject.tag == "jumpEnemyTag")
		{
			other.gameObject.transform.parent.GetComponent<iEnemyScriptC>().dieFunction();
			jumpFunction();
		}
		else if(other.gameObject.tag == "killTag")
		{
			Debug.Log("DIE Reason : Kill Tag");
			StartCoroutine( dieFunction());
		}
		else if(other.gameObject.tag == "coin")
		{
			Destroy(other.gameObject);
			manager.increaseScore(1);
		}
	}
}
