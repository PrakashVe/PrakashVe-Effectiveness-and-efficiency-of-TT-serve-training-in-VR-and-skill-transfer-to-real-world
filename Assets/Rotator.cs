using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float xAngle, yAngle;
    public float  zAngle =1;
    public GameObject pivot;

    private void Awake()
    {
        pivot.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
    }

    void Update()
    {
        pivot.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
       
    }

}
