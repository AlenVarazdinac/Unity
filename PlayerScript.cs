using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    // Player
    public float playerSpeed;
	public float playerRotationSpeed;
	public float playerDodgeSpeed;
    private float playerRotation, verMovement, playerDodge;
	public Transform playerTransform;
    public int playerMaxHealth = 10;
    public int playerCurrentHealth;
    public bool isPlayerHurt = false;
	public float dodgeTimer = 0;

    // Movement Boundaries
    public float xMin, xMax, yMin, yMax;

	// Bullet
	public GameObject bullet;
	private BulletScript bulletScript;

	// Shooting Delay
	public float nextShootTime; // Able to shoot after..
	public float delay; // How much to add to get nextShootTime
	public float totalTime; // On how much to be able to shoot

	// Enemy
	public GameObject enemy;
	private EnemyScript enemyScript;
	private EnemyAIScript enemyAIScript;

	// Particles
	public ParticleSystem particles;

	// Camera
	public Camera myCamera;
	public CameraScript cameraScript;

	// Mouse Position
	Vector3 mousePos;

    // Invincibility
    public float invincibilityTime;

    // BoxCollider2D
    private BoxCollider2D boxCollider2D;

	void Awake ()
	{
		bulletScript = bullet.GetComponent<BulletScript> ();
		enemyScript = enemy.GetComponent<EnemyScript> ();
		enemyAIScript = enemy.GetComponent<EnemyAIScript> ();
        boxCollider2D = GetComponent<BoxCollider2D>();
		cameraScript = myCamera.GetComponent<CameraScript> ();


		GetComponent<Rigidbody2D> ().angularDrag = 0.3F;
		GetComponent<Rigidbody2D> ().drag = 0.2F;
		GetComponent<Rigidbody2D> ().mass = 1;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
	}
		
	void Start () 
	{
		playerCurrentHealth = playerMaxHealth;
	
	}
	
	// Update is called once per frame
	void Update (){

		dodgeTimer += Time.deltaTime;
		if (dodgeTimer >= 5) {
			
			dodgeTimer = 5;
		}

		// Shooting
		if (Input.GetKey(KeyCode.Space) && nextShootTime >= totalTime) {
			Shoot ();
		}
			
		// Destroy Player
		if (playerCurrentHealth <= 0) 
		{
			enemyAIScript.target = null;
			Destroy(gameObject);
			Debug.Log("You have been killed!");
		}

		// Shooting Delay Number Stuff
		if (nextShootTime >= 10) 
		{
			nextShootTime = 10;
			delay = 0.0F;
		} else 
		{
			delay = 0.05F;
			nextShootTime += delay;
		}

//        // Invincibility after getting hit
//        if (boxCollider2D.enabled == false)
//        {
//            // Convert invincibilityTime to seconds
//            invincibilityTime += Time.deltaTime;
//            if (invincibilityTime >= 1.0F)
//            {
//                boxCollider2D.enabled = true;
//                invincibilityTime = 0.0F;
//            }
//        }

	}

    void FixedUpdate()
    {
        // Player Movement

		playerRotation = Input.GetAxis("Rotation");
		verMovement = Input.GetAxis("ForwardReverse");
		playerDodge = Input.GetAxis ("Dodge");

		float zRotation = playerRotation * playerRotationSpeed;
		float ySpeed = verMovement * playerSpeed;
		float dodge = playerDodge * playerDodgeSpeed;

		GetComponent<Rigidbody2D> ().AddTorque (-zRotation, 0);
		GetComponent<Rigidbody2D> ().AddForce (transform.up * ySpeed);

		if (Input.GetButton("Dodge") && dodgeTimer == 3) {
			GetComponent<Rigidbody2D> ().AddForce (transform.right * dodge);
			dodgeTimer = 0;
		}
	    // Player Movement Boundaries
        GetComponent<Rigidbody2D>().position = new Vector2
            (Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, xMin, xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax));

		// Play particles
		if (playerRotation < 0 || playerRotation > 0 || verMovement < 0 || verMovement > 0) 
		{
			particles.Play ();
		} 
		else if (playerRotation == 0 || verMovement == 0) 
		{
			particles.Stop ();
		}
			
    }

	// Collision with enemy
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") 
		{
			playerCurrentHealth = playerCurrentHealth - enemyScript.enemyDamage;
			Debug.Log ("Your health is now " + playerCurrentHealth);
			isPlayerHurt = true;

     //       boxCollider2D.enabled = false;

        
        }

    }


	void Shoot(){

		Vector2 myPos = new Vector2 (playerTransform.transform.position.x, playerTransform.transform.position.y);
		GameObject projectile = (GameObject)Instantiate (bullet, myPos, Quaternion.identity);
		projectile.gameObject.name = "Bullet";
		projectile.transform.parent = playerTransform;
		projectile.GetComponent<Rigidbody2D> ().velocity = transform.up * bulletScript.bulletSpeed;
		nextShootTime = 0;


	}
}
