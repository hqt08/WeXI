using UnityEngine;
using System.Collections;

public class IEnemyScriptC1 : MonoBehaviour {

	public float height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void triggerEnemy()
	{
		Debug.Log("triggered");
		iTween.MoveTo(gameObject,iTween.Hash("y",transform.position.y + height, "time", 0.2f, "easetype",iTween.EaseType.linear,"oncomplete","startrolling"));
	}

	public void startrolling()
	{
		iTween.MoveTo(gameObject,iTween.Hash("delay",0.2f,"x",transform.position.x + 100f,"y",transform.position.y,"time",10f,"easetype",iTween.EaseType.linear, "oncomplete","destroyTheObject"));
		iTween.RotateBy(gameObject, iTween.Hash("z", 1.0f, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.easeInOutQuad));
	}

	void destroyTheObject()
	{
		Destroy(gameObject);
	}
}
