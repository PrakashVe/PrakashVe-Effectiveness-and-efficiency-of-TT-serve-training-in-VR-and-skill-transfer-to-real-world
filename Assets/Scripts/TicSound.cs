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
    public TextMeshPro FScoreCount;
    public TextMeshPro BScoreCount;
    public static int FscoreValue = 0;
    public static int BscoreValue = 0;

    GameObject TTball;

    public object ControllerRight { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        ticSound = GetComponent<AudioSource>();

        GameObject FSCount = GameObject.FindGameObjectWithTag("ForeHandScore"); // fetching text area of forehand
        FScoreCount = FSCount.GetComponent<TextMeshPro>();
        GameObject BSCount = GameObject.FindGameObjectWithTag("BackHandScore"); // fetching text area of Backhand
        BScoreCount = BSCount.GetComponent<TextMeshPro>();
        //GameObject BScoreCount = GameObject.FindGameObjectWithTag("BackHandScore");
        //Test
        //GameObject MestDect = GameObject.FindGameObjectWithTag("BackHandBat");
        //MestDect = MestDect.GetComponent<MeshCollider>();
      


    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Table1") || collision.collider.CompareTag("Table2") || collision.collider.CompareTag("Floor") || collision.collider.CompareTag("ForeHandBat") || collision.collider.CompareTag("BackHandBat") || collision.collider.CompareTag("ServeTarget"))
        {
            ticSound.Play();
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

        if (collision.collider.CompareTag("ForeHandBat") || collision.collider.CompareTag("BackHandBat") )
        {

            GameObject ttballclone = GameObject.FindGameObjectWithTag("ttBall");
            TTball = Resources.Load("TennisBall") as GameObject;
            GameObject spawnttball = Instantiate(TTball) as GameObject;
            spawnttball.transform.position = ttballclone.transform.position;            
            Destroy(ttballclone);
            Rigidbody rb = spawnttball.GetComponent<Rigidbody>();
            //multiply the force to 1 and then rotate the ball according to bat  angle
            rb.AddForce( 1   , 0 , 0);  // AddForce(float x, float y, float z, ForceMode mode = ForceMode.Force);

            //reference to the tracked-object component on the controller/HMD GameObject
            SteamVR_TrackedObject trackedObj;

            //get the device associated with that tracked object (which is how you access buttons and stuff)
            SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

            GameObject ControllerRight = GameObject.Find("Controller (right)");
            SteamVR_TrackedObject trackedObjectR = ControllerRight.GetComponent<SteamVR_TrackedObject>();
            trackedObjectR.SetDeviceIndex 
            //get the velocity
            Vector3 vel = device.velocity;


            // Rigidbody rb = ttballclone.GetComponent<Rigidbody>();
            // rb.AddForce(0, 200, 0);
            // //racket ka position  forward. + raket velocity 
            // //  spawner.transform.position = spawnpoint.transform.position;
            // //  Rigidbody rb = spawner.GetComponent<Rigidbody>();
            // //  rb.AddForce(Quaternion.AngleAxis(tAngle, new Vector3(0, 1, 1)) * transform.right * tVelocity);
            //
            // GameObject ControllerRight = GameObject.Find("Controller (right)");
            // SteamVR_TrackedObject trackedObjectR = ControllerRight.GetComponent<SteamVR_TrackedObject>();
            // SteamVR_Input._default.inActions.Pose.GetVelocity 

        }
    }
}
