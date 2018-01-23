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
		weaponEnabled = weaponEnabledDefault;
	}

    // Update is called once per frame
    void Update()
    {
        if (cameraTf.rotation.eulerAngles.x > minPickupAngle && cameraTf.rotation.eulerAngles.x <= 90 && !weaponEnabled)
        {//And countdown is over
			tf.parent = null;
            weaponEnabled = true;
			StartCoroutine("updateWeaponTf");
        }
    }

    IEnumerator updateWeaponTf()
    {
		while(true)
		{
			tf.rotation = Quaternion.Lerp(tf.rotation, cameraTf.rotation * Quaternion.LookRotation(new Vector3(0, 90, 0)), Time.fixedDeltaTime * weaponMovementSpeed);
        	tf.position = cameraTf.position + tf.rotation * Quaternion.LookRotation(new Vector3(0, -90, 0)) * aimPosOffset;
			yield return new WaitForFixedUpdate();
		}
    }

}
