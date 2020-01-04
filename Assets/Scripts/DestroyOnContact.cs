using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public EnemyHealthManager healthManager;

	// Use this for initialization
	void Start () {
        healthManager = GetComponent<EnemyHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Player")
        {
            healthManager.GiveDamage(healthManager.maxEnemyHealth);
        }
    }
}
