using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat1Collider : MonoBehaviour
{
    public float ControVelocity;
    Vector3 lastControPosition;
    public Transform Contro;

    Rigidbody obj2;
    GameObject TTball;

    GameObject BatDistancePoint;
    GameObject Forehandpoint;
    GameObject Backhandpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        // get controller speed
        ControVelocity = (Contro.position - lastControPosition).magnitude / Time.deltaTime;
        lastControPosition = Contro.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //saving the hitting data 
        GameObject obj = other.gameObject;
        obj2 = obj.GetComponent<Rigidbody>();
        Vector3 vel = obj2.velocity;
            if (!other.gameObject.CompareTag("Lcontroller"))
            {
                    Destroy(other.gameObject);
            }
        //remapping the hitting data to the go as per direction 


        TTball = Resources.Load("TennisBall") as GameObject;
        if (other.gameObject.name != "Controller (left)")
        {
            GameObject spawnttball = Instantiate(TTball) as GameObject;
            spawnttball.transform.position = obj.transform.position;

            spawnttball.GetComponent<Rigidbody>().AddForceAtPosition(-vel, transform.position);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Lcontroller"))
        {

        }

        else if (collision.collider.CompareTag("ttBall"))
        {
            //remove mesh collider of forehand  bat for a sec
            GameObject GoForeHandBat = GameObject.FindGameObjectWithTag("ForeHandBat");
            GoForeHandBat.GetComponent<Collider>().enabled = false;
            GameObject Goforehandbat1 = GameObject.FindGameObjectWithTag("forehandbat1");
            GoForeHandBat.GetComponent<Collider>().enabled = false;
            GameObject Goforehandbat2 = GameObject.FindGameObjectWithTag("forehandbat2");
            GoForeHandBat.GetComponent<Collider>().enabled = false;

            //trying to instantiate new ball and push in forward direction
            GameObject fspawnpoint = GameObject.FindGameObjectWithTag("fspawnpoint");            
            // get the instantiation point
            GameObject forhandbatF = GameObject.FindGameObjectWithTag("forhandbat1");

            //load new tt ball
            TTball = Resources.Load("TennisBall") as GameObject;
            GameObject ttballclone = GameObject.FindGameObjectWithTag("ttBall");
            GameObject[] ttballclones = GameObject.FindGameObjectsWithTag("ttBall");
            //destroy each ttball
            foreach (GameObject ttballclon in ttballclones)
                Destroy(ttballclon);

            GameObject spawnttball = Instantiate(TTball) as GameObject;
            //spawnttball.transform.position = ttballclone.transform.position;
            spawnttball.transform.position = forhandbatF.transform.position;
            Rigidbody rb = spawnttball.GetComponent<Rigidbody>();

            // to calculate distance between point so i can decide its forehand or backhand
            BatDistancePoint = GameObject.FindGameObjectWithTag("BatDistancePoint");
            Forehandpoint = GameObject.FindGameObjectWithTag("Forehandpoint");
            Backhandpoint = GameObject.FindGameObjectWithTag("Backhandpoint");
            float fDist = Vector3.Distance(BatDistancePoint.transform.position, Forehandpoint.transform.position);            
            float bDist = Vector3.Distance(BatDistancePoint.transform.position, Backhandpoint.transform.position);
            Debug.Log("fDist  : " + fDist);
            Debug.Log("bDist  : " + bDist);
            float speed = ControVelocity + 2; // keep it 3
            if (fDist > bDist)
                rb.velocity = transform.TransformDirection(new Vector3(0, -speed, 0));
            else
                rb.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
        }
    }
}
