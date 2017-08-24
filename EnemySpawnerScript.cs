using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour {

	// When to spawn
	public float enemy1Timer;
	public float enemy1TimeToSpawn = 5.5F;
	public float enemy2Timer;
	public float enemy2TimeToSpawn = 4.5F;
    public float enemy3Timer;
    public float enemy3TimeToSpawn = 3.5F;
    public float enemy4Timer;
    public float enemy4TimeToSpawn = 4.0F;
	public float enemy5Timer;
	public float enemy5TimeToSpawn = 4.5f;

	// Enemies
	public GameObject enemy1;
	public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
	public GameObject enemy5;

	// How much enemies has been spawned
	public int maxEnemy;
	public int spawnedEnemies;
//	private EnemySpawnerScript enemySpawnerScript;

	// How much enemies to kill
	public int howMuchToKill;

	// Get HUD for counting how much enemies is killed
	public GameObject HUD;
	public HUDScript hudScript;


	void Awake () 
	{		
		hudScript = HUD.GetComponent<HUDScript> ();
//		enemySpawnerScript = GetComponent<EnemySpawnerScript>();
		spawnedEnemies = 0;
	}

	void Update () 
	{
		
		// Time in seconds
		enemy1Timer += Time.deltaTime;
		enemy2Timer += Time.deltaTime;
		enemy3Timer += Time.deltaTime;
		enemy4Timer += Time.deltaTime;
		enemy5Timer += Time.deltaTime;

		// Stop spawning when xx enemies is spawned, start if less.
		if (spawnedEnemies >= maxEnemy) 
		{
			
			Debug.Log ("Spawner has stopped spawning enemies!");
		} 
		else if (spawnedEnemies <= maxEnemy) 
		{
			SpawnEnemies ();
			Debug.Log("Spawner has started spawning enemies!");
		}



	}

	// This controls enemy spawning
	public void SpawnEnemies()
	{

		// Spawn Enemy1
		if (enemy1Timer >= enemy1TimeToSpawn) 
		{
			Instantiate (enemy1, new Vector2(450, 0), Quaternion.identity);
			enemy1Timer = 0.0F;
			spawnedEnemies++;
		}

		// Spawn Enemy2
		if (enemy2Timer >= enemy2TimeToSpawn) 
		{
			Instantiate (enemy2, new Vector2(550, 0), Quaternion.identity);
			enemy2Timer = 0.0F;
			spawnedEnemies++;
		}

		// Spawn Enemy3
		if (enemy3Timer >= enemy3TimeToSpawn) 
		{
			Instantiate (enemy3, new Vector2(350, 0), Quaternion.identity);
			enemy3Timer = 0.0F;
			spawnedEnemies++;
		}

		// Spawn Enemy4
		if (enemy4Timer >= enemy4TimeToSpawn) 
		{
			Instantiate (enemy4, new Vector2(750, 0), Quaternion.identity);
			enemy4Timer = 0.0F;
			spawnedEnemies++;
		}

		// Spawn Enemy5
		if (enemy5Timer >= enemy5TimeToSpawn) 
		{
			Instantiate (enemy5, new Vector2(500, 0), Quaternion.identity);
			enemy5Timer = 0.0F;
			spawnedEnemies++;
		}

	}
}
