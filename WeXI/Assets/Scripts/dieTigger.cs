using UnityEngine;
using System.Collections;

public class dieTigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void death(){
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetTrigger ("die");
	}
}
