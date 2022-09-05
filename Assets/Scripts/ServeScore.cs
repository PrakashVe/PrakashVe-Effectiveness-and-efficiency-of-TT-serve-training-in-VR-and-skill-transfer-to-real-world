using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class ServeScore : MonoBehaviour
{
      /*  code depricated on 11 april 2022

    // string[] ColliedObj; // string array
    public int Scount = 0;   // to count number of hit by ball
    public string[] AColliedObject = new string[30000]; // created a array to store all tags // change soon
    public TextMeshPro SScoreCounter;
    public static int SscoreValue = 0;
    //for serve Target
    public static int SeCount = 0;
    public GameObject[] STargetcube = new GameObject[13];
    //for return target
    public static int Rcount = 0;
    public GameObject[] RTargetcube = new GameObject[9];

    GameObject TTball;
    public GameObject spawnpoint;
    void Start()
    {
        GameObject TMServeScore = GameObject.FindGameObjectWithTag("ServeScore"); // fetching text area of ServeScore
        SScoreCounter = TMServeScore.GetComponent<TextMeshPro>();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Hit By  " + collision.collider.gameObject);
        //Debug.Log("thi game object  " + this.gameObject);
        AColliedObject[Scount] = collision.collider.gameObject.tag.ToString(); // storing tag name in array hit by TT

        if (collision.collider.CompareTag("ServeTarget"))
        {
            //Destroy(this.gameObject); // destroying TT ball
            TTball = Resources.Load("TennisBall") as GameObject; // loading new tt ball in the basket
            GameObject spawnttball = Instantiate(TTball) as GameObject;
            //GameObject BasketSpawnPoint = GameObject.FindGameObjectWithTag("ttBall");

            // spawnttball.transform.position = BasketSpawnPoint.transform.position;            
            //BasketSpawnPoint.transform.position = spawnpoint.transform.position;
            spawnttball.transform.position = spawnpoint.transform.position;
            ServeTarget(); // calling script to enable next target
            Scount += 1;            
            // Call something   
            FinalTarget();
        }
       
    }
    /// <summary>
    /// Normal serve is done, 
    /// Pending : What if ball hit by net
    /// </summary>
    void FinalTarget()
    {
        for (int i = 0; i < Scount + 1; i++)
        {
            //When you try on computer
            //if (AColliedObject[i] == "Table1" && AColliedObject[i + 1] == "Table2" && AColliedObject[i + 2] == "ServeTarget")
            //if (true)
            //When you try on VR
            if ((AColliedObject[i] == "ForeHandBat" || AColliedObject[i] == "BackHandBat") && AColliedObject[i + 1] == "Table1" && AColliedObject[i + 2] == "Table2" && AColliedObject[i + 3] == "TargetCubes"+ i)
           {
               //Debug.Log("Hurraayyyyyyy ");
                SscoreValue += 1; //add 1 to score
                SScoreCounter.GetComponent<TextMeshPro>().text = SscoreValue.ToString();//convert score to string    
                //ServeTarget();
            }
            
            //  Debug.Log("AColliedObject[i]      " + AColliedObject[i]);
            else if (AColliedObject[i] == "RTarget") //When you try on computer
            //When you try on VR   if ((AColliedObject[i] == "ForeHandBat" || AColliedObject[i] == "BackHandBat") && AColliedObject[i + 1] == "RTarget")
            {             
                ReTarget();
            }
        }
    }
    void ReTarget()
    {
        GameObject.Find(RTargetcube[Rcount].name).GetComponent<MeshRenderer>().enabled = false; // find return target and disable
        GameObject.Find(RTargetcube[Rcount].name).GetComponent<Collider>().enabled = false;
        //Debug.Log("Rcount   " + Rcount);
        Rcount += 1;
        GameObject.Find(RTargetcube[Rcount].name).GetComponent<MeshRenderer>().enabled = true; // Enable next return target
        GameObject.Find(RTargetcube[Rcount].name).GetComponent<Collider>().enabled = true;
    }

    void ServeTarget() //to enable new serve target
    {
        //STargetcube[SeCcount].GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find(STargetcube[SeCount].name).GetComponent<MeshRenderer>().enabled = false;  // find serve target and disable
        GameObject.Find(STargetcube[SeCount].name).GetComponent<Collider>().enabled = false;
       // Debug.Log("Rcount   " + STargetcube[SeCount]);
        SeCount = SeCount+1;
        // destro tennis ball
       
        //Debug.Log(" SeCount " + SeCount );
        GameObject.Find(STargetcube[SeCount].name).GetComponent<MeshRenderer>().enabled = true; // Enable next serve target
        GameObject.Find(STargetcube[SeCount].name).GetComponent<Collider>().enabled = true;

        if(SeCount >13)
        {
            //break
        }

        
    }
  
    */
}
