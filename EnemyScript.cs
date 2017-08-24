using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{

	public float enemySpeed;
	public float enemyHealth;
	public float attackRange;
	public int enemyDamage = 1;
	public int scoreValue;

	// Bullet
	public GameObject bullet;
	public BulletScript bulletScript;

	// HUD
	public GameObject HUD;
	public HUDScript hudScript;

	// Enemy spawner
	public GameObject enemySpawner;
	public EnemySpawnerScript enemySpawnerScript;


	// Use this for initialization
	void Start () 
	{
		bulletScript = bullet.GetComponent<BulletScript> ();

		HUD = GameObject.FindGameObjectWithTag ("Hud");
		hudScript = HUD.GetComponent<HUDScript> ();

		enemySpawner = GameObject.FindGameObjectWithTag ("EnemySpawner");
		enemySpawnerScript = enemySpawner.GetComponent<EnemySpawnerScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyHealth == 0) 
		{
			Destroy(gameObject);
			Debug.Log("Enemy destroyed!");
			hudScript.score += scoreValue;
			hudScript.enemiesKilledCounter++;
			enemySpawnerScript.spawnedEnemies--;
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet") 
		{
			enemyHealth = enemyHealth - bulletScript.bulletDamage;
			Debug.Log ("Enemy health is now " + enemyHealth);
			Destroy(coll.gameObject);
		}

	}
}
