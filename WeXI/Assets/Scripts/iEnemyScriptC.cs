using UnityEngine;
using System.Collections;

public class iEnemyScriptC : MonoBehaviour {

	public float height;
	public GameObject bullet;
	public float shootDelay;
	private GameObject player;

	public enum Direction{
		Left,
		Right
	};

	public Direction direction;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		iTween.MoveTo(gameObject,iTween.Hash("y",transform.position.y + height, "time", 2.0f, "easetype",iTween.EaseType.linear,"oncomplete","startshooting"));
	}

	void startshooting()
	{
		GameObject tempBullet = Instantiate(bullet,transform.position,Quaternion.identity) as GameObject;
		if(direction == Direction.Left)
		{
			tempBullet.GetComponent<BulletScriptC>().direction = -1;
		}else
		{
			tempBullet.GetComponent<BulletScriptC>().direction = 1;
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
