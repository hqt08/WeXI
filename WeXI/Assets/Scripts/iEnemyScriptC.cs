using UnityEngine;
using System.Collections;

public class iEnemyScriptC : MonoBehaviour {

	public float height;
	public GameObject bullet;
	public float shootDelay;
	private GameObject player;

	public enum Direction{
		Left,
		Right,
		Up
	};

	public Direction direction;

	// These properties are to get the positions of the first "i" which is already in the enemy gameObject and fire it.

	private Vector3 bulletOriginalPosition;
	public float bulletSpeed = 3.0f;
	private bool isFirstBulletShot;
	private Vector3 originalScale;
	public GameObject firstBullet;
	private GameObject newBullet;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player");
		isFirstBulletShot = false;
		originalScale = bullet.transform.localScale;
	}

	public void triggerEnemy()
	{
		iTween.MoveTo(gameObject,iTween.Hash("y",transform.position.y + height, "time", 0.7f, "easetype",iTween.EaseType.linear,"oncomplete","startshooting"));
	}

	void startshooting()
	{
		if(isFirstBulletShot == false)
		{
			// This is just to first the first bullet...
			bulletOriginalPosition = firstBullet.transform.position;
			firstBullet.AddComponent<BulletScriptC>().speedOfBullet = bulletSpeed;
			if(direction == Direction.Left)
			{
				firstBullet.GetComponent<BulletScriptC>().direction = -1;
			}else if(direction == Direction.Right)
			{
				firstBullet.GetComponent<BulletScriptC>().direction = 1;
			}
			else if(direction == Direction.Up)
			{
				firstBullet.GetComponent<BulletScriptC>().direction = 0;
			}

			Invoke("startshooting",shootDelay);

		}
		else
		{
			///This is to fire the new bullet..
			newBullet = Instantiate(bullet,bulletOriginalPosition,Quaternion.identity) as GameObject;
			newBullet.transform.localScale = Vector3.zero;
			iTween.ScaleTo(newBullet,iTween.Hash("scale",originalScale,"time",3.0f,"oncomplete","fireBullet","oncompletetarget",gameObject,"easetype",iTween.EaseType.linear));
		}

		isFirstBulletShot = true;
	}

	public void fireBullet()
	{
		newBullet.AddComponent<BulletScriptC>().speedOfBullet = bulletSpeed;
		if(direction == Direction.Left)
		{
			newBullet.GetComponent<BulletScriptC>().direction = -1;
		}else if(direction == Direction.Right)
		{
			newBullet.GetComponent<BulletScriptC>().direction = 1;
		}
		else if(direction == Direction.Up)
		{
			newBullet.GetComponent<BulletScriptC>().direction = 0;
		}
		Invoke("startshooting",shootDelay);
	}

	public void dieFunction()
	{
		iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(0.01f,0.01f,0.01f),"time",1.0f,"oncomplete","destroyTheObject"));
	}

	void destroyTheObject()
	{
		 Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
