using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {

    public EnemyAI enemyAIScript;
    public bool triggered = false;
    public Collider2D player;

    // Use this for initialization
    void Start()
    {
        enemyAIScript = transform.parent.GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !player.isActiveAndEnabled)
        {
            enemyAIScript.inRange = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAIScript.inRange = true;
            triggered = true;
            player = other;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAIScript.inRange = false;
            triggered = false;
        }
    }
}
