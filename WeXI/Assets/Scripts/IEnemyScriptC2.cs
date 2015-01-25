using UnityEngine;
using System.Collections;

public class IEnemyScriptC2 : MonoBehaviour {

	public float height;
	private gameManager gameManager;
	bool hit = false;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if(gameObject.transform.localRotation.z >0.5f && hit==false)
		{
			hit = true;
			audio.Play();
		}
		else if(gameObject.transform.localRotation.z <=0.5f && hit==true)
			hit = false;
	}

	public void triggerEnemy()
	{
		iTween.ScaleBy(gameObject, iTween.Hash("x", 3, "y", 3, "time", 0.7f));
		iTween.MoveTo(gameObject,iTween.Hash("y",transform.position.y + height, "time", 0.7f, "easetype",iTween.EaseType.linear,"oncomplete","starthammering"));
	}

	public void starthammering()
	{
		Debug.Log("hammer");
		iTween.RotateBy(gameObject, iTween.Hash("z", 0.3f, "time", 0.5f, "easetype", iTween.EaseType.easeInQuad, "looptype", iTween.LoopType.pingPong));
	}

	public void dieFunction()
	{
		// Increment score
		gameManager.increaseScore(20);
		
		// Die animation for big "I"
		Debug.Log("Boss Defeated");
		iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(0.01f,0.01f,0.01f),"time",0.5f,"oncomplete","destroyTheObject"));
	}

	void destroyTheObject()
	{
		Destroy(gameObject);
	}
}
