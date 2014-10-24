// Adds Following to the GameObject attached
// follows GameObject with tag "Player"

using UnityEngine;
using System.Collections;

public class Follow1 : MonoBehaviour {

	Transform target;
	Transform myTransform;

	// rotation and move speed can be overriden from the Unity UI
	float moveSpeed = 6;

	void Awake()
	{
		myTransform = transform;
	}

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
		transform.LookAt (new Vector3(target.position.x, transform.position.y, target.position.z));
		myTransform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}
}
