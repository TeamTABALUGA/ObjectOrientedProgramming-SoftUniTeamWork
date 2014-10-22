using UnityEngine;
using System.Collections;

public class PlayerGateA : PlayerGate {
	
	public GameObject gateA;

	// Use this for initialization
	void Start () {
		this.InitialState = true;
		this.ChangedState = false;
		this.IsBGate = false;
		this.Gate = gateA;
	}
}
