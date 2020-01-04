using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LivesManager : MonoBehaviour {

    //public int startingLives;
    public int lifeCounter;

    public GameObject gameOverScreen;
    public PlayerController player;

    public string mainMenu;

    private TextMeshProUGUI text;

    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();

        lifeCounter = PlayerPrefs.GetInt("PlayerLives");

        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }

        text.text = "x " + lifeCounter;
	}

    public void GiveLife()
    {
        lifeCounter++; //++ increments by one
        PlayerPrefs.SetInt("PlayerLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerLives", lifeCounter);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu); 
    }
}
