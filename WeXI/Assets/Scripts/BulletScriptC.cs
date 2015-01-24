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

		transform.Translate(new Vector3(direction,0,0) * speedOfBullet * Time.deltaTime);
		
	}
}
