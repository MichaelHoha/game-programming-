using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    CharacterController controller;
    float speed = 10;
    float angularSpeed = 100;
    public GameObject aCamera; // must be connected to some object in Unity
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // connect controller to component in Unity
    }

    // Update is called once per frame
    void Update()
    {
        float rotation_about_Y;
        float rotation_about_X;

        rotation_about_Y = Input.GetAxis("Mouse X")* angularSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, rotation_about_Y, 0));
        rotation_about_X = Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        aCamera.transform.Rotate(new Vector3(-rotation_about_X,0,0));


        float dx = speed*Time.deltaTime, dz= speed* Time.deltaTime;
        // basic (primitive) motion
        //transform.Translate(new Vector3(0,0, 0.05f));

        dz *= Input.GetAxis("Vertical");// can be -1, 0 or 1
        dx *= Input.GetAxis("Horizontal");// can be -1, 0 or 1

        Vector3 motion = new Vector3(dx, -0.5f, dz); // in LOCAL coordinates
        motion = transform.TransformDirection(motion); // transforms coordinates to GLOBAL
        controller.Move(motion); // in GLOBAL coordinates
    }
}
