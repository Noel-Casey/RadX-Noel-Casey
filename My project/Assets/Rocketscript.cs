using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rocketscript : MonoBehaviour
{
    float turningspeed = 180;
    float thrustValue = 2;
    float gravity = 2;
    Rigidbody rb;
    Vector3 velocity, acceleration;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //acceleration = Vector3.zero;

        //acceleration += gravity * Vector3.down;

        if (Input.GetKey(KeyCode.W))
        {
            // transform.position += transform.up * Time.deltaTime;
            //acceleration += thrustValue * transform.up;
            rb.AddForce(thrustValue * transform.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Roll Left
            transform.Rotate(Vector3.up, turningspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Roll Right
            transform.Rotate(Vector3.down, turningspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            // pitch up
            transform.Rotate(Vector3.right, turningspeed * Time.deltaTime);
        }

        //Roll Using Mouse
        transform.Rotate(Vector3.up, 
            Input.GetAxis("Horizontal") * turningspeed * Time.deltaTime);

        //Roll Using Mouse
        transform.Rotate(Vector3.right,
            Input.GetAxis("Vertical") * turningspeed * Time.deltaTime);

        //velocity += acceleration * Time.deltaTime;
        //transform.position += velocity * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("ouch");
    }

}
