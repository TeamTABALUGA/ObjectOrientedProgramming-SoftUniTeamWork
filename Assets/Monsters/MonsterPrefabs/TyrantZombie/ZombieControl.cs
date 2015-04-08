using UnityEngine;
using System.Collections;

public class ZombieControl : MonoBehaviour {

	Animator animator;
	private float moveSpeed = 3;
	public float zombieBite = 15;
    public Player playerScript;

	private bool isBiting = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetBool ("Atack", false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void OnTriggerEnter(Collider other){     
		//animator = GetComponent(Animator);
		if (other.tag == "Player"){
			moveSpeed = 0;
			animator.SetBool("Atack", true);
			isBiting = true;
			if (playerScript.Health > 0) {
				StartCoroutine(StartKilling());
			}
		}  	
	
	}
	
	protected void OnTriggerExit (Collider other) {
		//animator = GetComponent(Animator);
		if (other.tag == "Player"){
			moveSpeed = 3;
			animator.SetBool("Atack", false);
			isBiting = false;
			StopCoroutine(StartKilling());
		}
	}

	private void BiteThePlayer() {
		playerScript.Health -= zombieBite;
	}

	private IEnumerator StartKilling() {
		BiteThePlayer ();
		while (isBiting) {
			yield return new WaitForSeconds(1);
			BiteThePlayer ();
		}
	}
}
