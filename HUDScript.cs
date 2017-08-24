using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public Sprite[] heartSprites;
    public Image heartUI;
    // Get player
    public GameObject player;
    public PlayerScript playerScript;  
	// Red Flash
	public Image hurtEffect;
	public int timeToFade = 100; // How much time needs to fade effect
	public int currentFade = 0; // What is current time for fade
	public int addToFade = 1; // How much time to add to timeToFade
	// Score
	public Text scoreText;
	public int score;
	// Enemies Killed
	public Text enemiesKilledText;
	public int enemiesKilledCounter;
	// Enemy Spawner
	public GameObject enemySpawner;
	public EnemySpawnerScript enemySpawnerScript;

    void Awake ()
    {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemySpawnerScript = enemySpawner.GetComponent<EnemySpawnerScript> ();
        playerScript = player.GetComponent<PlayerScript>();
		// Reset the score
		score = 0;
		// Reset enemies killed
		enemiesKilledCounter = 0;
	}

    void Update ()
    {
        heartUI.sprite = heartSprites[playerScript.playerCurrentHealth];

		// Hurt Effect
		if (hurtEffect.enabled == true && currentFade >= timeToFade) 
		{
			hurtEffect.enabled = false;
			currentFade += addToFade;

		}
		
	 	if (playerScript.isPlayerHurt == true) 
		{
			hurtEffect.enabled = true;
			currentFade += addToFade;

			if (currentFade >= timeToFade)
			{
				hurtEffect.enabled = false;
				playerScript.isPlayerHurt = false;
				currentFade = 0;
			}
		} 

		scoreText.text = "Score: " + score.ToString();
		enemiesKilledText.text = "Killed: " + enemiesKilledCounter.ToString ();

		if (enemiesKilledCounter >= enemySpawnerScript.howMuchToKill) 
		{
			enemySpawnerScript.enabled = false;
		}
	}
}
