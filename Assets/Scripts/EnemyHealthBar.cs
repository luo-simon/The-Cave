using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

    EnemyHealthManager enemyHealthManager;

    public Image healthBar;

    // Use this for initialization
    void Start () {
        enemyHealthManager = GetComponent<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update () {
        float enemyHealthFloat = enemyHealthManager.enemyHealth;
        healthBar.fillAmount = enemyHealthFloat / enemyHealthManager.maxEnemyHealth;
    }
}
