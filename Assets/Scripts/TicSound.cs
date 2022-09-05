using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.IO;
using Valve.VR;

/// <summary>
/// Tic sound of TT Ball when it hit and ForeHand / Backhand score count 
/// </summary>
public class TicSound : MonoBehaviour
{
    private AudioSource ticSound; // for audio sound    
    

    // Start is called before the first frame update
    void Start()
    {
        ticSound = GetComponent<AudioSource>();        
    }


private void OnCollisionEnter(Collision collision)
    {
        
            ticSound.Play();
        
        
        /* if (collision.collider.CompareTag("Table1") || collision.collider.CompareTag("Table2") || collision.collider.CompareTag("Floor") || collision.collider.CompareTag("ForeHandBat") || collision.collider.CompareTag("BackHandBat") || collision.collider.CompareTag("ServeTarget"))
         {
            // ticSound.Play();
             //Debug.Log("Hit By  "+ collision.collider.gameObject);
             if (collision.collider.gameObject.name == "BackHandBat")
             {
                 BscoreValue += 1; //add 10 to score
                 BScoreCount.GetComponent<TextMeshPro>().text = BscoreValue.ToString();                
             }
             else if (collision.collider.gameObject.name == "ForeHandBat")
             {
                 FscoreValue += 1; //add 10 to score
                 FScoreCount.GetComponent<TextMeshPro>().text = FscoreValue.ToString();
             }
         }
         if (collision.collider.CompareTag("RTarget"))
         {
         }
        */
        /*  if (collision.collider.CompareTag("ForeHandBat") || collision.collider.CompareTag("BackHandBat") )
           {
               // collider script 


               //trying to instantiate new ball and push in forward direction

               //   GameObject ttballclone = GameObject.FindGameObjectWithTag("ttBall");
               //   TTball = Resources.Load("TennisBall") as GameObject;
               //   Destroy(ttballclone);
               //   GameObject spawnttball = Instantiate(TTball) as GameObject;
               //   spawnttball.transform.position = ttballclone.transform.position;            
               //   
               //   //Rigidbody rb = spawnttball.GetComponent<Rigidbody>();
               //    //multiply the force to 1 and then rotate the ball according to bat  angle
               //  
               //   
               //     Rigidbody rb = GetComponent<Rigidbody>();
               //     var vel = rb.velocity;      //to get a Vector3 representation of the velocity
               //     var speed = vel.magnitude;
               //     speed = speed * 100;
               //      TTball.transform.Translate(Vector3.forward * speed *  Time.deltaTime);  // I dont know what am i doing now


               //rb.AddForce( transform.forward * 100);  // AddForce(float x, float y, float z, ForceMode mode = ForceMode.Force);

               //Debug.Log(  "rotation" + rb.transform.rotation.eulerAngles          ) ;
               //Debug.Log("Rcontroller rotation   " + GameObject.FindGameObjectWithTag("Rcontroller").transform.rotation.eulerAngles);  // controller rotation fetch
               // GameObject Rcontro = GameObject.FindGameObjectWithTag("Rcontroller"); 

               //  Debug.Log("velocity of tt ball " + vel);
               //  Debug.Log("speed of tt ball " + speed);
               // rb.AddForce(100 * speed, 100 * speed, 100 * speed); 
               //   rb.AddRelativeForce(Vector3.Angle (90, transform.forward) * 100);

           }*/
    }
}
