using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    public float lookSensitivity = 1;
    public GameObject camera;

    [HideInInspector]
    public Quaternion lookDirection;

    Rigidbody rb;
    Transform tf;
    Transform cameraTf;

    // Use this for initialization
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();

        cameraTf = camera.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float h_movement = Input.GetAxisRaw("Horizontal");
        float v_movement = Input.GetAxisRaw("Vertical");

        float rotationInputY = Input.GetAxisRaw("Mouse Y");
        float rotationInputX = Input.GetAxisRaw("Mouse X");

        rb.MoveRotation(Quaternion.Euler(0f, rb.rotation.eulerAngles.y +  rotationInputX * Time.fixedDeltaTime * lookSensitivity, 0f));

        Vector3 movement = tf.rotation * new Vector3(h_movement, 0f, v_movement).normalized * Time.fixedDeltaTime * speed;

        Debug.Log(cameraTf.rotation.eulerAngles.x - rotationInputY * Time.fixedDeltaTime * lookSensitivity); 

        cameraTf.rotation = Quaternion.Euler(Mathf.Clamp((cameraTf.rotation.eulerAngles.x+90)%360 - rotationInputY * Time.fixedDeltaTime * lookSensitivity, 0, 180)-90, cameraTf.rotation.eulerAngles.y , cameraTf.rotation.eulerAngles.z);
        rb.MovePosition(tf.position + movement);
    }

}
