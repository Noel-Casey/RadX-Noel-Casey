using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camerafollowscript : MonoBehaviour
{
    private GameObject Rocket;

    // Start is called before the first frame update
    void Start()
    {
        Rocket = GameObject.Find("AtomRocket");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y + 2, Rocket.transform.position.z - 10);
    }
}
