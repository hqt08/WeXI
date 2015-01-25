using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	public GameObject core;
	float lobHeight = 3;
	float lobTime = 2.0f;
	public Vector3 targetPosition;
    public GameObject blastEffect;

	void Start(){

        //lobHeight = transform.position.y + lobHeight;

		iTween.MoveBy(core, iTween.Hash("y", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(core, iTween.Hash("y", -lobHeight, "time", lobTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));
        iTween.MoveTo(gameObject, iTween.Hash("position", targetPosition, "time", lobTime, "easeType", iTween.EaseType.linear, "onComplete", "cleanUp"));
	}

    void cleanUp()
    {
        //iTween.FadeTo(gameObject, iTween.Hash("delay", 0.4f, "time", .5, "alpha", 0, "onComplete", "destroyObject"));
        GameObject tempEffect = Instantiate(blastEffect, core.transform.position, Quaternion.identity) as GameObject;
        Destroy(tempEffect, 1.0f);
        Destroy(gameObject);	

    }
	
	void destroyObject(){
		//Destroy(gameObject);	
	}
}

