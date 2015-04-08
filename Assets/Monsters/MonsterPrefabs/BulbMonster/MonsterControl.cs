using UnityEngine;
using System.Collections;

public class MonsterControl : MonoBehaviour {

	private float moveSpeed = 3;
	public float monsterBite = 5;
	private bool isBiting;
	public FirstPlayer playerScript;

    Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetBool ("Attack", false);
	}
	
	void OnTriggerEnter(Collider other){     
		//animator = GetComponent(Animator);
		if (other.tag == "Player"){
			moveSpeed = 0;
			animator.SetBool("Attack", true);
			isBiting = true;
			if (playerScript.Health > 0) {
				StartCoroutine(StartKilling());
			}
		}  		
	}
	
	void OnTriggerExit (Collider other) {
		//animator = GetComponent(Animator);
		if (other.tag == "Player"){
			moveSpeed = 3;
			animator.SetBool("Attack", false);
			isBiting = false;
			StopCoroutine(StartKilling());
		}
	}

	void BiteThePlayer() {
		playerScript.Health -= monsterBite;
	}

	IEnumerator StartKilling() {
		BiteThePlayer ();
		while (isBiting) {
			yield return new WaitForSeconds(20);
			BiteThePlayer ();
		}
	}
}
