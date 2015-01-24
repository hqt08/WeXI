using UnityEngine;
using System.Collections;

public class destroyTimed : MonoBehaviour {

	public float timeToDestroy = 10.0f;

	// Use this for initialization
	void Start () {

		Destroy(gameObject,timeToDestroy);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
