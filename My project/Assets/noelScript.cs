using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noelScript : MonoBehaviour
{
    public GameObject backpackCloneTemplate;
    float turningspeed = 90;
    float speed;
    float WalkingSpeed = 1;
    float RunningMultiplier = 3;

    Animator noelsAnimator;

    // Start is called before the first frame update
    void Start()
    {
        noelsAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        noelsAnimator.SetBool("IsWalking", false);
        speed = 0;

        if (Input.GetKey(KeyCode.W))
        {
            speed = WalkingSpeed;
            noelsAnimator.SetBool("IsWalking", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed = -WalkingSpeed;
            noelsAnimator.SetBool("IsWalking", true);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= RunningMultiplier;
            noelsAnimator.SetBool("IsRunning", true);
        }
        else
            noelsAnimator.SetBool("IsRunning", false);

        if (Input.GetKey(KeyCode.D))
        {
            // Roll Left
            transform.Rotate(Vector3.up, turningspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Roll Right
            transform.Rotate(Vector3.down, turningspeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(backpackCloneTemplate, transform.position, transform.rotation);
        }

        transform.position +=speed * transform.forward * Time.deltaTime;

    }
}
