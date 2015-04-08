using UnityEngine;
using System.Collections;

public abstract class PlayerGate : MonoBehaviour {

	public FirstPlayer player;
	private GameObject gate;
	private bool initialState;
	private bool changedState;
	private int curentUnlockLevel = 5;
	protected bool isBGate;

	public bool IsBGate 
	{ 
		get { return this.isBGate;}
		set { this.isBGate = value;} 
	}

	public GameObject Gate 
	{ 
		get { return this.gate;}
		set { this.gate = value;} 
	}

	public bool InitialState 
	{ 
		get { return this.initialState;}
		set { this.initialState = value;} 
	}

	public bool ChangedState 
	{ 
		get { return this.changedState;}
		set { this.changedState = value;} 
	}

	// Use this for initialization
	void Start () {
		gate.collider.enabled = initialState;
	}

	void OnTriggerEnter(Collider other) {
		if ((other.tag == "Player") && ((player.Level >= curentUnlockLevel))) {
			if (IsBGate) {
				curentUnlockLevel = 15;
			}
			gate.collider.enabled = this.ChangedState;
		}
	}
}
