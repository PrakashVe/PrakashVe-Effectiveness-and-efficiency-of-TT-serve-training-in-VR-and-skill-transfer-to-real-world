using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaCollider : MonoBehaviour
{

    Rigidbody obj2;
    GameObject TTball;
    
    public float ControVelocity;
    Vector3 lastControPosition;
    public Transform Contro;

    GameObject BatDistancePoint;
    GameObject Forehandpoint;
    GameObject Backhandpoint;

    void Start()
    {
       
        
    }

    public void Update()
    {
        // get controller speed
        ControVelocity = (Contro.position - lastControPosition).magnitude / Time.deltaTime;
        lastControPosition = Contro.position;
        //if ( ControVelocity >2 )
        //        Debug.Log("ControVelocity   " + ControVelocity);

    }

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.gameObject.name);
        //saving the hitting data 
        GameObject obj = other.gameObject;
        obj2 = obj.GetComponent<Rigidbody>();
         Vector3 vel = obj2.velocity;
            if(!other.gameObject.CompareTag("Lcontroller"))
                {
                    Destroy(other.gameObject);
                }

        //Debug.Log("inside Bacollider.cs, going to destroy  : " + other.gameObject.name);

        //remapping the hitting data to the go as per direction 
       

        TTball = Resources.Load("TennisBall") as GameObject;
        if (other.gameObject.name != "Controller (left)")
        {
            GameObject spawnttball = Instantiate(TTball) as GameObject;
            spawnttball.transform.position = obj.transform.position;
           
            spawnttball.GetComponent<Rigidbody>().AddForceAtPosition(-vel, transform.position);
        }
      //  Debug.Log("code executed");
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Lcontroller"))
        {
            
        }

        else  if (collision.collider.CompareTag("ttBall") )
           {

            // ballspawnpoint();

            //remove mesh collider of forehand  bat for a sec
            GameObject GoForeHandBat = GameObject.FindGameObjectWithTag("ForeHandBat");
            GoForeHandBat.GetComponent<Collider>().enabled = false;

            //trying to instantiate new ball and push in forward direction
            GameObject fspawnpoint = GameObject.FindGameObjectWithTag("fspawnpoint");
            GameObject bspawnpoint = GameObject.FindGameObjectWithTag("bspawnpoint");

            // get the instantiation point
          //  GameObject forhandbatF = GameObject.FindGameObjectWithTag("forhandbat1");
           // GameObject forhandbatB = GameObject.FindGameObjectWithTag("forhandbat2");



            TTball = Resources.Load("TennisBall") as GameObject;
            GameObject ttballclone = GameObject.FindGameObjectWithTag("ttBall");
            GameObject[] ttballclones = GameObject.FindGameObjectsWithTag("ttBall");
            foreach (GameObject ttballclon in ttballclones)
                Destroy(ttballclon);

            GameObject spawnttball = Instantiate(TTball) as GameObject;
            spawnttball.transform.position = ttballclone.transform.position;
            //spawnttball.transform.position = fspawnpoint.transform.position;
            Rigidbody rb = spawnttball.GetComponent<Rigidbody>();


            // Debug.Log("inside Ba script" );
            // Debug.Log(  "this .game objecy :"    +  this.gameObject);
            // Debug.Log(" collision.collider.gameObject.name   :" + collision.collider.gameObject.name);




            // Debug.Log("Controller rotation X: " + ControDir.transform.rotation.x + " Y : " + ControDir.transform.rotation.y + " Z : " + ControDir.transform.rotation.z );

            // to calculate distance between point so i can decide its forehand or backhand
            BatDistancePoint = GameObject.FindGameObjectWithTag("BatDistancePoint");
            Forehandpoint = GameObject.FindGameObjectWithTag("fspawnpoint");
            Backhandpoint = GameObject.FindGameObjectWithTag("bspawnpoint");
            float fDist = Vector3.Distance(BatDistancePoint.transform.position, Forehandpoint.transform.position);
            //float bDist = Vector3.Distance(BatDistancePoint.transform.position, Backhandpoint.transform.localPosition);
            float bDist = Vector3.Distance(BatDistancePoint.transform.position, Backhandpoint.transform.position);

            // Debug.Log("fDist  : " + fDist);
            // Debug.Log("bDist  : " + bDist);


            //ControVelocity = ControVelocity + 1;  // velocity of controller
            // speed 4 is too fast for serving so changing is to 3
            //float speed = ControVelocity + 4; 
           
            float constant = 3f;
            // float speed = ControVelocity + constant ; // keep it 3

            //float speed = ControVelocity + 3;
            // 14 jun 2022 change from here.
            float speed;
            if (ControVelocity > 2)
            {
                speed = ControVelocity + 5;
            }
            else
            {
                speed = ControVelocity  + 3;
            }


            Debug.Log("ControVelocity   " + ControVelocity);
            if (fDist > bDist)
                rb.velocity = transform.TransformDirection(new Vector3(0, -speed, 0));
            else
                rb.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            /*
            if (ControVelocity <2)
            {
                float speed = ControVelocity + 2;
                if (fDist > bDist)
                    rb.velocity = transform.TransformDirection(new Vector3(0, -speed, 0));
                else
                    rb.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            }
            if (ControVelocity > 2)
            {
                float speed = ControVelocity + 3;
                if (fDist > bDist)
                    rb.velocity = transform.TransformDirection(new Vector3(0, -speed, 0));
                else
                    rb.velocity = transform.TransformDirection(new Vector3(0, speed, 0));

                Debug.Log("ControVelocity   " + ControVelocity);
            }            

           */

            //rb.velocity = transform.TransformDirection(new Vector3(0, 5f, 0));  //perfectly working
            //testing one of these should work x, y, z

            /*
          //testing one of these should work x, y, z  // Z is working fine
            // ok that was a shitty idea and work only with few condition
          if (ControDir.transform.rotation.z > 0)  // to identify which direction bat is facing, so I can decide if its is a forehand or backhand
              rb.velocity = transform.TransformDirection(new Vector3(0, -speed, 0));
          else
              rb.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
          */

            /*
            var vel = rb.velocity;      //to get a Vector3 representation of the velocity
            var speed = vel.magnitude;
            Debug.Log("velocity of tt bat " + vel);        
            Debug.Log("speed of tt bat " + speed);
            Debug.Log("Controller velocity" + ControVelocity);
            */
        }

    }

     void speed()
    {
        

    }
}


