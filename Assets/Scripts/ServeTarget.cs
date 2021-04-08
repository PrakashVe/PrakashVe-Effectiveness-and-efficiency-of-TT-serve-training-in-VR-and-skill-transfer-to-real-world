using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

/// <summary>
///  All code merge with Serve score , so right now No use of this script
/// </summary>
public class ServeTarget : MonoBehaviour
{
    public static int SeCcount = 0;
    public GameObject[] STargetcube = new GameObject[5];
    private AudioSource STargetSound;
    public TextMeshPro SScoreCounter;
    void Start()
    {
        STargetSound = GetComponent<AudioSource>();
        //RCollider = GetComponent<Collider>();
        //RMCollider = GetComponent<MeshRenderer>();

        GameObject TMServeScore = GameObject.FindGameObjectWithTag("ServeScore"); // fetching text area of ServeScore
        SScoreCounter = TMServeScore.GetComponent<TextMeshPro>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ttBall"))
        {
           // STargetSound.Play();

            if (SScoreCounter.GetComponent<TextMeshPro>().text == (SeCcount).ToString() )
            { 
                    this.GetComponent<MeshRenderer>().enabled = false;
                    this.GetComponent<Collider>().enabled = false;
                //Debug.Log("Rcount   " + Rcount);
                    SeCcount += 1;
                    STargetcube[SeCcount].GetComponent<MeshRenderer>().enabled = true;
                    STargetcube[SeCcount].GetComponent<Collider>().enabled = true;
            }
        }
    }
}
