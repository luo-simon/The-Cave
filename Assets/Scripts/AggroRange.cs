using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRange : MonoBehaviour {

    public EnemyAI enemyAIScript;
    public FollowPlayer followPlayerScript;

	// Use this for initialization
	void Start () {
        enemyAIScript = transform.parent.GetComponent<EnemyAI>();
        followPlayerScript = transform.parent.GetComponent<FollowPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(enemyAIScript != null)
                enemyAIScript.following = true;
            else
                followPlayerScript.following = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemyAIScript != null)
                enemyAIScript.following = false;
            else
                followPlayerScript.following = false;
        }
    }
}
