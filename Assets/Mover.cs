using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject ObjectToMove;
    public float velocity;
    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -velocity, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
       rb.AddForce(0, 0, -velocity, ForceMode.Impulse);
        

    }

}
