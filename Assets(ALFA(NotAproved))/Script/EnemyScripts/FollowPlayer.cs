// Adds Following to the GameObject attached
// follows GameObject with tag "Player"

using UnityEngine;
using System.Collections;

public class Follow1 : MonoBehaviour {
	
	Transform target;
	Transform myTransform;
	
	// rotation and move speed can be overriden from the Unity UI
	float moveSpeed = 3;
	float rotationSpeed = 3;
	
	void Awake()
	{
		myTransform = transform;
	}
	
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () {
		transform.LookAt (new Vector3(target.position.x, transform.position.y, target.position.z));
		myTransform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {
		if ((other.tag == "Player")) {
			moveSpeed = 0;
		}
	}
	void OnTriggerExit(Collider other) {
		if ((other.tag == "Player")) {
			moveSpeed = 3;
		}
	}
}
