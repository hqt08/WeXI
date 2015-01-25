using UnityEngine;
using System.Collections;

public class AbstractController : MonoBehaviour {

	public GameObject abstract1;
	public GameObject abstract2;
	public GameObject we2;
	public GameObject I2;

	// Use this for initialization
	void Start () {
		abstract2.GetComponent<SpriteRenderer>().renderer.enabled = false;
		we2.GetComponent<SpriteRenderer>().renderer.enabled = false;
		I2.GetComponent<SpriteRenderer>().renderer.enabled = false;

		abstract1.GetComponent<SpriteRenderer>().renderer.enabled = true;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void page1()
	{
		abstract2.GetComponent<SpriteRenderer>().renderer.enabled = false;
		we2.GetComponent<SpriteRenderer>().renderer.enabled = false;
		I2.GetComponent<SpriteRenderer>().renderer.enabled = false;

		abstract1.GetComponent<SpriteRenderer>().renderer.enabled = true;
	}

	void page2()
	{
		abstract2.GetComponent<SpriteRenderer>().renderer.enabled = true;
		we2.GetComponent<SpriteRenderer>().renderer.enabled = true;
		I2.GetComponent<SpriteRenderer>().renderer.enabled = true;

		abstract1.GetComponent<SpriteRenderer>().renderer.enabled = false;
	}

}
