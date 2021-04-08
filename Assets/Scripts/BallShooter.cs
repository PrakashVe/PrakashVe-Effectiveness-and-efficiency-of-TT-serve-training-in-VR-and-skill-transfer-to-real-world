using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    GameObject Tball;
    public GameObject spawnpoint;
    public int tVelocity = 200;
    public float tAngle = 155;
    //public float xAngle = 1;
    //public float zAngle = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Tball = Resources.Load("TennisBall") as GameObject;

        StartCoroutine(AutoThrow());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawner = Instantiate(Tball) as GameObject;
            spawner.transform.position = spawnpoint.transform.position;
            //spawner.transform.rotation = Quaternion.Euler(tRotateX, tRotateY, tRotateZ);
            Rigidbody rb = spawner.GetComponent<Rigidbody>();
            rb.AddForce( Quaternion.AngleAxis( tAngle , new Vector3 (0,1,1)) * transform.right * tVelocity );
            //  rb.AddForce(Quaternion.AngleAxis(xAngle, new Vector3(1, 0, 0)) * transform.forward );
            //  rb.AddForce(Quaternion.AngleAxis(zAngle, new Vector3(0, 0, 1)) * transform.forward);

        //i was tring to acess servescore script
           // Tball.GetComponent<ServeScore>().

        }
    }
    IEnumerator AutoThrow()
    {
        yield return new WaitForSeconds(3);//wait for 2 second
        Throw();
    }

    void Throw()
    {
        GameObject spawner = Instantiate(Tball) as GameObject;
        spawner.transform.position = spawnpoint.transform.position;       
        Rigidbody rb = spawner.GetComponent<Rigidbody>();
        rb.AddForce(Quaternion.AngleAxis(tAngle, new Vector3(0, 1, 1)) * transform.right * tVelocity);

        StartCoroutine(AutoThrow());
    }
}
