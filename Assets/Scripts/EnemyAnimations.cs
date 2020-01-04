using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    EnemyHealthManager enemyHealthManager;
    private Animator anim;

    // Use this for initialization
    void Start () {
        enemyHealthManager = GetComponent<EnemyHealthManager>();
        anim.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
