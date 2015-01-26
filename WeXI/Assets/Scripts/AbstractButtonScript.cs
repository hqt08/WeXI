using UnityEngine;
using System.Collections;

public class AbstractButtonScript : MonoBehaviour {

	public string name;

	//animation
	public GameObject we;
	public GameObject I;

	//other buttons
	public GameObject back;
	public GameObject next;
	public GameObject menu;
	public GameObject replay;

	// Use this for initialization
	void Start () {
		back.GetComponent<SpriteRenderer>().renderer.enabled = false;
		replay.GetComponent<SpriteRenderer>().renderer.enabled = false;
		menu.GetComponent<SpriteRenderer>().renderer.enabled = true;
		next.GetComponent<SpriteRenderer>().renderer.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(we.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Abstract_We_Idle") &&
		   I.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("I_Normal") &&
		   name=="Replay")
		{
			this.enabled = true;
		}
		else
		{
			this.enabled = false;
		}
	
	}

	void OnMouseUp()
	{
		if(name=="Replay")
		{
			Debug.Log("Replay");
			we.GetComponent<Animator>().CrossFade("Abstract_We_Move",0f);
			I.GetComponent<Animator>().CrossFade("I_Awake",0f);
		}
		else if(name=="Back")
		{
			GameObject.Find("AbstractController").GetComponent<AbstractController>().SendMessage("page1");
			this.GetComponent<SpriteRenderer>().renderer.enabled = false;
			this.collider2D.enabled = false;
			replay.GetComponent<SpriteRenderer>().renderer.enabled = false;
			replay.collider2D.enabled = false;
			menu.GetComponent<SpriteRenderer>().renderer.enabled = true;
			menu.collider2D.enabled = true;
			next.GetComponent<SpriteRenderer>().renderer.enabled = true;
			next.collider2D.enabled = true;
		}
		else if(name=="Next")
		{
			we.GetComponent<Animator>().CrossFade("Abstract_We_Move",0f);
			I.GetComponent<Animator>().CrossFade("I_Awake",0f);
			GameObject.Find("AbstractController").GetComponent<AbstractController>().SendMessage("page2");
			this.GetComponent<SpriteRenderer>().renderer.enabled = false;
			this.collider2D.enabled = false;
			replay.GetComponent<SpriteRenderer>().renderer.enabled = true;
			replay.collider2D.enabled = true;
			menu.GetComponent<SpriteRenderer>().renderer.enabled = false;
			menu.collider2D.enabled = false;
			back.GetComponent<SpriteRenderer>().renderer.enabled = true;
			back.collider2D.enabled = true;
		}
		else if(name=="Menu")
		{
			Application.LoadLevel("Menu");
		}
	}
}
