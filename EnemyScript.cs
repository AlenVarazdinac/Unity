using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHealth;
	public GameObject bullet;
	private BulletScript bulletScript;

	void Start () {
		bulletScript = bullet.GetComponent<BulletScript> ();
	}
	
	void Update () {
		DestroyEnemy ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Bullet") {
			enemyHealth -= bulletScript.bulletDamage;
			Destroy (coll.gameObject);
		}
	}

	void DestroyEnemy() {
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
