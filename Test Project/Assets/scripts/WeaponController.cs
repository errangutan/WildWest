using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public Vector3 aimPosOffset;
	public float minPickupAngle;
	public bool weaponEnabledDefault = false;

	bool weaponEnabled;
	Transform tf;
	Transform cameraTf;

	void Awake () {
		tf = GetComponent<Transform> ();
		cameraTf = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
		weaponEnabled = weaponEnabledDefault;
	}

	// Update is called once per frame
	void Update () {
		if (cameraTf.rotation.eulerAngles.x > minPickupAngle && true) {//And countdown is over
			PlayerController.onLookDirValid += updateWeaponTf;
			weaponEnabled = true;
		}
	}

	void updateWeaponTf () {
		tf.rotation = cameraTf.rotation * Quaternion.LookRotation(new Vector3(0,90,0));
		tf.position = cameraTf.position + cameraTf.rotation * aimPosOffset;	
		//tf.position = cameraTf.position;
	}

}
