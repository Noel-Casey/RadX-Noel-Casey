using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControlScript : MonoBehaviour
{
    public GameObject victimCloneTemplate;
    Rigidbody rb;
    float ThrustValue = 10.0f;
    float turningSpeed = 180;
    float jumpForce = 5;
    float explosionRadius = 5;
    float explosionStrength = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward * ThrustValue * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Instantiate(victimCloneTemplate, transform.position, transform.rotation);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        VictimScript victimScript = collision.gameObject.GetComponent<VictimScript>();

        Collider[] allVictims = Physics.OverlapSphere(transform.position + Vector3.down, explosionRadius);

        foreach (Collider collider in allVictims)
        {
            VictimScript newVictim = collider.gameObject.GetComponent<VictimScript>();

            if (newVictim != null)
            {
                newVictim.Bump(explosionStrength,
                            transform.position + Vector3.down, explosionRadius);
            }
            
        }



        //if (collision.gameObject.name == "Victim")
        //{
        //    Rigidbody victimRB = collision.gameObject.GetComponent<Rigidbody>();
        //    if (victimRB != null)
        //    {
        //        print("sd;jsdkj");
        //        victimRB.AddExplosionForce(1000, transform.position + Vector3.down, 5);
        //    }
        //}
    }


}