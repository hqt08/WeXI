using UnityEngine;
using System.Collections;

public class BulletScriptC : MonoBehaviour {

	public float speedOfBullet;

	[HideInInspector]
	public int direction = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	

		if(direction == -1 || direction == 1)
		{
			transform.Translate(new Vector3(direction,0,0) * speedOfBullet * Time.deltaTime);
		}
		else if(direction == 0)
		{
			transform.Translate(new Vector3(0,1,0) * speedOfBullet * Time.deltaTime);
		}
		
	}
}
