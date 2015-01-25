using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Menu_Controller : MonoBehaviour {

	public Sprite[] sprites;

	public SpriteRenderer[] sr_Buttons;
	
	private SpriteRenderer sr;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Load Level here.
	public void OnClickButton (GameObject obj)
	{
		print ("OnClickButton");
		if (obj.tag == "Abstract") 
		{
			Application.LoadLevel("Abstract");
		} 
		else if (obj.tag == "Chapter1") 
		{
			Application.LoadLevel("Scene1");
		} 
		else if (obj.tag == "Chapter2") 
		{
			Application.LoadLevel("Scene2");
		} 
		else if (obj.tag == "Credits") 
		{
			Application.LoadLevel("Credits");
		}
	}

	public void OnPointerOver (GameObject obj)
	{
		if (obj.tag == "Abstract") 
		{
			sr_Buttons[0].sprite = sprites[4];
		} 
		else if (obj.tag == "Chapter1") 
		{
			sr_Buttons[1].sprite = sprites[5];
		} 
		else if (obj.tag == "Chapter2") 
		{
			sr_Buttons[2].sprite = sprites[6];
		} 
		else if (obj.tag == "Credits") 
		{
			sr_Buttons[3].sprite = sprites[7];
		}
	}

	public void OnPointerExit (GameObject obj)
	{
		if (obj.tag == "Abstract") 
		{
			sr_Buttons[0].sprite = sprites[0];
		} 
		else if (obj.tag == "Chapter1") 
		{
			sr_Buttons[1].sprite = sprites[1];
		} 
		else if (obj.tag == "Chapter2") 
		{
			sr_Buttons[2].sprite = sprites[2];
		} 
		else if (obj.tag == "Credits") 
		{
			sr_Buttons[3].sprite = sprites[3];
		}
	}
}
