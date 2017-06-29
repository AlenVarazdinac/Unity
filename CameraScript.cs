using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	private int cameraDistanceZ = -1;

	void Start () {
		
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 
				cameraDistanceZ);
		
		Camera.main.aspect = 16f / 10f;
		
	
	}

	void Update () {

		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, 
			cameraDistanceZ);
		
	}
}
