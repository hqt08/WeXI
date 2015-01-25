using UnityEngine;
using System.Collections;

public class BossLevel2 : MonoBehaviour {

    public float height = 3.0f;
    private GameObject player;
    public GameObject bomb;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void triggerEnemy()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", transform.position.y + height, "time", 0.7f, "easetype", iTween.EaseType.linear, "oncomplete", "startAttacking"));
    }

    void startAttacking()
    {
        Invoke("attackTowardsPlayer", 2.0f);

    }
    public void dieFunction()
    {
        Debug.Log("Boss Defeated");
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0.01f, 0.01f, 0.01f), "time", 0.5f, "oncomplete", "destroyTheObject"));
    }

    void destroyTheObject()
    {
        Destroy(gameObject);
    }

    void attackTowardsPlayer()
    {
        GameObject newBomb = (GameObject)Instantiate(bomb,transform.position,Quaternion.identity);
        Bomb newBombScript = newBomb.GetComponent<Bomb>();
        newBombScript.targetPosition = player.transform.position;
        Invoke("attackTowardsPlayer", 2.0f);
    }

}
