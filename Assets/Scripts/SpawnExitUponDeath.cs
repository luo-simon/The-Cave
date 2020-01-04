using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExitUponDeath : MonoBehaviour {

    public GameObject exit;
    public EnemyHealthManager enemyHealthManager;

	// Use this for initialization
	void Start () {
        enemyHealthManager = GetComponent<EnemyHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyHealthManager.dead == true)
        {
            exit.gameObject.SetActive(true);
        }
    }
}
