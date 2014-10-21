using UnityEngine;
using System.Collections;

public class PLayerGateB : PlayerGate {

	public GameObject gateB;
	
	// Use this for initialization
	void Start () {
		this.InitialState = false;
		this.ChangedState = true;
		this.IsBGate = true;
		this.Gate = gateB;
	}
}
