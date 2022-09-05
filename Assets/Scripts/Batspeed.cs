using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batspeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   /*  void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        var vel = rb.velocity;      //to get a Vector3 representation of the velocity
        var speed = vel.magnitude;

        Debug.Log("velocity of tt bat " + vel);
        Debug.Log("speed of tt bat " + speed);

    }

    */
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("ttBall"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            var vel = rb.velocity;      //to get a Vector3 representation of the velocity
            var speed = vel.magnitude;

            Debug.Log("velocity of tt bat " + vel);
            Debug.Log("speed of tt bat " + speed);
        }
    }

}
