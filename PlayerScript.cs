using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// STATS
	public float playerSpeed;
	public float playerSpeedBckp;
	public float leftRightSpeed;
	public float leftRightSpeedBckp;
	public float rotationSpeed;
	public float boostSpeed;
	public float maxBoost;
	public float currentBoost;

//	private Rigidbody2D rb2D;

	// For shooting
	public float shootingReady;
	public float shootTimer;
	public GameObject bulletPrefab;
	private BulletScript bulletScript;

	void Start () {

//		rb2D = GetComponent<Rigidbody2D>();
		bulletScript = bulletPrefab.GetComponent<BulletScript> ();
		currentBoost = 100;
		maxBoost = 100;
		playerSpeedBckp = playerSpeed;
		leftRightSpeedBckp = leftRightSpeed;
	
	}

	void Update () {
		PlayerBoost ();

		// Refill boost
		currentBoost += Time.deltaTime * 10;
		if (currentBoost >= maxBoost) {
			currentBoost = maxBoost;
		}
	}

	void FixedUpdate () {
		PlayerMovement ();
		Shooting ();

		

		shootTimer += Time.deltaTime;
		if (shootTimer >= 1){
			shootTimer = 1;
		}

	}


	void Shooting(){
		if (Input.GetMouseButton(0) && shootTimer >= shootingReady) {
			Vector2 target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
			Vector2 direction = target - myPos;
			direction.Normalize();
			GameObject bullet = (GameObject)Instantiate( bulletPrefab, myPos, Quaternion.identity);
			bullet.name = "Bullet";
			bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletScript.bulletSpeed; // direction or transform.up
			shootTimer = 0;
		}
	}

	void PlayerMovement(){

		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.up * Time.deltaTime * playerSpeed;
		} else if (Input.GetKey (KeyCode.S)) {
			transform.position -= transform.up * Time.deltaTime * playerSpeed;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * Time.deltaTime * leftRightSpeed;
		} else if (Input.GetKey (KeyCode.A)) {
			transform.position -= transform.right * Time.deltaTime * leftRightSpeed;
		}

		// Rotate towards mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position);

		// Keyboard Rotation
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			transform.Rotate (-Vector3.forward * rotationSpeed * Time.deltaTime);
//		} else if (Input.GetKey (KeyCode.LeftArrow)) {
//			transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
//		}
	}

	void PlayerBoost(){
		if (Input.GetKey (KeyCode.LeftShift) && currentBoost >= 0) {
			playerSpeed = boostSpeed;
			leftRightSpeed = boostSpeed;
			currentBoost--;
		}else if (Input.GetKeyUp(KeyCode.LeftShift) || currentBoost <= 0){
			playerSpeed = playerSpeedBckp;
			leftRightSpeed = leftRightSpeedBckp;
		}

	}
}
