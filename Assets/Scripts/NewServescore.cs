using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using System.IO;
using Valve.VR;


public class NewServescore : MonoBehaviour
{
    public TextMeshPro SScoreCounter;
    public static int SscoreValue = 0;

    GameObject TTball;
    public GameObject spawnpoint;

     //for serve Target
    public static int SeCount = 0;
    public GameObject[] STargetcube = new GameObject[13];

    // string[] ColliedObj; // string array
    public int Scount = 0;   // to count number of hit by ball
    public int ACount= 0;
    public int Attempt =1;

    // Start is called before the first frame update
    void Start()
    {
        //Attempt = 1;
        TTball = Resources.Load("TennisBall") as GameObject; // loading new tt ball in the basket

        GameObject TMServeScore = GameObject.FindGameObjectWithTag("ServeScore"); // fetching text area of ServeScore
        SScoreCounter = TMServeScore.GetComponent<TextMeshPro>();
    }
    void Awake()
    {
        //Attempt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// every time ball hit table 1 or target, Scount add 1, so if scount is 2 then only target should count as valid hit
    /// if its table 2 before target then completly invalid serve.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ForeHandBat"))
        {
            //attemps();
            //Attempt = Attempt + 1;
            //Debug.Log("Attempt  Attempt  :  " + Attempt);
        }
        if (collision.collider.CompareTag("Table1"))
        {
            ACount = ACount + 1;
            //attemps();
            Scount = Scount+1;           
        }
        if (collision.collider.CompareTag("Table2"))
        {
            Scount = Scount + 3;
            ACount = ACount + 1;            
        }
        if (collision.collider.CompareTag("ServeTarget"))
        {
            Scount ++;
            if (ACount > 1)
            {
                Attempt ++;
            }
                if (Scount == 2)
            {
                //Debug.Log("Scount  ServeTarget  :  " + Scount);
                Destroy(this.gameObject);  // destroy current tt ball
              destroyBall();
              ServeTarget(); // to enable next serve target
              Scount = 0;
            }
        }

    }
    void destroyBall()
    {
        //Instanciating new TT ball below Table  //if you need a ball under table write <2
        if (GameObject.FindGameObjectsWithTag("ttBall").Length < 2)
        {
            GameObject spawner = Instantiate(TTball) as GameObject;
            spawner.transform.position = spawnpoint.transform.position;
        }
    }
    void ServeTarget() //to enable new serve target
    {
        //STargetcube[SeCcount].GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find(STargetcube[SeCount].name).GetComponent<MeshRenderer>().enabled = false;  // find serve target and disable
        GameObject.Find(STargetcube[SeCount].name).GetComponent<Collider>().enabled = false;
        Debug.Log( STargetcube[SeCount] + " took " + Attempt );        
        SeCount = SeCount + 1;
        // destro tennis ball
        
        if (SeCount < 13)
        {
            //Debug.Log(" SeCount " + SeCount );
            GameObject.Find(STargetcube[SeCount].name).GetComponent<MeshRenderer>().enabled = true; // Enable next serve target
            GameObject.Find(STargetcube[SeCount].name).GetComponent<Collider>().enabled = true;            
        }
        ServeTargetScore();

    }    

    void ServeTargetScore()
    {
        SscoreValue += 1; //add 1 to score
        SScoreCounter.GetComponent<TextMeshPro>().text = SscoreValue.ToString(); //convert score to string    
    }

    void attemps()
    {
        Attempt = Attempt + 1;
        Debug.Log("Attempt  Attempt  :  " + Attempt);
    }


}
