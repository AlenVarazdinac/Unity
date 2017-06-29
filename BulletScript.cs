using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int bulletSpeed;
	private float bulletCurrentLife;
	public float bulletMaxLife;
	public int bulletDamage;

	void Start () {
	
	}
	
	void Update () {

		BulletLife ();

	}

	// Destroy bullet after how much
	void BulletLife(){
		bulletCurrentLife += Time.deltaTime;
		if(bulletCurrentLife >= bulletMaxLife){
			Destroy (gameObject);
		}
	}
}
