using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Vector3 aimPosOffset;
    public float minPickupAngle;
    public bool weaponEnabledDefault = false;

    public float weaponMovementSpeed;

    bool weaponEnabled;
    Transform tf;
    Transform cameraTf;

    void Awake()
    {
        tf = GetComponent<Transform>();
        cameraTf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Use this for initialization
    void Start()
    {
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
        tf.rotation = Quaternion.Slerp(tf.rotation, cameraTf.rotation * Quaternion.LookRotation(new Vector3(0, 90, 0)), weaponMovementSpeed);
        tf.position = cameraTf.position + tf.rotation * Quaternion.LookRotation(new Vector3(0, -90, 0)) * aimPosOffset;
        //tf.position = cameraTf.position;
    }

}
