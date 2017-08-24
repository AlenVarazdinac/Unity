using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour 
{

	// For random movement
	public Transform[] randomPoint;
	public Transform[] enemySpawner;
	public int currentPoint;

	// Get Enemy
	public GameObject enemy;
	private EnemyScript enemyScript;
	public bool followingPlayer;

	// Get Player
	public Transform target;
	Collider2D followPlayer;
	public GameObject player;

	public LayerMask playerMask;
	

	void Start () 
	{
		// Get enemy script
		enemyScript = enemy.GetComponent<EnemyScript> ();

        // Get player
		player = GameObject.FindGameObjectWithTag ("Player");

		// Attach Player
		target = GameObject.Find ("Player").transform;

		// Attach Random Point
		randomPoint [0] = GameObject.Find ("RandomPoint1").transform;
		randomPoint [1] = GameObject.Find ("RandomPoint2").transform;
		randomPoint [2] = GameObject.Find ("RandomPoint3").transform;
		randomPoint [3] = GameObject.Find ("RandomPoint4").transform;
		randomPoint [4] = GameObject.Find ("RandomPoint5").transform;
		randomPoint [5] = GameObject.Find ("RandomPoint6").transform;
		randomPoint [6] = GameObject.Find ("RandomPoint7").transform;
		randomPoint [7] = GameObject.Find ("RandomPoint8").transform;
		randomPoint [8] = GameObject.Find ("RandomPoint9").transform;
		randomPoint [9] = GameObject.Find ("RandomPoint10").transform;
		randomPoint [10] = GameObject.Find ("RandomPoint11").transform;
		randomPoint [11] = GameObject.Find ("RandomPoint12").transform;
		randomPoint [12] = GameObject.Find ("RandomPoint13").transform;
		randomPoint [13] = GameObject.Find ("RandomPoint14").transform;

		// Attach Enemy Spawner
		enemySpawner [0] = GameObject.Find ("EnemySpawner1").transform;
		enemySpawner [1] = GameObject.Find ("EnemySpawner2").transform;
		enemySpawner [2] = GameObject.Find ("EnemySpawner3").transform;
		enemySpawner [3] = GameObject.Find ("EnemySpawner4").transform;
		enemySpawner [4] = GameObject.Find ("EnemySpawner5").transform;
		enemySpawner [5] = GameObject.Find ("EnemySpawner6").transform;
		enemySpawner [6] = GameObject.Find ("EnemySpawner7").transform;
		enemySpawner [7] = GameObject.Find ("EnemySpawner8").transform;

		// Get Random Spawn Location 
		int randomSpawnPoint = Random.Range (0, 7);
		transform.position = enemySpawner [randomSpawnPoint].position;
		currentPoint = randomSpawnPoint;

	}

	void Update () 
	{
		followPlayer = Physics2D.OverlapCircle (transform.position, enemyScript.attackRange, playerMask);

		// If player is not in enemy line of sight then don't follow player 

		int nextRandPoint = Random.Range (0, 13);
		// If enemy is at the random point get another random point
		if (transform.position == randomPoint [currentPoint].position) 
		{
			currentPoint = nextRandPoint;
		}

		// Continue loop
		if (currentPoint >= randomPoint.Length) 
		{
			currentPoint = nextRandPoint;
		}

		if (followPlayer == false)
		{
			transform.position = Vector2.MoveTowards (transform.position, randomPoint [currentPoint].position, enemyScript.enemySpeed * Time.deltaTime);
			followingPlayer = false;
		}
		// If player is in enemy line of sight then follow Player
		else
		{
			transform.position = Vector2.MoveTowards (transform.position, target.position, enemyScript.enemySpeed * Time.deltaTime);
			followingPlayer = true;
		}

    }

}
