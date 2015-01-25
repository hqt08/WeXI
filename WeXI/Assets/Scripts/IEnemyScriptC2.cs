using UnityEngine;
using System.Collections;

public class IEnemyScriptC2 : MonoBehaviour {

	public float height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void triggerEnemy()
	{
		iTween.ScaleBy(gameObject, iTween.Hash("x", 4, "y", 5, "time", 0.7f));
		iTween.MoveTo(gameObject,iTween.Hash("y",transform.position.y + height, "time", 0.7f, "easetype",iTween.EaseType.linear,"oncomplete","starthammering"));
	}

	public void starthammering()
	{
		Debug.Log("hammer");
		iTween.RotateBy(gameObject, iTween.Hash("z", 0.3f, "time", 0.3f, "easetype", iTween.EaseType.easeInQuad, "looptype", iTween.LoopType.pingPong));
	}

	public void dieFunction()
	{
		Debug.Log("Boss Defeated");
		iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(0.01f,0.01f,0.01f),"time",0.5f,"oncomplete","destroyTheObject"));
	}

	void destroyTheObject()
	{
		Destroy(gameObject);
	}
}
