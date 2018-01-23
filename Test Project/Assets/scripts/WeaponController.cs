using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public float initialWeaponVerticalAngle = 80;
    public Vector3 aimPosOffset;
    public float minPickupAngle;
    public bool weaponEnabledDefault = false;

    public float weaponMovementSpeed;

    bool weaponEnabled;
    Transform tf;
    Transform cameraTf;
	PlayerController pc;
	Rigidbody rb;

    void Awake()
    {
        tf = GetComponent<Transform>();
        cameraTf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
		tf.rotation = Quaternion.LookRotation(new Vector3(-30,0,180));
		tf.position = cameraTf.position + tf.rotation * Quaternion.LookRotation(new Vector3(0, -90, 0)) * aimPosOffset;
        weaponEnabled = weaponEnabledDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTf.rotation.eulerAngles.x > minPickupAngle && cameraTf.rotation.eulerAngles.x <= 90 && true)
        {//And countdown is over
            PlayerController.onLookDirValid += updateWeaponTf;
			tf.parent = null;
            weaponEnabled = true;
        }
    }

    void updateWeaponTf()
    {
		tf.rotation = Quaternion.Lerp(tf.rotation, cameraTf.rotation * Quaternion.LookRotation(new Vector3(0, 90, 0)), Time.fixedDeltaTime * weaponMovementSpeed);
        tf.position = cameraTf.position + tf.rotation * Quaternion.LookRotation(new Vector3(0, -90, 0)) * aimPosOffset;
        rb.MovePosition(tf.position + pc.movement);
		//tf.position = cameraTf.position;
    }

}
