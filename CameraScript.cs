using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
    public Transform target;
    public Camera cam;

    // Camera bounds
    public Vector3 minCamera;
    public Vector3 maxCamera;

	public GameObject player;
	public PlayerScript playerScript;

	public Vector3 cameraPosition;

    public void Start()
    {
		cameraPosition = transform.position;
		playerScript = player.GetComponent<PlayerScript> ();
        cam = GetComponent<Camera>();
        cam.aspect = 16f / 10f;

    }

    void Update()
    {
		cam.transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, minCamera.x, maxCamera.x),
			Mathf.Clamp(transform.position.y, minCamera.y, maxCamera.y),
 			Mathf.Clamp(transform.position.z, minCamera.z, maxCamera.z));
    }

	void FixedUpdate () 
	{
        // Follow player
        if (target)
        {
			transform.position = Vector3.Lerp(transform.position, target.position, 0.05f) + new Vector3(0,0, -10);
        }

	}

}
