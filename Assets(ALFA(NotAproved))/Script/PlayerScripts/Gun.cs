using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour {

	public enum GunType {Semi,Burst,Auto };
	public GunType gunType;
	public float rpm;

	// Components
	public Transform spawn;
	public Transform shellEjectionPoint;
	public Rigidbody shell;
	private LineRenderer tracer;

	//System
	private float secondsBetweenShoots;
	private float nextPosibleShootTime;

	void Start(){
		secondsBetweenShoots = 60 / rpm;
		if (GetComponent<LineRenderer> ()) {
			tracer = GetComponent<LineRenderer>();
		}
	}

	public void Shoot () {


		if (CanShoot ()) {
			Ray ray = new Ray (spawn.position, spawn.forward);
			RaycastHit hit;

			float shotDistance = 20;

			if (Physics.Raycast (ray, out hit, shotDistance)) {
					shotDistance = hit.distance;
			}
			nextPosibleShootTime = Time.time + secondsBetweenShoots;

			audio.Play();

			if (tracer) {
				StartCoroutine("RenderTracer", ray.direction * shotDistance);
			}

			Rigidbody newShell = Instantiate(shell,shellEjectionPoint.position,Quaternion.identity) as Rigidbody;
			newShell.AddForce(shellEjectionPoint.forward * Random.Range(150f, 200f) + spawn.forward * Random.Range(-10f,10f));
		}
	}

	public void SootContinuous() {

		if (gunType == GunType.Auto) {
			Shoot();
		}
	}

	private bool CanShoot(){
		bool canShoot = true;
		if (Time.time < nextPosibleShootTime) {
			canShoot = false;
		}
		return canShoot;
	} 

	IEnumerator RenderTracer(Vector3 hitPoint){
		tracer.enabled = true;
		tracer.SetPosition (0, spawn.position);
		tracer.SetPosition (1, spawn.position + hitPoint);
		yield return null;
		tracer.enabled = false;
	}
}
