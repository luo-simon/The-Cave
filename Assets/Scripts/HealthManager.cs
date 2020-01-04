using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;

    public static int playerHealth;

    TextMeshProUGUI text;

    private GameManager gameManager;

    public bool isDead = false;

    private LivesManager livesManager;

    public Image healthBar;

    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();

        //playerHealth = maxPlayerHealth;
        playerHealth = PlayerPrefs.GetInt("PlayerHealth");

        gameManager = FindObjectOfType<GameManager>();

        livesManager = FindObjectOfType<LivesManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            gameManager.RespawnPlayer();
            livesManager.TakeLife();
            isDead = true;
        }
        text.text = "" + playerHealth;
        float playerHealthFloat = playerHealth;
        healthBar.fillAmount = playerHealthFloat/maxPlayerHealth ;
    }

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);

    }

    public void FullHealth()
    {
        //playerHealth = maxPlayerHealth;
        playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
    }
}
